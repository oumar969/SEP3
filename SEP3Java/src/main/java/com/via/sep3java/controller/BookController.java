package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController @RequestMapping("/book") public class BookController
{
  @Autowired private BookRepository bookRepository;
  @Autowired private BookRegistryRepository bookRegistryRepository;

  @PostMapping("/create") public ResponseEntity<?> createBook(
      @RequestBody Book book)
  {
    BookRegistry existingBook = bookRegistryRepository.findByIsbn(
        book.getIsbn());
    if (existingBook == null)
    {
      return new ResponseEntity<>(
          "Book with ISBN " + book.getIsbn() + " is not in the book registry.",
          HttpStatus.BAD_REQUEST);
    }
    return new ResponseEntity<>(bookRepository.save(book), HttpStatus.CREATED);
  }

  @GetMapping("/get/all/{isbn}") public Iterable<Book> getAllBooksByIsbn(
      @PathVariable String isbn)
  {
    return bookRepository.findAllByIsbn(isbn);
  }

  @GetMapping("/get/all") public Iterable<Book> getAllBooks()
  {
    return bookRepository.findAll();
  }

  @GetMapping("/get/loaner/{loanerUuid}") public Iterable<Book> getLoanerBooks(
      @PathVariable String loanerUuid)
  {
    return bookRepository.findAllByLoanerUuid(loanerUuid);
  }

  @PutMapping("/update/{uuid}") public ResponseEntity<?> updateBook(
      @PathVariable String uuid, @RequestBody Map<String, String> body)
  {
    Book book = bookRepository.findByUuid(uuid);
    if (book == null)
    {
      return new ResponseEntity<>("Book with UUID " + uuid + " not found.",
          HttpStatus.NOT_FOUND);
    }
    String loanerUuid = body.get("loanerUuid");
    if ("return".equals(loanerUuid))
    {
      book.setLoanerUuid("");
    }
    else if (loanerUuid != null && !loanerUuid.isEmpty()
        && loanerUuid != "return")
    {
      book.setLoanerUuid(loanerUuid);
    }

    bookRepository.save(book);
    return new ResponseEntity<>(
        "Book with uuid " + uuid + " updated successfully.", HttpStatus.OK);
  }

  @DeleteMapping("/delete/by-uuid/{uuid}") public ResponseEntity<?> deleteByUuid(
      @PathVariable String uuid)
  {
    Book book = bookRepository.findByUuid(uuid);
    if (book == null)
    {
      return new ResponseEntity<>("Book with UUID " + uuid + " not found.",
          HttpStatus.NOT_FOUND);
    }
    bookRepository.delete(book);
    return new ResponseEntity<>(
        "Book with UUID " + uuid + " deleted successfully.", HttpStatus.OK);
  }

  @DeleteMapping("/delete/by-isbn/{isbn}") public ResponseEntity<?> deleteByIsbn(
      @PathVariable String isbn)
  {
    List<Book> books = bookRepository.findAllByIsbn(isbn);
    if (books.isEmpty())
    {
      return new ResponseEntity<>("No books with ISBN " + isbn + " not found.",
          HttpStatus.NOT_FOUND);
    }
    for (Book book : books)
    {
      bookRepository.delete(book);
    }
    return new ResponseEntity<>(
        "Books with ISBN " + isbn + " deleted successfully.", HttpStatus.OK);
  }

}