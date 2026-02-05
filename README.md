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

<img width="712" height="168" alt="image" src="https://github.com/user-attachments/assets/4e862c4b-f3b2-4eb3-b28c-b02502391ad3" />


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
#### NOTE: The port may be different...confirm yours and use appropriately. In this codebase, 5000 was used as port.

#### Tips for Smooth Testing
- 1. Always choose the correct HTTP method
      Postman defaults to GET — don’t forget to switch to POST/PUT/DELETE.
- 2. Use JSON body for POST/PUT
    - Click Body
    - Select raw
    - Choose JSON from the dropdown
- 3. Watch the response
  Your minimal API returns simple JSON like:
```
{ "message": "Book added successfully" }
```

- 4. If you get HTTPS errors
    Use the HTTP URL instead:
    http://localhost:YOUR-PORT/...



###  Dashboard
<img width="701" height="117" alt="image" src="https://github.com/user-attachments/assets/b4d5c316-4a50-48bd-ba6a-b14651b00aa6" />





###  Books API
<img width="705" height="301" alt="image" src="https://github.com/user-attachments/assets/fd11a45c-c3d6-4aa4-a943-72d8e1bf8ccc" />




###  Readers API
<img width="709" height="303" alt="image" src="https://github.com/user-attachments/assets/b4509e77-d3b9-48a2-9f80-180f321a91d9" />




###  Borrowings API
<img width="706" height="343" alt="image" src="https://github.com/user-attachments/assets/81c98f3a-43ba-4ed5-883d-ac8a648de393" />

POST → http://localhost:5000/borrowings

Overdue
GET → http://localhost:5000/borrowings/1/overdue


###  Reports API
<img width="710" height="212" alt="image" src="https://github.com/user-attachments/assets/63f0afa2-9b64-484f-bcb2-e4cd9b54626f" />



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
- Documentation


