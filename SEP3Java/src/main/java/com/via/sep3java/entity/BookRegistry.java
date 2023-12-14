package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

@Entity public class BookRegistry
{
  @Id private String isbn;

  @Column(nullable = false) private String title;

  @Column private String author;

  @Column private String description;

  @Column private String genre;

  @Column private String reviews;

  public String getGenre()
  {
    return genre;
  }

  public void setGenre(String genre)
  {
    this.genre = genre;
  }

  public String getReviews()
  {
    return reviews;
  }

  public void setReviews(String reviews)
  {
    this.reviews = reviews;
  }

  public BookRegistry()
  {
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public String getTitle()
  {
    return title;
  }

  public void setTitle(String title)
  {
    this.title = title;
  }

  public String getAuthor()
  {
    return author;
  }

  public void setAuthor(String author)
  {
    this.author = author;
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
