var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Authentication configuration

//Register Staff
app.MapPost("/auth/register", () =>
{
    return Results.Ok(new { message = "Staff registered successfully." });
});

//Login Staff
app.MapPost("/auth/login", () =>
{
    return Results.Ok(new { message = "Staff logged in successfully.", token = "fake-jwt-token" });
});

//Dashboard

app.MapGet("/dashboard", () =>
{
    return Results.Ok(new 
    { 
        totalBooks = 120,
        totalReaders = 45,
        activeBorrowings = 18
    });
});

//Books Management
app.MapGet("/books", () =>
{
    return Results.Ok(new { message = "List os all books" });
});

//Get a book
app.MapGet("/books/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Details of book with ID {id}" });
});

//Add a new book
app.MapPost("/books", () =>
{
    return Results.Ok(new { message = "New book added successfully." });
});

//Update a book
app.MapPut("/books/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Book with ID {id} updated successfully." });
});

//Delete a book
app.MapDelete("/books/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Book with ID {id} deleted successfully." });
});

//Readers Management

//Get all readers
app.MapGet("/readers", () =>
{     return Results.Ok(new { message = "List of all readers" });
});

//Get a reader
app.MapGet("/readers/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Details of reader with ID {id}" });
});

//Add a new reader
app.MapPost("/readers", () =>
{
    return Results.Ok(new { message = "New reader added successfully." });
});

//Update a reader
app.MapPut("/readers/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Reader with ID {id} updated successfully." });
});

//Delete a reader
app.MapDelete("/readers/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Reader with ID {id} deleted successfully." });
});

//Borrowing Management

//Get all borrowings
app.MapGet("/borrowings", () =>
{
    return Results.Ok(new { message = "List of all borrowings" });
});
//Get a borrowing
app.MapGet("/borrowings/{id}", (int id) =>
{
    return Results.Ok(new { message = "List of all borrowings" });
});

//Add a new borrowing
app.MapPost("/borrowings", () =>
{
    return Results.Ok(new { message = "New borrowing record created successfully." });
});

//Update a borrowing
app.MapPut("/borrowings/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Borrowing record with ID {id} updated successfully." });
});

//Cancel a borrowing
app.MapDelete("/borrowings/{id}", (int id) =>
{
    return Results.Ok(new { message = $"Borrowing record with ID {id} cancelled successfully." });
});


//Reporting

app.MapGet("/reports/borrowings", () =>
{
    return Results.Ok(new { message = "List of all borrowings report" });
});

app.MapGet("/reports/books", () =>
{
    return Results.Ok(new { message = "List of all books report" });
});

app.MapGet("/reports/readers", () =>
{
    return Results.Ok(new { message = "List of all readers report" });
});

//Overdue Books Report

app.MapGet("/borrowings/{id}/overdue", (int id) =>
{
    return Results.Ok(new 
    { 
        borrowingId = id,
        overdueDays = 5,
        penaltyFee = 5 * 0.50, // Assuming $0.50 per day
        message = "List of overdue books" 
    });
});

app.Run();
