package FileAccessServer;

import FileAccessServer.DAOs.BookDao;
import FileAccessServer.DAOs.BookDaoImpl;

public class Server
{
  private BookDao bookDao;

  public Server()
  {
    this.bookDao = new BookDaoImpl();
  }
}
