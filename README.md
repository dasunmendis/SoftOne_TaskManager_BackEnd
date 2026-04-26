# SoftOne Task Manager - Backend API

[![.NET](https://img.shields.io/badge/.NET-8.0-512bd4.svg)](https://dotnet.microsoft.com/download)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A robust, scalable backend built with **.NET Core** following **Clean Architecture** principles. This project serves as the core engine for the SoftOne Task Manager application, providing a secure and efficient API for task management.

---

## 🚀 Key Features

- **Clean Architecture**: Decoupled layers for Domain, Application, Infrastructure, and API.
- **CQRS Pattern**: Implementation using **MediatR** for separation of concerns between reads and writes.
- **Validation**: Strong typing and business rule validation using **FluentValidation**.
- **Data Mapping**: Automated object-to-object mapping with **AutoMapper**.
- **ORM**: High-performance data access using **Entity Framework Core**.
- **API Documentation**: Interactive API exploration with **Swagger/OpenAPI**.
- **Authentication**: Custom **Basic Authentication** implementation.

---

## 🛠️ Tech Stack

- **Framework**: .NET 8.0 / 9.0
- **Database**: Microsoft SQL Server
- **ORM**: EF Core
- **Libraries**:
  - `MediatR` (CQRS)
  - `AutoMapper` (Object Mapping)
  - `FluentValidation` (Input Validation)
  - `Swashbuckle.AspNetCore` (Swagger)

---

## 📂 Project Structure

The project follows the **Clean Architecture (Onion)** pattern to ensure high maintainability and testability.

```bash
SoftOne_TaskManager_BackEnd/
├── TaskManager.API/            # Entry point, Controllers, Auth, Middlewares
├── TaskManager.Application/    # Business logic, CQRS (Features), DTOs, Interfaces
├── TaskManager.Domain/         # Core Entities, Value Objects, Domain Exceptions
└── TaskManager.Infrastructure/ # Data Access, Repositories, EF Migrations, External Services
```

### Layer Responsibilities:
- **Domain**: Contains the core business entities and logic that is independent of any framework.
- **Application**: Orchestrates the flow of data. Defines use cases (Commands/Queries) and interfaces.
- **Infrastructure**: Implements interfaces defined in Application layer (e.g., Database context, Repositories).
- **API**: Handles HTTP requests, CORS, and dependency injection root.

---

## 🏁 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or LocalDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [VS Code](https://code.visualstudio.com/)

### Setup
1. **Clone the repository**:
   ```bash
   git clone https://github.com/dasunmendis/SoftOne_TaskManager_BackEnd.git
   ```

2. **Update Connection String**:
   Check `TaskManager.API/appsettings.Development.json` and ensure the `DefaultConnection` matches your local SQL Server instance.

3. **Apply Migrations**:
   Open a terminal in the root directory and run:
   ```bash
   dotnet ef database update --project TaskManager.Infrastructure --startup-project TaskManager.API
   ```

4. **Run the Project**:
   ```bash
   dotnet run --project TaskManager.API
   ```

---

## 💻 Useful Commands

| Action | Command |
| :--- | :--- |
| **Build Solution** | `dotnet build` |
| **Run API** | `dotnet run --project TaskManager.API` |
| **Add Migration** | `dotnet ef migrations add <Name> --project TaskManager.Infrastructure --startup-project TaskManager.API` |
| **Update Database** | `dotnet ef database update --project TaskManager.Infrastructure --startup-project TaskManager.API` |
| **Restore Packages**| `dotnet restore` |

---

## 📜 Coding Guidelines

To maintain code quality and consistency, please follow these rules:

1. **CQRS Everywhere**: All business logic should reside in the `Application` layer within the `Features` folder. Use MediatR Commands for writes and Queries for reads.
2. **Lean Controllers**: Controllers should only be responsible for routing and returning results. They should delegate all logic to MediatR.
3. **DTOs for Input/Output**: Never expose Domain Entities directly. Use DTOs and AutoMapper.
4. **Validation**: Use FluentValidation for all request DTOs. Do not use Data Annotations for business logic.
5. **Dependency Injection**: Use the `DependencyInjection.cs` files in each layer to register services.
6. **Error Handling**: Use global exception handling or middleware to manage API responses consistently.

---

## 🔓 Authentication

The API uses **Basic Authentication**.
- **Header**: `Authorization: Basic <base64(username:password)>`
- **Current Setup**: See `BasicAuthenticationHandler.cs` in the API project for logic.

---

## 📖 API Documentation

Once the project is running, you can access the Swagger UI to explore and test the endpoints:
- **URL**: `http://localhost:<port>/swagger` (Port usually 5000/5001 or as defined in `launchSettings.json`)

---

## 🤝 Contributing

1. Create a new branch: `git checkout -b feature/your-feature`
2. Commit your changes: `git commit -m 'Add some feature'`
3. Push to the branch: `git push origin feature/your-feature`
4. Open a Pull Request.

---

Developed with ❤️ by [Dasun Mendis](https://github.com/dasunmendis)
