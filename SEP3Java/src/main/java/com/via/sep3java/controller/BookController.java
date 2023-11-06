package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/book")
public class BookController {
  @Autowired
  private BookRepository bookRepository;
  @Autowired
  private BookRegistryRepository bookRegistryRepository;

  @PostMapping("/create")
  public ResponseEntity<?> addBook(@RequestBody Book book) {
    BookRegistry existingBook = bookRegistryRepository.findByIsbn(book.getIsbn());
    if (existingBook == null) {
      return new ResponseEntity<>("Book with ISBN " + book.getIsbn() + " is not in the book registry.", HttpStatus.BAD_REQUEST);
    }
    return new ResponseEntity<>(bookRepository.save(book), HttpStatus.CREATED);
  }

  @PutMapping("/book/{uuid}")
  public ResponseEntity<?> updateBook(@PathVariable String uuid, @RequestBody Map<String, String> body) {
    Optional<Book> bookToUpdate = bookRepository.findById(uuid);
    if (!bookToUpdate.isPresent()) {
      return new ResponseEntity<>("Book with UUID " + uuid + " not found.", HttpStatus.NOT_FOUND);
    }
    String loanerUuid = body.get("loanerUuid");
    bookToUpdate.get().setLoanerUuid(loanerUuid);
    bookRepository.save(bookToUpdate.get());
    return new ResponseEntity<>("Book with UUID " + uuid + " updated successfully.", HttpStatus.OK);
  }

  @DeleteMapping("/book/{uuid}")
  public ResponseEntity<?> deleteBook(@PathVariable String uuid) {
    Book bookToDelete = bookRepository.findByUuid(uuid);
    if (bookToDelete == null) {
      return new ResponseEntity<>("Book with UUID " + uuid + " not found.", HttpStatus.NOT_FOUND);
    }
    bookRepository.delete(bookToDelete);
    return new ResponseEntity<>("Book with UUID " + uuid + " deleted successfully.", HttpStatus.OK);
  }
}