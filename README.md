# 🧰 Employee Leave Management API

A RESTful API built with ASP.NET Core 6 and EF Core for managing employee leaves.

## 🚀 Tech Stack
- ASP.NET Core 6 Web API
- Entity Framework Core
- SQLite / SQL Server
- JWT Authentication
- Swagger for API Docs

## 📌 Features
- CRUD for Employees, LeaveTypes, LeaveRequests
- JWT-secured endpoints
- Swagger UI for testing

## 🔐 Authentication
Use `/api/auth/login` to get JWT token (add manually or build login system).

## 🧪 API Endpoints

### 👤 Employees
- `GET /api/employees`
- `GET /api/employees/{id}`
- `POST /api/employees`
- `PUT /api/employees/{id}`
- `DELETE /api/employees/{id}`

### 🗂️ Leave Types
- `GET /api/leavetypes`
- `GET /api/leavetypes/{id}`
- `POST /api/leavetypes`
- `PUT /api/leavetypes/{id}`
- `DELETE /api/leavetypes/{id}`

### 📝 Leave Requests
- `GET /api/leaverequests`
- `GET /api/leaverequests/{id}`
- `POST /api/leaverequests`
- `PUT /api/leaverequests/{id}`
- `DELETE /api/leaverequests/{id}`

## 📦 Getting Started

```bash
git clone https://github.com/your-username/employee-leave-api.git
cd employee-leave-api
dotnet ef database update
dotnet run
