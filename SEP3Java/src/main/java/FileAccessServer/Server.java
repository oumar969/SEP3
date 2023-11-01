package FileAccessServer;

import FileAccessServer.DAOs.BookDao;
import FileAccessServer.DAOs.BookDaoImpl;
import FileAccessServer.DAOs.Response;
import FileAccessServer.Models.Book;

import java.util.List;
import java.util.concurrent.CompletableFuture;

public class Server
{
  private BookDao bookDao;

  public Server()
  {
    this.bookDao = new BookDaoImpl();
    CompletableFuture<Response<List<Book>>> booksTest = bookDao.GetAllAsync();
    booksTest.thenAccept(response -> {
      if (response.isSuccess())
      {
        System.out.println("Books retrieved successfully");
        for (Book book : response.getData())
        {
          System.out.println(book.getTitle());
        }
      }
      else
      {
        System.out.println("Error retrieving books");
      }
    });
  }
}
