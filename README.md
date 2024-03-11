# ASP.NET Core Application with EF Core - Company, Vehicle, and Item Management

This project is an ASP.NET Core application designed to manage logistics operations, focusing on handling vehicles, items, and companies. It uses Entity Framework Core for data persistence and offers a RESTful API for managing entities within the application.

## Features

- **Entity Framework Core**: Utilizes EF Core for ORM, efficiently managing database operations with companies, vehicles, and items.
- **ASP.NET Core API**: Implemented a RESTful API architecture, providing a backend structure for handling HTTP requests.
- **Data Validation**: Enforces data integrity and validation to ensure reliability and consistency of the application data.
- **CRUD Operations**: Supports basic Create, Read, Update, and Delete operations for managing companies, vehicles, and items.
- **Async/Await**: Implemented asynchronous programming patterns to enhance performance and responsiveness.
- **Error Handling**: Implemented error handling to manage and log exceptions, providing meaningful feedback to the user.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- C#

## Getting Started

### Prerequisites

- .NET 6.0 SDK
- Visual Studio or VS Code
- SQL Server (or any compatible database)

### Setup and Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Navigate to the project directory and restore dependencies:
   ```bash
   dotnet restore
   ```
3. Update the connection string in `appsettings.json` to match your database configuration.
4. Apply migrations to your database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## Usage

The application supports the following operations:

- Add, get, update, and delete companies, vehicles, and items.
- Also you can find items based on criteria and manage company earnings and vehicle assignments.
