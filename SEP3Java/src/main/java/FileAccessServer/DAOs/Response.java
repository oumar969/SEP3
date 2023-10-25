package FileAccessServer.DAOs;

public class Response<T> {
  private final boolean success;
  private final String errorMessage;
  private final T data;

  public Response(boolean success, String errorMessage, T data) {
    this.success = success;
    this.errorMessage = errorMessage;
    this.data = data;
  }

  public boolean isSuccess() {
    return success;
  }

  public String getErrorMessage() {
    return errorMessage;
  }

  public T getData() {
    return data;
  }
}