<h1 align="center">api-base-net8</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET">
  <img src="https://img.shields.io/badge/PostgreSQL-16-blue" alt="PostgreSQL">
  <img src="https://img.shields.io/badge/Architecture-Layered-orange" alt="Architecture">
</p>

This project serves as a template for .NET 8 APIs, following Clean Architecture principles. It comes with a basic authentication and authorization system already in place, providing a robust and scalable structure for developing secure and high-quality APIs. Ideal for projects that require a strong foundation with best practices in design and security.

## Features

- **Layered Architecture**: Clear separation of concerns between layers.
- **.NET 8.0**: Latest .NET version with performance improvements.
- **PostgreSQL**: Pre-configured integration with PostgreSQL database.
- **Extensible**: Easy to extend and adapt for various types of APIs.
- **Best Practices**: Implements good coding practices like dependency injection and repository pattern.


## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [PostgreSQL 16](https://www.postgresql.org/download/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Setup

1. Create a new repository with this template:

   
![image](https://github.com/user-attachments/assets/22a33fe0-92f2-4d32-b361-160b3c409772)


3. Atualize o `appsettings.json` com sua string de conexão do PostgreSQL:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=seubanco;Username=seuusuario;Password=suasenha"
   }

4. Execute as migrações do banco de dados:

        dotnet ef database update

5. Inicie a API:
   
       dotnet run

## Contact

For inquiries or support, please contact me through the following channels:

- **Email**: augusto.n.omena@gmail.com
- **LinkedIn**: [august-omena](https://www.linkedin.com/in/augusto-omena/)

