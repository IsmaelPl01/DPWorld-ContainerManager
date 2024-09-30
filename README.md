# DPWorld-ContainerManager
Aplicación de gestión y filtrado de contenedores para DP World, diseñada para facilitar la visualización y selección de contenedores mediante un panel interactivo y filtros.

## Funcionalidades
- **Filtrado de contenedores**: Los usuarios pueden buscar contenedores por número y aplicar filtros según categorías predefinidas.
- **Selección de contenedores**: Permite seleccionar y deseleccionar contenedores individualmente o en bloque.
- **Paginación**: Navega fácilmente entre las páginas de resultados con control de elementos por página.
- **Resumen de selección**: Muestra el número total de contenedores seleccionados y el monto total correspondiente.

## Tecnologías
- **Frontend**: [MudBlazor](https://mudblazor.com/) para la interfaz de usuario.
- **Backend**: API básica en Python (Flask).
- **Lenguajes**: C# y Python.

## Instalación

### Clonar el repositorio

1. Clona este repositorio:
    ```bash
    git clone https://github.com/IsmaelPl01/DPWorld-ContainerManager.git
    ```
2. Dirígete al directorio del proyecto:
    ```bash
    cd DPWorld-ContainerManager
    ```

### Ejecutar la aplicación .NET (Frontend)

3. Restaura los paquetes NuGet:
    ```bash
    dotnet restore
    ```

4. Ejecuta el proyecto:
    ```bash
    dotnet run
    ```

### Ejecutar la API (Backend en Python)

1. Dirígete a la carpeta de la API:
    ```bash
    cd api-testing-DPWORLD
    ```

2. Crea un entorno virtual (opcional, pero recomendado):
    ```bash
    python3 -m venv venv
    ```

3. Activa el entorno virtual:
    - En **Linux/macOS**:
      ```bash
      source venv/bin/activate
      ```
    - En **Windows**:
      ```bash
      .\venv\Scripts\activate
      ```

4. Instala las dependencias requeridas:
    ```bash
    pip install flask flask-cors
    ```

5. Inicia la API:
    ```bash
    python api.py
    ```

6. La API estará disponible en: `http://127.0.0.1:5000/api/containers`

### Uso de la API

- **Obtener todos los contenedores**: 
  ```bash
  GET /api/containers

- **Filtrar contenedores**: 
  ```bash
    GET /api/containers?lineHold=value&sizes=value&containerType=value&searchTerm=value&priceOrder=value

- **Obtener un contenedor específico por recordId**: 
  ```bash
    GET /api/container/<recordId>

  

