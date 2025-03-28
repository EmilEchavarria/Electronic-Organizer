# 📒 Electronic Organizer

Un **Organizador Electrónico** desarrollado en **C# .NET Framework** utilizando **Windows Forms** y una arquitectura **multicapa (4 capas)** con MySQL como base de datos.

## 🚀 Características
- 📌 **CRUD Completo**: Insertar, modificar, buscar y eliminar registros.
- 🖥 **Interfaz intuitiva**: Diseño amigable con Windows Forms.
- 💾 **Base de Datos MySQL**: Almacenamiento seguro y eficiente.
- 📂 **Arquitectura Multicapa**: Separación en **Capa de Datos, Capa de Negocios, Capa de Presentación y Capa de Entidades**.
- 🔌 **Conexión optimizada**: Manejo de MySQL con `MySql.Data`.

## 🛠️ Tecnologías Utilizadas
- 🔹 C# (.NET Framework)
- 🔹 Windows Forms
- 🔹 MySQL
- 🔹 MySQL Connector/NET
- 🔹 Arquitectura Multicapa

## 📸 Capturas de Pantalla
_Agrega aquí imágenes de la interfaz de usuario._

## 📥 Instalación
1. Clona el repositorio:
   ```sh
   git clone https://github.com/tuusuario/Electronic-Organizer.git
   ```
2. Abre el proyecto en **Visual Studio**.
3. Restaura los paquetes NuGet necesarios.
4. Configura la conexión a tu base de datos MySQL en `app.config`.
5. Ejecuta los scripts SQL en tu servidor MySQL.
6. Compila y ejecuta la aplicación.

## 🛠 Configuración de la Base de Datos
Ejecuta el siguiente script en MySQL para crear la base de datos y las tablas necesarias:

```sql
CREATE DATABASE organizer;

USE organizer;

-- CREAR LA TABLA AGENDA

CREATE TABLE agenda (
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(45) NOT NULL,
    APELLIDO VARCHAR(45) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL,
    DIRECCION VARCHAR(50) NOT NULL,
    GENERO VARCHAR(10) NOT NULL,
    ESTADO_CIVIL VARCHAR(15) NOT NULL,
    MOVIL VARCHAR(15) NOT NULL UNIQUE,
    TELEFONO VARCHAR(15) NOT NULL UNIQUE,
    CORREO_ELECTRONICO VARCHAR(50) NOT NULL UNIQUE,
	ESTADO TINYINT NOT NULL DEFAULT 1
);

```

## 🤝 Contribuciones
¡Las contribuciones son bienvenidas! Para contribuir:
1. Haz un **fork** del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -m 'Añadir nueva funcionalidad'`).
4. Envía un **pull request**.

## 📝 Licencia
Este proyecto está bajo la licencia **MIT**. Consulta el archivo `LICENSE` para más detalles.

---
_Desarrollado por [Emil Echavarria](https://github.com/EmilEchavarria)_ ✨
