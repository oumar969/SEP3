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
  private String loanerUUID;

  // Default constructor is required by JPA specifications
  public Book() {
    this.uuid = UUID.randomUUID().toString();
  }

  // For the id field
  public String getUUID() {
    return uuid;
  }

  public void setUUID(String uuid) {
    this.uuid = uuid;
  }

  public String getLoanerUUID()
  {
    return loanerUUID;
  }

  public void setLoanerUUID(String loanerUUID)
  {
    this.loanerUUID = loanerUUID;
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
