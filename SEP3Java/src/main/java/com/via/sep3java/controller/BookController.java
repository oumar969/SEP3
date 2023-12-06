package com.via.sep3java.controller;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@RequestMapping("/book")
public class BookController {
    @Autowired
    private BookRepository bookRepository;
    @Autowired
    private BookRegistryRepository bookRegistryRepository;

    @PostMapping("/create")
    public ResponseEntity<?> createBook(@RequestBody Book book) {
        BookRegistry existingBook = bookRegistryRepository.findByIsbn(book.getIsbn());
        if (existingBook == null) {
            return new ResponseEntity<>("Book with ISBN " + book.getIsbn() + " is not in the book registry.", HttpStatus.BAD_REQUEST);
        }
        return new ResponseEntity<>(bookRepository.save(book), HttpStatus.CREATED);
    }

    @PutMapping("/update/{uuid}")
    public ResponseEntity<?> updateBook(@PathVariable String uuid, @RequestBody Map<String, String> body) {
        Book book = bookRepository.findByUuid(uuid);
        if (book == null) {
            return new ResponseEntity<>("Book with UUID " + uuid + " not found.", HttpStatus.NOT_FOUND);
        }
        String loanerUuid = body.get("loanerUuid");
        if (loanerUuid != null && !loanerUuid.isEmpty()) {
            book.setLoanerUuid(loanerUuid);
        }
        bookRepository.save(book);
        return new ResponseEntity<>("Book with uuid " + uuid + " updated successfully.", HttpStatus.OK);
    }

    @DeleteMapping("/deleteByUuid/{uuid}")
    public ResponseEntity<?> deleteByUuid(@PathVariable String uuid) {
        Book book = bookRepository.findByUuid(uuid);
        if (book == null) {
            return new ResponseEntity<>("Book with Uuid " + uuid + " not found.", HttpStatus.NOT_FOUND);
        }
        bookRepository.delete(book);
        return new ResponseEntity<>("Book with UUID " + uuid + " deleted successfully.", HttpStatus.OK);
    }

    @DeleteMapping("/deleteByIsbn/{isbn}")
    public ResponseEntity<?> deleteByIsbn(@PathVariable String isbn) {
        Book book = bookRepository.findByIsbn(isbn);
        if (book == null) {
            return new ResponseEntity<>("Book with isbn " + isbn + " not found.", HttpStatus.NOT_FOUND);
        }
        bookRepository.delete(book);
        return new ResponseEntity<>("Book with isbn " + isbn + " deleted successfully.", HttpStatus.OK);
    }


}