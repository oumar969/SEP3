package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import org.hibernate.PropertyValueException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

@RestController
@RequestMapping("/book_registry")
public class BookRegistryController
{
  @Autowired
  private BookRegistryRepository repository;

//  @ExceptionHandler(PropertyValueException.class)
//  public ResponseEntity<String> handlePropertyValueException(PropertyValueException ex) {
//    return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Invalid request data: " + ex.getMessage());
//  }
  @PostMapping("/register")
  public BookRegistry registerBook(@Valid @RequestBody BookRegistry bookRegistry) {
    return repository.save(bookRegistry);
  }
}