package FileAccessServer.DAOs;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;
import java.util.concurrent.CompletableFuture;

import FileAccessServer.DatabaseConnection;
import FileAccessServer.Models.Book;


import java.util.List;
import java.util.concurrent.CompletableFuture;

public class BookDaoImpl implements BookDao {

  private Connection connection;

  public BookDaoImpl() {
    try {
      // Load the SQLite JDBC driver
      Class.forName("org.sqlite.JDBC");
      // Establish a connection to the SQLite database
      connection = DatabaseConnection.getConnection();
    } catch (ClassNotFoundException | SQLException e) {
      e.printStackTrace();
    }
  }

  @Override
  public CompletableFuture<Response<Void>> CreateAsync(Book book) {
    // Implementation for creating a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous creation operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(new Response<Void>(true, "Book created successfully", null));
    return future;
  }

  @Override
  public CompletableFuture<Response<Void>> UpdateAsync(Book book) {
    // Implementation for updating a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous update operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(new Response<Void>(true, "Book updated successfully", null));
    return future;
  }

  @Override
  public CompletableFuture<Response<Void>> DeleteAsync(Book book) {
    // Implementation for deleting a book asynchronously
    CompletableFuture<Response<Void>> future = new CompletableFuture<>();
    // Perform the asynchronous delete operation
    // ...
    // Once the operation is complete, complete the future
    future.complete(new Response<Void>(true, "Book deleted successfully", null));
    return future;
  }

  @Override
  public CompletableFuture<Response<List<Book>>> GetAllAsync() {
    CompletableFuture<Response<List<Book>>> future = new CompletableFuture<>();
    try {
      String sql = "SELECT * FROM Book";
      PreparedStatement statement = connection.prepareStatement(sql);
      ResultSet resultSet = statement.executeQuery();
      List<Book> books =null; // Process the resultSet and create a list of Book objects
          future.complete(new Response<List<Book>>(true, "Books retrieved successfully", books));
    } catch (SQLException e) {
      future.complete(new Response<List<Book>>(false, "Error retrieving books", null));
    }
    return future;
  }


  @Override
  public CompletableFuture<Response<Book>> GetAsync(int UUID) {
    // Implementation for retrieving a book by ID asynchronously
    CompletableFuture<Response<Book>> future = new CompletableFuture<>();
    // Perform the asynchronous get by ID operation
    // ...
    // Once the operation is complete, complete the future with the retrieved book
    Book book = null;// Retrieve book by ID
        future.complete(new Response<Book>(true, "Book retrieved successfully", book));
    return future;
  }
}