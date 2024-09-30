using System.Text.Json.Serialization;
using DpWorldClient.UI.Converters;

namespace DpWorldClient.UI.Models
{
    public class ContainerModel
    {
        [JsonPropertyName("recordId")]
        public string RecordId { get; set; }

        [JsonPropertyName("containerNo")]
        public string ContainerNo { get; set; }

        [JsonPropertyName("isoCode")]
        public string IsoCode { get; set; }

        [JsonPropertyName("YardInTime")]
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? YardInTime { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("weight")]
        public string Weight { get; set; }

        [JsonPropertyName("vgmWeight")]
        public string VgmWeight { get; set; }

        [JsonPropertyName("lineOperator")]
        public string LineOperator { get; set; }

        [JsonPropertyName("portOfDischarge")]
        public string PortOfDischarge { get; set; }

        [JsonPropertyName("portOfLoading")]
        public string PortOfLoading { get; set; }

        [JsonPropertyName("bookingNo")]
        public string BookingNo { get; set; }

        [JsonPropertyName("TemperatureReq")]
        public string TemperatureReq { get; set; }

        [JsonPropertyName("CurrentTemp")]
        public string CurrentTemp { get; set; }

        [JsonPropertyName("transitState")]
        public string TransitState { get; set; }

        [JsonPropertyName("locType")]
        public string LocType { get; set; }

        [JsonPropertyName("IsOOG")]
        public int IsOOG { get; set; }

        [JsonPropertyName("HazardousClass")]
        public string HazardousClass { get; set; }

        [JsonPropertyName("yardPosition")]
        public string YardPosition { get; set; }

        [JsonPropertyName("vessel")]
        public string Vessel { get; set; }

        [JsonPropertyName("voyage")]
        public string Voyage { get; set; }

        [JsonPropertyName("PayToDate")]
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? PayToDate { get; set; }

        [JsonPropertyName("damage")]
        public string Damage { get; set; }

        [JsonPropertyName("outBoundCarrier")]
        public string OutBoundCarrier { get; set; }

        [JsonPropertyName("consignee")]
        public string Consignee { get; set; }

        [JsonPropertyName("dwellTime")]
        [JsonConverter(typeof(NullableDoubleConverter))]
        public double? DwellTime { get; set; }

        [JsonPropertyName("storageDays")]
        [JsonConverter(typeof(NullableDoubleConverter))]
        public double? StorageDays { get; set; }

        [JsonPropertyName("storageFees")]
        [JsonConverter(typeof(NullableDoubleConverter))]
        public double? StorageFees { get; set; }

        [JsonPropertyName("lineHold")]
        public string LineHold { get; set; }

        [JsonPropertyName("dgaHold")]
        public string DgaHold { get; set; }

        [JsonPropertyName("holds")]
        public string Holds { get; set; }

        [JsonPropertyName("billofLading")]
        public string BillofLading { get; set; }

        [JsonPropertyName("containerUrl")]
        public string ContainerUrl { get; set; }

        [JsonPropertyName("TotalChargedAmount")]
        public double TotalChargedAmount { get; set; }

        [JsonPropertyName("TotalAmount")]
        public double TotalAmount { get; set; }

        [JsonPropertyName("TaxAmount")]
        public double TaxAmount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("UnitCharges")]
        public List<UnitChargeModel> UnitCharges { get; set; }
    }
}
