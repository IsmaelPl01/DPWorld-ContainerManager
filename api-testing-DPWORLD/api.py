from flask import Flask, jsonify, request
from flask_cors import CORS
import json
import datetime

app = Flask(__name__)
CORS(app)

class CustomJSONEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, datetime.datetime):
            return obj.isoformat()
        if obj is None:
            return None
        return super().default(obj)

app.json_encoder = CustomJSONEncoder

with open('ChargesSamples.json', 'r') as file:
    containers_data = json.load(file)

@app.route('/api/containers', methods=['GET'])
def get_containers():
    line_hold = request.args.get('lineHold')
    sizes = request.args.get('sizes')
    container_type = request.args.get('containerType')
    search_term = request.args.get('searchTerm')
    price_order = request.args.get('priceOrder')  # Nuevo parámetro para el orden de precios

    filtered_data = containers_data

    if line_hold:
        filtered_data = [container for container in filtered_data if container.get('lineHold') == line_hold]
    
    if sizes:
        sizes_list = sizes.split(',')
        filtered_data = [container for container in filtered_data if container.get('isoCode', '')[:2] in sizes_list]
    
    if container_type:
        if container_type == 'REFRIGERATED':
            filtered_data = [container for container in filtered_data if container.get('TemperatureReq') and container.get('TemperatureReq') != 'NONE']
        elif container_type == 'NON_REFRIGERATED':
            filtered_data = [container for container in filtered_data if not container.get('TemperatureReq') or container.get('TemperatureReq') == 'NONE']
    
    if search_term:
        filtered_data = [container for container in filtered_data if search_term.lower() in container.get('containerNo', '').lower()]

    # Ordenar por TotalChargedAmount
    if price_order:
        reverse = price_order.upper() == 'HIGH_TO_LOW'
        filtered_data = sorted(filtered_data, key=lambda x: x.get('TotalChargedAmount', 0), reverse=reverse)

    response = {
        "message": "Data retrieved successfully",
        "isSuccess": True,
        "statusCode": "200",
        "body": filtered_data
    }
    return jsonify(response)

@app.route('/api/container/<string:record_id>', methods=['GET'])
def get_container(record_id):
    container = next((container for container in containers_data if container.get('recordId') == record_id), None)
    
    if container:
        response = {
            "message": "Container data retrieved successfully",
            "isSuccess": True,
            "statusCode": "200",
            "body": container
        }
    else:
        response = {
            "message": "Container not found",
            "isSuccess": False,
            "statusCode": "404",
            "body": None
        }
    
    return jsonify(response)

if __name__ == '__main__':
    app.run(debug=True)