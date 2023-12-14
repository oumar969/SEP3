package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

@Entity public class Book
{
  @Id @Column(nullable = false) private String uuid;

  @Column(nullable = false) private String isbn;

  @Column(nullable = false) private String loanerUuid;

  public Book()
  {
  }

  public String getUuid()
  {
    return uuid;
  }

  public void setUuid(String uuid)
  {
    this.uuid = uuid;
  }

  public String getLoanerUuid()
  {
    return loanerUuid;
  }

  public void setLoanerUuid(String loanerUuid)
  {
    this.loanerUuid = loanerUuid;
  }

  public String getIsbn()
  {
    return isbn;
  }

  public void setIsbn(String isbn)
  {
    this.isbn = isbn;
  }
}
