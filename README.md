# 📌 CrediarioW

A RESTful API for managing **store credit (crediário)** operations.  
Currently developed as a **backend-only API**, designed to be easily integrated with a future frontend application (web or mobile).

Built with **ASP.NET Core**, **Entity Framework Core**, **JWT Authentication**, and **PostgreSQL**.

---

## 🚀 Technologies

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- PostgreSQL  
- JWT Authentication  
- Swagger / OpenAPI  
- Npgsql  
- Supabase (PostgreSQL hosting)

---

## 🧱 Architecture

The project follows a **layered architecture** based on a **MVC**, separating responsibilities to ensure scalability and maintainability:

- **Controllers** → HTTP  
- **Services** → Business rules
- **Models** ->  Data model
- **Repositories** → Data access  
- **Infrastructure** → Cross-cutting concerns (JWT, database, configs)

This structure allows the API to be consumed by **any future frontend**, such as:
- Web applications (React, Angular, Vue)
- Mobile apps (Flutter, React Native)
- Other backend services

---

## 🔐 Authentication (JWT)

The API uses **JWT Bearer Authentication** to protect endpoints.

## ▶️ Running the API

### Requirements

- .NET 8 SDK
- PostgreSQL instance

## 🔒 Configuration Files

This project does **not** include the `appsettings.json` file in version control, as it contains sensitive information such as database credentials and JWT secrets.

To run the project locally:

1. Copy the example configuration file:
   ```bash
   cp appsettings.example.json appsettings.json

### 🗄️ Database Setup & Migrations

This API **does not create a database automatically**.
The database **must already exist** before running the application.
When the application starts, Entity Framework Core automatically applies any pending migrations using:

```csharp
context.Database.Migrate();
```

### Build and Run
Commands

  ```bash
  dotnet restore
  dotnet build
  dotnet run
  ```
