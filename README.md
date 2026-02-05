## Library Management System (LMS) – Minimal API
A lightweight ASP.NET Core Minimal API for managing books, readers, borrowings, authentication, reports, and overdue calculations.
This project focuses only on API design — no database or models are required.
### Features
- Staff registration & login
- Dashboard summary
- Book management (CRUD)
- Reader management (CRUD)
- Borrowing management (CRUD + overdue calculation)
- Reports for books, readers, and borrowings
- Fully testable using Postman or Swagger

### Getting Started
1. Run the API
```
dotnet run
```

You’ll see something like:
```
http://localhost:5000
https://localhost:7000
```

Use either URL for testing.

## Testing With Postman
Use the tables below to test each endpoint with the correct HTTP method.
Each endpoint you created can be tested with a simple GET, POST, PUT, or DELETE request.

## API Endpoints

### Authentication

POST → http://localhost:5000/auth/register

```JSON
{
  "username": "staff1",
  "password": "pass123"
}
```

POST → http://localhost:5000/auth/login

```JSON
{
  "username": "staff1",
  "password": "pass123"
}
```

###  Dashboard




###  Books API




###  Readers API




###  Borrowings API




###  Reports API



## Project Structure (Minimal API)
```
/LMS
 ├── Program.cs
 └── README.md
```


## NOTE:
- This project is intentionally simple for learning purposes.
- You can later extend it with:
- EF Core
- JWT authentication
- Real database models
- Swagger documentation


