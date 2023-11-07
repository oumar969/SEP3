package com.via.sep3java.entity;

import java.util.UUID;


import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Column;

@Entity
public class Book {
  @Id
  private String uuid;

  @Column(nullable = false)
  private String isbn;

  @Column
  private String loanerUuid;

  // Default constructor is required by JPA specifications
  public Book() {
    this.uuid = UUID.randomUUID().toString();
  }

  // For the id field
  public String getUuid() {
    return uuid;
  }

  public void setUuid(String uuid) {
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
