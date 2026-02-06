var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Fake data for demonstration purposes
var books = new List<dynamic>
{
    new { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "978-0743273565", PublicationDate = new DateTime(1925, 4, 10), Genre = "Fiction", AvailableCopies = 3 },
    new { Id = 2, Title = "To Kill a Monkey", Author = "Kemi Adetiba ", ISBN = "123-2025202525", PublicationDate = new DateTime(2025, 7, 11), Genre = "Fiction", AvailableCopies = 5 },
    new { Id = 3, Title = "1984", Author = "George Orwell", ISBN = "978-0451524935", PublicationDate = new DateTime(1949, 6, 8), Genre = "Dystopian", AvailableCopies = 2 }
    new { Id = 4, Title = "The Catcher in the Rye", Author = " F. Scott Fitzgerald", ISBN = "978-0316769488", PublicationDate = new DateTime(1951, 7, 16), Genre = "Fiction", AvailableCopies = 4 }
    new { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "978-1503290563", PublicationDate = new DateTime(1813, 1, 28), Genre = "Romance", AvailableCopies = 6 }
};

var readers = new List<dynamic>
{
    new { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890", MembershipDate = new DateTime(2020, 1, 15) },
    new { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "987-654-3210", MembershipDate = new DateTime(2021, 5, 20) },
    new { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Phone = "555-123-4567", MembershipDate = new DateTime(2019, 3, 10) },
    new { Id = 4, Name = "Bob Brown", Email = "bob.brown@example.com", Phone = "444-987-6543", MembershipDate = new DateTime(2022, 8, 5) },
    new { Id = 5, Name = "Charlie Davis", Email = "charlie.davis@example.com", Phone = "333-555-7777", MembershipDate = new DateTime(2023, 2, 25) }
};

var borrowings = new List<dynamic>
// Each borrowing record links a book to a reader with a borrow date, where some dates are in the past (-x)and some in the future (x)
{
    new { Id = 1, BookId = 1, ReaderId = 1, BorrowDate = DateTime.Now.AddDays(-10) },
    new { Id = 2, BookId = 2, ReaderId = 2, BorrowDate = DateTime.Now.AddDays(8) },
    new { Id = 3, BookId = 3, ReaderId = 3, BorrowDate = DateTime.Now.AddDays(-5) },
    new { Id = 4, BookId = 4, ReaderId = 4, BorrowDate = DateTime.Now.AddDays(-2) },
    new { Id = 5, BookId = 5, ReaderId = 5, BorrowDate = DateTime.Now.AddDays(-1) }
};



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
//Get all books
app.MapGet("/books", () =>
{
    return Results.Ok(new { message = "List of all books", books });
});

//Get a book
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(borrowing => borrowing.Id == id);
    if (book == null)
    {
        return Results.NotFound(new { message = $"Book with ID {id} not found." });
    }
    return Results.Ok(new
    {
        message = $"Details of book with ID {id}",
        data = book
    });
});

//Add a new book
app.MapPost("/books", (dynamic newBook) =>
{
    int newId = books.Max(borrowing => borrowing.Id) + 1;
    var book = new
    {
        Id = newId,
        Title = newBook.Title,
        Author = newBook.Author,
        Available = true
    };
    return Results.Ok(new
    {
        message = "New book added successfully. Details below: ",
        data = book
    });
});

//Update a book
app.MapPut("/books/{id}", (int id, dynamic updateBook, string Author) =>
{
    var book = books.FirstOrDefault(borrowing => borrowing.Id == id);
    if (book == null)

        return Results.NotFound(new { message = $"Book with ID {id} not found." });

    books.Remove(book);
    var newBook = new
    {
        Id = id,
        Title = updateBook.Title,
        Author = updateBook.Author,
        Available = updateBook.Available
    };
    books.Add(newBook);

    return Results.Ok(new
    {
        message = $"Book with ID {id} updated successfully."
    data = newBook
    });
});

//Delete a book
app.MapDelete("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(borrowing => borrowing.Id == id);
    if (book == null)
        return Results.NotFound(new { message = $"Book with ID {id} not found." });
    books.Remove(book);
    return Results.Ok(new { message = $"Book with ID {id} deleted successfully." });
});

//Readers Management

//Get all readers
app.MapGet("/readers", () =>
{
    return Results.Ok(new
    {
        message = "List of all readers",
        data = readers
    });
});

//Get a reader
app.MapGet("/readers/{id}", (int id) =>
{
    var reader = readers.FirstOrDefault(reader => reader.Id == id);
    if (reader == null)
        return Results.NotFound(new { message = $"Reader with ID {id} not found." });

    return Results.Ok(new { message = $"Details of reader with ID {id}", reader });
});

//Add a new reader
app.MapPost("/readers", (dynamic newReader) =>
{
    int newId = readers.Max(reader => reader.Id) + 1;
    var reader = new
    {
        Id = newId,
        Name = newReader.Name,
        Email = newReader.Email,
        Phone = newReader.Phone,
        MembershipDate = DateTime.Now
    };
    readers.Add(reader);
    return Results.Ok(new { message = "New reader added successfully.", reader });
});

