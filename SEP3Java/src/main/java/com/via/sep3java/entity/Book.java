package com.via.sep3java.entity;

import org.hibernate.annotations.GenericGenerator;

import java.util.UUID;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Column;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;

@Entity
public class Book {
// test
  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  private Integer id;

  @Column(nullable = false)
  private String title;

  @Column
  private String author;

  // Default constructor is required by JPA specifications
  public Book() {
  }

  // Getters and setters (or you can use Lombok to generate them)

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
  public Integer getId() {
    return id;
  }

  public void setId(Integer id) {
    this.id = id;
  }

  // ...additional fields, constructors, methods as necessary...
}
