# 🚀 Arquitectura de Microservicios API REST con comunicación asíncrona
Este repositorio contiene microservicios desarrollados en .NET Core 8.0 para la gestión de operaciones bancarias, que incluye la creación, modificación y eliminación de entidades como Clientes, Cuentas y Movimientos. La API está diseñada para ser flexible y escalable, con soporte para despliegue en contenedores, reportes personalizados y pruebas unitarias e integración.

## 📑 Tabla de Contenidos
- [Descripción General](#descripción-general)
- [📂 Estructura del Proyecto](#estructura-del-proyecto)
- [📦 Entidades Principales](#entidades-principales)
  - [👤 Persona](#persona)
  - [🧑‍💼 Cliente](#cliente)
  - [🏦 Cuenta](#cuenta)
  - [💸 Movimientos](#movimientos)
- [⚙️ Funcionalidades del API](#funcionalidades-del-api)
- [🧪 Pruebas](#pruebas)
- [🚢 Despliegue](#despliegue)
- [🔗 Endpoints](#endpoints)
- [📋 Instrucciones de Uso](#instrucciones-de-uso)
- [🔧 Requerimientos](#requerimientos)
- [💼 Casos de Uso](#casos-de-uso)

## 🔍 Descripción General

Este proyecto implementa un sistema bancario simple compuesto por varias entidades clave (Persona, Cliente, Cuenta y Movimientos) con una interfaz REST que maneja operaciones CRUD, generación de reportes de cuenta y registro de transacciones. La API está diseñada para permitir la fácil integración con aplicaciones frontend y sistemas de terceros a través de estándares REST.

El sistema soporta los siguientes métodos HTTP:
- **GET**: Obtener registros de Clientes, Cuentas y Movimientos.
- **POST**: Crear nuevos Clientes, Cuentas y registrar Movimientos.
- **PUT**: Actualizar información de Clientes, Cuentas y Movimientos.
- **DELETE**: Eliminar Clientes, Cuentas y Movimientos.

### ⚡ Características Técnicas:
- **Manejo de errores** robusto con mensajes personalizados y manejo de excepciones.
- **Validación de datos** implementada utilizando las capacidades de validación de modelos de .NET Core.
- **Pruebas unitarias e integración** usando xUnit.
- **Despliegue en contenedores Docker**, facilitando la portabilidad y escalabilidad de la solución.

## 📂 Estructura del Proyecto

El proyecto está organizado bajo el patrón de arquitectura de capas para mantener la separación de responsabilidades. Las capas principales son:
- **API Layer**: Controladores de API REST.
- **Service Layer**: Contiene la lógica de negocio.
- **Data Access Layer**: Encapsula la interacción con la base de datos.
- **Entities**: Definición de modelos de datos para Clientes, Cuentas y Movimientos.

## 📦 Entidades Principales

### 👤 Persona
Clase base que incluye atributos generales:
- **Nombre**: Nombre completo de la persona.
- **Género**: Género de la persona.
- **Edad**: Edad de la persona.
- **Identificación**: Número de identificación único.
- **Dirección**: Dirección de residencia.
- **Teléfono**: Número telefónico.

### 🧑‍💼 Cliente
Entidad que hereda de `Persona` y agrega los siguientes atributos:
- **ClienteID**: Identificador único para el cliente (PK).
- **Contraseña**: Contraseña de acceso.
- **Estado**: Estado activo/inactivo del cliente.

### 🏦 Cuenta
Entidad que representa una cuenta bancaria, que contiene:
- **Número de cuenta**: Identificador único de la cuenta (PK).
- **Tipo de cuenta**: Puede ser Ahorro o Corriente.
- **Saldo inicial**: Saldo con el que inicia la cuenta.
- **Estado**: Estado activo/inactivo de la cuenta.

### 💸 Movimientos
Entidad que registra las transacciones realizadas en una cuenta:
- **Fecha**: Fecha en la que se realizó el movimiento.
- **Tipo de movimiento**: Depósito o Retiro.
- **Valor**: Monto del movimiento.
- **Saldo**: Saldo resultante después del movimiento.

## ⚙️ Funcionalidades del API

### F1: CRUD de Entidades
Se proporciona soporte completo para las operaciones de creación, lectura, actualización y eliminación (CRUD) para las entidades:
- **Clientes**: `/api/clientes`
- **Cuentas**: `/api/cuentas`
- **Movimientos**: `/api/movimientos`

### F2: Registro de Movimientos
Los movimientos en las cuentas se pueden registrar utilizando el endpoint correspondiente, actualizando automáticamente el saldo disponible. Si una cuenta no tiene saldo suficiente para un retiro, se devuelve el mensaje `"Saldo no disponible"`.

### F3: Reportes de Estado de Cuenta
Genera un reporte detallado de los movimientos y saldos de las cuentas de un cliente, dentro de un rango de fechas específico:
- **Endpoint**: `/api/reportes?fecha={rango}`

El reporte incluye:
- Cuentas asociadas con sus respectivos saldos.
- Detalle de los movimientos en las cuentas.

### F4: Pruebas Unitarias e Integración
- Implementación de pruebas unitarias para la entidad `Cliente`.
- Pruebas de integración para verificar la interacción entre las diferentes capas del sistema.

### F5: Despliegue en Contenedores
La solución está preparada para ser desplegada en **Docker**. Simplemente sigue las instrucciones para construir y ejecutar el contenedor.

## 🧪 Pruebas

Se han implementado pruebas unitarias e integración usando **xUnit**. Estas pruebas aseguran la correcta funcionalidad de los servicios principales, incluyendo:
- Validaciones de creación de clientes.
- Simulaciones de movimientos de cuenta.

## 🚢 Despliegue

Para desplegar la solución en contenedores Docker, sigue los siguientes pasos:
1. Clonar el repositorio.
2. Navegar a la raíz del proyecto.
3. Ejecutar el comando: `docker build -t nombre_imagen .`
4. Ejecutar el contenedor: `docker run -d -p 8080:80 nombre_imagen`

## 🔗 Endpoints

Los endpoints principales que se exponen son:
- **/api/clientes**: Operaciones CRUD para clientes.
- **/api/cuentas**: Operaciones CRUD para cuentas bancarias.
- **/api/movimientos**: Operaciones CRUD y registro de movimientos.
- **/api/reportes**: Generación de reportes de estado de cuenta por rango de fechas.

## 📋 Instrucciones de Uso

1. Ejecuta la solución localmente o despliega el contenedor Docker.
2. Usa una herramienta como **Postman** o **curl** para interactuar con los endpoints.
3. Ejemplos de uso:
   - Crear cliente: `POST /api/clientes`
   - Registrar movimiento: `POST /api/movimientos`
   - Obtener reporte de cuentas: `GET /api/reportes?fecha={rango}`

## 🔧 Requerimientos

- **.NET Core 6.0 o superior**
- **Docker** para despliegue en contenedores
- **SQL Server** para la base de datos
- Herramienta de prueba como **Postman** o **curl**

## 💼 Casos de Uso

1. **Creación de un nuevo cliente**: Permite registrar nuevos clientes con su información personal.
2. **Apertura de cuentas**: Creación de cuentas bancarias para los clientes existentes.
3. **Registro de movimientos**: Permite registrar depósitos y retiros, actualizando los saldos disponibles.
4. **Generación de reportes**: Se pueden generar reportes detallados por rango de fechas para visualizar los movimientos y saldos de las cuentas de un cliente.

---

Este proyecto está diseñado para ser un ejemplo funcional de cómo estructurar y desplegar microservicios en .NET Core, enfocándose en la creación de APIs RESTful escalables y bien organizadas.
