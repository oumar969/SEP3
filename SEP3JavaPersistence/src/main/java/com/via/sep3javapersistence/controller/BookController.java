package com.via.sep3javapersistence.controller;

import com.via.sep3javapersistence.domain.Book;
import com.via.sep3javapersistence.domain.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class BookController {
  @Autowired
  private BookRepository repository;

  @PostMapping("/book")
  public Book addEntity(@RequestBody Book entity) {
    return repository.save(entity);
  }

  // other CRUD operations
}