# 🚀 DotNet Angular App 2

A modern **Full Stack CRUD Application** built using **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **Angular**. The application demonstrates a clean architecture using the **Repository Pattern**, Dependency Injection, RESTful APIs, and a responsive Angular frontend for managing student/class records.

---

## 📌 Features

- ✅ ASP.NET Core Web API
- ✅ Angular Frontend
- ✅ Entity Framework Core (Code First)
- ✅ SQL Server Integration
- ✅ Repository Pattern
- ✅ Dependency Injection
- ✅ RESTful CRUD Operations
- ✅ Asynchronous Programming
- ✅ OpenAPI Documentation
- ✅ Scalar API Documentation
- ✅ Bootstrap UI
- ✅ Modal Popup for Create/Edit
- ✅ Clean Folder Structure
- ✅ Separation of Concerns

---

# 🛠 Tech Stack

### Backend

- ASP.NET Core (.NET 9)
- C#
- Entity Framework Core
- SQL Server
- LINQ
- Repository Pattern
- Dependency Injection
- OpenAPI
- Scalar API

### Frontend

- Angular
- TypeScript
- Bootstrap 5
- HTML5
- CSS3
- RxJS
- Angular Router
- Angular HttpClient

---

# 📂 Project Structure

```
DotNet_Angular_App_2
│
├── DotNet_Angular_App_2
│   ├── Controllers
│   ├── Data
│   ├── Migrations
│   ├── Models
│   ├── Repositories
│   ├── Program.cs
│   └── appsettings.json
│
├── DotNet_Angular_App_2_Frontend
│   └── UI
│       ├── src
│       │   ├── app
│       │   │   ├── component
│       │   │   ├── Model
│       │   │   ├── Services
│       │   │   ├── app.routes.ts
│       │   │   ├── app.config.ts
│       │   │   └── app.ts
│       │   └── main.ts
│       └── package.json
│
└── README.md
```

---

# ⚙ Backend Architecture

```
Client
   │
   ▼
Controller
   │
   ▼
Repository Interface
   │
   ▼
Repository
   │
   ▼
DbContext
   │
   ▼
SQL Server
```

---

# 📁 Backend Folder Description

## Controllers

Contains all REST API endpoints.

```
GET
POST
PUT
DELETE
```

---

## Models

Contains entity classes.

Example

```csharp
public class Class
{
    public int Id { get; set; }

    public string Name { get; set; }

    public char Grade { get; set; }

    public bool IsPassed { get; set; }
}
```

---

## Data

Contains

- DbContext
- Database Configuration

---

## Repositories

Contains

- Repository Interface
- Repository Implementation

Responsible for all database operations.

---

## Migrations

Contains EF Core migration files generated using Code First.

---

# 🌐 API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | /api/Class | Get All Students |
| GET | /api/Class/{id} | Get Student By Id |
| POST | /api/Class | Create Student |
| PUT | /api/Class/{id} | Update Student |
| DELETE | /api/Class/{id} | Delete Student |

---

# 🖥 Frontend Features

- Display all students
- Add student
- Update student
- Delete student
- Bootstrap Modal
- Responsive UI
- API Integration
- Routing
- Service Layer
- Model Layer

---

# 🧱 Angular Structure

```
src
│
├── app
│   ├── component
│   │      └── main-class
│   │
│   ├── Model
│   │
│   ├── Services
│   │
│   ├── app.routes.ts
│   ├── app.config.ts
│   └── app.ts
│
└── main.ts
```

---

# 🗄 Database

SQL Server

Entity Framework Core Code First

Migration Commands

```powershell
Add-Migration InitialCreate
Update-Database
```

or

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

# ▶ Running the Backend

Clone Repository

```bash
git clone https://github.com/tapan0810/DotNet_Angular_App_2.git
```

Navigate

```bash
cd DotNet_Angular_App_2
```

Restore

```bash
dotnet restore
```

Update Connection String

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Apply Migration

```bash
dotnet ef database update
```

Run

```bash
dotnet run
```

Backend runs on

```
https://localhost:xxxx
```

---

# ▶ Running Angular

Navigate

```bash
cd DotNet_Angular_App_2_Frontend/UI
```

Install Packages

```bash
npm install
```

Run

```bash
ng serve
```

Angular runs on

```
http://localhost:4200
```

---

# 📖 API Documentation

OpenAPI

```
/openapi/v1.json
```

Scalar

```
/scalar
```

---

# 🧩 Design Patterns Used

- Repository Pattern
- Dependency Injection
- SOLID Principles
- Separation of Concerns

---

# 🚀 Future Enhancements

- JWT Authentication
- Authorization
- Role Based Access
- Pagination
- Search
- Filtering
- Sorting
- Validation
- AutoMapper
- Unit Testing
- Docker
- Azure Deployment
- Logging
- Exception Middleware
- Generic Repository
- Unit of Work
- CI/CD Pipeline

---

# 📚 Concepts Covered

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- CRUD Operations
- Angular
- TypeScript
- Bootstrap
- Repository Pattern
- Dependency Injection
- REST APIs
- Async/Await
- LINQ
- HTTP Client
- OpenAPI
- Scalar Documentation

---

# 📸 Application Workflow

```
Angular UI
      │
      ▼
HTTP Client
      │
      ▼
ASP.NET Core Web API
      │
      ▼
Repository Layer
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server
```

---

# 👨‍💻 Author

**Tapan Ray**

Software Engineer | ASP.NET Core | Angular | Azure | SQL Server | REST APIs

GitHub

https://github.com/tapan0810

LinkedIn

https://www.linkedin.com/in/tapan-ray/

---
