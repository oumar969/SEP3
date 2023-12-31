package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import com.via.sep3java.service.ISBNServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController @RequestMapping("/book-registry") public class BookRegistryController
{
  @Autowired private BookRegistryRepository bookRegistryRepository;
  @Autowired private BookRepository bookRepository;

  @PostMapping("/create") public BookRegistry registerBook(
      @Valid @RequestBody BookRegistry bookRegistry)
  {
    if (bookRegistry.getIsbn() == null || bookRegistry.getIsbn().isEmpty())
    {
      bookRegistry.setIsbn(ISBNServices.Generate());
    }

    return bookRegistryRepository.save(bookRegistry);
  }

  @GetMapping("/get/all") public Iterable<BookRegistry> getAllBookRegistries()
  {
    return bookRegistryRepository.findAll();
  }

  @GetMapping("/getByIsbn/{isbn}") public ResponseEntity<?> getBookRegistry(
      @PathVariable String isbn)
  {
    BookRegistry existingBookRegistry = bookRegistryRepository.findByIsbn(isbn);
    if (existingBookRegistry == null)
    {
      return new ResponseEntity<>("Book with ISBN " + isbn + " not found.",
          HttpStatus.NOT_FOUND);
    }
    return new ResponseEntity<>(existingBookRegistry, HttpStatus.OK);
  }

  @PutMapping("/update/{isbn}") public ResponseEntity<?> updateBookRegistry(
      @PathVariable String isbn, @RequestBody BookRegistry bookRegistry)
  {
    BookRegistry existingBookRegistry = bookRegistryRepository.findByIsbn(isbn);
    if (existingBookRegistry == null)
    {
      return new ResponseEntity<>("Book with ISBN " + isbn + " not found.",
          HttpStatus.NOT_FOUND);
    }
    existingBookRegistry.setAuthor(bookRegistry.getAuthor());
    existingBookRegistry.setTitle(bookRegistry.getTitle());
    existingBookRegistry.setGenre(bookRegistry.getGenre());
    existingBookRegistry.setIsbn(bookRegistry.getIsbn());
    existingBookRegistry.setReviews(bookRegistry.getReviews());
    existingBookRegistry.setDescription(bookRegistry.getDescription());
    bookRegistryRepository.save(existingBookRegistry);
    return new ResponseEntity<>(
        "Book with ISBN " + isbn + " updated successfully.", HttpStatus.OK);
  }

  @DeleteMapping("/delete/{isbn}") public ResponseEntity<?> deleteBookRegistry(
      @PathVariable String isbn)
  {
    BookRegistry bookRegistry = bookRegistryRepository.findByIsbn(isbn);
    if (bookRegistry == null)
    {
      return new ResponseEntity<>("Book with ISBN " + isbn + " not found.",
          HttpStatus.NOT_FOUND);
    }
    bookRegistryRepository.delete(bookRegistry);

    List<Book> books = bookRepository.findAllByIsbn(isbn);
    for (Book book : books)
    {
      if (book.getIsbn().equals(isbn))
      {
        bookRepository.delete(book);
      }
    }
    return new ResponseEntity<>(
        "Book with ISBN " + isbn + " deleted successfully.", HttpStatus.OK);
  }
}