//Update a reader
app.MapPut("/readers/{id}", (int id, dynamic updtedReader) =>
{
    var reader = readers.FirstOrDefault(reader => reader.Id == id);
    if (reader == null)
        return Results.NotFound(new { message = $"Reader with ID {id} not found." });
    readers.Remove(reader);
    var newReader = new
    {
        Id = id,
        Name = updtedReader.Name,
        Email = updtedReader.Email,
        Phone = updtedReader.Phone,
        MembershipDate = reader.MembershipDate
    };
    readers.Add(newReader);
    return Results.Ok(new { message = $"Reader with ID {id} updated successfully.", newReader });
});

//Delete a reader
app.MapDelete("/readers/{id}", (int id) =>
{
    var reader = readers.FirstOrDefault(reader => reader.Id == id);
    if (reader = null)
    {
        return Results.NotFound(new { message = $"Reader with ID {id} not found." });
    }
    return Results.Ok(new { message = $"Reader with ID {id} deleted successfully." });
});

//Borrowing Management

//Get all borrowings
app.MapGet("/borrowings", () =>
{
    return Results.Ok(new { message = "List of all borrowings", borrowings });
});

//Get a borrowing
app.MapGet("/borrowings/{id}", (int id) =>
{
    var borrowing = borrowings.FirstOrDefault(borrowing => borrowing.Id == id);
    if (borrowing == null)
        return Results.NotFound(new { message = $"Borrowing record with ID {id} not found." });
    else

        return Results.Ok(new { message = "List of all borrowings", borrowing });
});

//Add a new borrowing
app.MapPost("/borrowings", (dynamic newBorrowing) =>
{
    int newId = borrowings.Max(borrowing => borrowing.Id) + 1;
    var borrowing = new
    {
        Id = newId,
        BookId = newBorrowing.BookId,
        ReaderId = newBorrowing.ReaderId,
        BorrowDate = DateTime.Now
    };
    borrowings.Add(borrowing);
    return Results.Ok(new { message = "New borrowing record created successfully.", borrowing });
});

//Update a borrowing
app.MapPut("/borrowings/{id}", (int id, dynamic updateBorrowing) =>
{
    var borrowing = borrowings.FirstOrDefault(borrowing => borrowing.Id == id);
    if (borrowing == null)
        return Results.NotFound(new { message = $"Borrowing record with ID {id} not found." });
    borrowing.Remove(borrowing);
    var newBorrow = new
    {
        Id = id,
        BookId = updateBorrowing.BookId,
        ReaderId = updateBorrowing.ReaderId,
        BorrowDate = updateBorrowing.BorrowDate
    };
    borrowings.Add(newBorrow);
    return Results.Ok(new { message = $"Borrowing record with ID {id} updated successfully.", newBorrow });
});

//Cancel a borrowing
app.MapDelete("/borrowings/{id}", (int id) =>
{
    var borrowing = borrowings.FirstOrDefault(borrowing => borrowing.Id == id);
    if (borrowing == null)
        return Results.NotFound(new { message = $"Borrowing record with ID {id} not found." });
    borrowings.Remove(borrowing);
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
app.MapGet("/reports/overdue", () =>
{
    var today = DateTime.Now;
    // Assuming a 14-day borrowing period
    int allowedDays = 14;

    var overdueBorrowList = borrowings
    .Where(borrowing => (today - borrowing.BorrowDate).TotalDays > allowedDays)
    .Select(borrowing =>
    {
        var book = books.FirstOrDefault(x => x.Id == borrowing.BookId);
        var reader = readers.FirstOrDefault(x => x.Id == borrowing.ReaderId);
        int overdueDays = (int)(today - borrowing.BorrowDate).TotalDays - allowedDays;
        double penaltyFee = overdueDays > 0 ? overdueDays * 0.50 : 0; // Assuming $0.50 per day
        return new
        {
            BorrowingId = borrowing.Id,
            Book = book,
            Reader = reader,
            BorrowDate = borrowing.BorrowDate,
            OverdueDays = (today - borrowing.BorrowDate).TotalDays - allowedDays,
            Charge = penaltyFee
        };
    })
    .ToList();

    return Results.Ok(new { message = "List of overdue borrowings report", overdueBorrowList });
});

// This endpoint calculates the overdue fee for a specific borrowing record based on the borrow date and current date.
app.MapGet("/borrowings/{id}/overdue", (int id) =>
{
    var borrowing = borrowings.FirstOrDefault(borrowings => borrowings.Id == id);
    if (borrowing == null)
        return Results.NotFound(new { message = $"Borrowing record with ID {id} not found." });
    int overdueDays = (DateTime.Now - borrowing.BorrowDate).Days - 14; // Assuming a 14-day borrowing period
    double penaltyFee = overdueDays > 0 ? overdueDays * 0.50 : 0; // Assuming $0.50 per day
    return Results.Ok(new
    {
        message = "Overdue Fee Details: ",
        borrowing.Id,
        overdueDays,
        penaltyFee,

    });
});

app.Run();
