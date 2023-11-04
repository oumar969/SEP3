package com.via.sep3java.entity;

import com.via.sep3java.service.ISBN;
import jakarta.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
public class BookRegistry
{
  @Id
  private String isbn;

  @Column(nullable = false)
  private String title;

  @Column(nullable = false)
  private String author;

  @Column(nullable = false)
  private String description;

  // Default constructor is required by JPA specifications
  public BookRegistry() {
    this.isbn = ISBN.Generate();
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  // For the title field
  public String getTitle() {
    return title;
  }

  public void setTitle(String title) {
    this.title = title;
  }

  // For the author field
  public String getAuthor() {
    return author;
  }

  public void setAuthor(String author) {
    this.author = author;
  }

  // For the id field
  public String getIsbn() {
    return isbn;
  }

  public void setIsbn(String isbn) {
    this.isbn = isbn;
  }

  // ...additional fields, constructors, methods as necessary...
}
