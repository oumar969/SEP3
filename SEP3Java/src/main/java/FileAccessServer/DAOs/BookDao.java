package FileAccessServer.DAOs;

import FileAccessServer.Models.Book;

import java.util.List;
import java.util.concurrent.CompletableFuture;

public interface BookDao {
  CompletableFuture<Response<Void>> CreateAsync(Book book);
  CompletableFuture<Response<Void>> UpdateAsync(Book book);
  CompletableFuture<Response<Void>> DeleteAsync(Book UUID);
  CompletableFuture<Response<List<Book>>> GetAllAsync();
  CompletableFuture<Response<Book>> GetAsync(int UUID); // By search parameters
}