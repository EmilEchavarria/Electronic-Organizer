# 📒 Electronic Organizer

An **Electronic Organizer** developed in **C# .NET Framework** using **Windows Forms** and a **four-layer architecture** with MySQL as the database.

## 🚀 Features
- 📌 **Complete CRUD**: Insert, modify, search, and delete records.
- 🖥 **User-friendly interface**: Intuitive design with Windows Forms.
- 💾 **MySQL Database**: Secure and efficient storage.
- 📂 **Multi-layer Architecture**: Separation into **Data Layer, Business Layer, Presentation Layer, and Entity Layer**.
- 🔌 **Optimized Connection**: MySQL handling with `MySql.Data`.

## 🛠️ Technologies Used
- 🔹 C# (.NET Framework)
- 🔹 Windows Forms
- 🔹 MySQL
- 🔹 MySQL Connector/NET
- 🔹 Multi-layer Architecture

## 📸 Screenshots
<img src="https://github.com/user-attachments/assets/5fe06e26-ed2b-4490-9d9b-19656a38aef3" width="300" />
<img src="https://github.com/user-attachments/assets/6c21b2f3-41cf-4dfe-9a72-97f66958e6d4" width="300" />
<img src="https://github.com/user-attachments/assets/b21cca2a-533f-4ba4-bf8c-6c5403a074c8" width="300" />
<img src="https://github.com/user-attachments/assets/50d88f7b-7848-4dfd-a200-2aee4041680b" width="300" />
<img src="https://github.com/user-attachments/assets/6eb02047-720b-49de-bd74-620f1df74c87" width="300" />

## 📥 Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/tuusuario/Electronic-Organizer.git
   ```
2. Open the project in **Visual Studio**.
3. Restore the required NuGet packages.
4. Configure the MySQL database connection in `app.config`.
5. Execute the SQL scripts on your MySQL server.
6. Compile and run the application.

## 🛠 Database Configuration
Run the following SQL script in MySQL to create the database and necessary tables:

```sql
CREATE DATABASE organizer;

USE organizer;

-- CREATE THE AGENDA TABLE

CREATE TABLE agenda (
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FIRST_NAME VARCHAR(45) NOT NULL,
    LAST_NAME VARCHAR(45) NOT NULL,
    BIRTH_DATE DATE NOT NULL,
    ADDRESS VARCHAR(50) NOT NULL,
    GENDER VARCHAR(10) NOT NULL,
    MARITAL_STATUS VARCHAR(15) NOT NULL,
    MOBILE VARCHAR(15) NOT NULL UNIQUE,
    PHONE VARCHAR(15) NOT NULL UNIQUE,
    EMAIL VARCHAR(50) NOT NULL UNIQUE,
    STATUS TINYINT NOT NULL DEFAULT 1
);
```

## 🤝 Contributions
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Make your changes and commit (`git commit -m 'Add new feature'`).
4. Submit a **pull request**.

## 📝 License
This project is under the **MIT** license. See the `LICENSE` file for more details.

---
_Developed by [Emil Echavarria](https://github.com/EmilEchavarria)_ ✨
