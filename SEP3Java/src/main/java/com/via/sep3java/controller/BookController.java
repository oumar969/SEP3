package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/books")
public class BookController {
  @Autowired
  private BookRepository repository;

  @PostMapping("/book")
  public Book addEntity(@RequestBody Book entity) {
    return repository.save(entity);
  }


  // other CRUD operations
}