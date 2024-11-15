<h1 align="center">VetConnect</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET">
  <img src="https://img.shields.io/badge/PostgreSQL-16-blue" alt="PostgreSQL">
  <img src="https://img.shields.io/badge/Architecture-Layered-orange" alt="Architecture">
</p>

API do projeto VetConnect, é um app para clinicas veterinárias e PetShops, aqui o cliente terá acesso fácil a seus serviços.

Esse projeto incluí um Frontend em Angular 18: https://github.com/AugustoOmena/Frontend-VetConnect

Seguindo os passos listados voce deve conseguir usar o projeto sem muitas dificuldades. Caso tenha dificuldades estou a disposição para ajudar.

Estado Atual:
![image](https://github.com/user-attachments/assets/a52854e9-ebaa-4f24-8523-3d5752152f55)


## Pré requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [PostgreSQL 16](https://www.postgresql.org/download/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- IDE (Visual Studio 2022 ou Rider)

## Setup

1. Clone o repositório:
<img src="https://github.com/user-attachments/assets/0fd91b2f-7440-4958-9f55-fc8006c8b50e" width="300" />

2. Atualize o `appsettings.json` com sua string de conexão do PostgreSQL:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=seubanco;Username=seuusuario;Password=suasenha"
   }

3. Execute as migrações do banco de dados:

        dotnet ef database update

4. Inicie a API:
   
       dotnet run

## Contato

For inquiries or support, please contact me through the following channels:

- **Email**: augusto.n.omena@gmail.com
- **LinkedIn**: [august-omena](https://www.linkedin.com/in/augusto-omena/)

