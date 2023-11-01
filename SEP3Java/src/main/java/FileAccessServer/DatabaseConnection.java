package FileAccessServer;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection
{
  private static final String DATABASE_URL = "jdbc:sqlite:/FileAccessServer/DataBase.db";

  public Connection getConnection() throws SQLException
  {
    Connection conn = DriverManager.getConnection(DATABASE_URL);
    conn.setSchema("main");
    return conn;
  }
}