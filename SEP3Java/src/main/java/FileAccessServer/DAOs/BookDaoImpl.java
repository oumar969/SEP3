package FileAccessServer.DAOs;

import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.concurrent.CompletableFuture;

import FileAccessServer.DatabaseConnection;
import FileAccessServer.Models.Book;

import java.util.List;
import java.util.concurrent.CompletableFuture;

public class BookDaoImpl implements BookDao
{

  private Connection connection;

  public BookDaoImpl()
  {
    try
    {
      // Load the SQLite JDBC driver
      Class.forName("org.sqlite.JDBC");
      // Establish a connection to the SQLite database
      connection = DatabaseConnection.getConnection();
      System.out.println(connection);
    }
    catch (ClassNotFoundException | SQLException e)
    {
      e.printStackTrace();
    }
  }

  @Override public CompletableFuture<Response<Void>> CreateAsync(Book book)
  {
    // Implementation for creating a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous creation operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(
        new Response<Void>(true, "Book created successfully", null));
    return future;
  }

  @Override public CompletableFuture<Response<Void>> UpdateAsync(Book book)
  {
    // Implementation for updating a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous update operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(
        new Response<Void>(true, "Book updated successfully", null));
    return future;
  }

  @Override public CompletableFuture<Response<Void>> DeleteAsync(Book book)
  {
    // Implementation for deleting a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous delete operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(
        new Response<Void>(true, "Book deleted successfully", null));
    return future;
  }

  @Override public CompletableFuture<Response<List<Book>>> GetAllAsync()
  {
    CompletableFuture<Response<List<Book>>> future = new CompletableFuture<>();
    try
    {
      Statement stmt = connection.createStatement();
      ResultSet resultSet = stmt.executeQuery("SELECT * FROM \"main\".Books");
      List<Book> books = new ArrayList<>();
      while (resultSet.next())
      {
        books.add(
            new Book(resultSet.getString("uuid"), resultSet.getString("title"),
                resultSet.getString("author"), resultSet.getString("genre"),
                resultSet.getString("isbn"), resultSet.getString("language"),
                resultSet.getString("description")));
      }
      future.complete(
          new Response<List<Book>>(true, "Books retrieved successfully",
              books));
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      future.complete(
          new Response<List<Book>>(false, "Error retrieving books", null));
    }
    return future;
  }

  @Override public CompletableFuture<Response<Book>> GetAsync(int UUID)
  {
    // Implementation for retrieving a book by ID asynchronously
    CompletableFuture<Response<Book>> future = new CompletableFuture<>();
    // Perform the asynchronous get by ID operation
    // ...
    // Once the operation is complete, complete the future with the retrieved book
    Book book = null;// Retrieve book by ID
    future.complete(
        new Response<Book>(true, "Book retrieved successfully", book));
    return future;
  }
}