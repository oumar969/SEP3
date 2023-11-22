package com.via.sep3java.controller;

import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.service.ISBNServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;

@RestController @RequestMapping("/book-registry") public class BookRegistryController
{
  @Autowired private BookRegistryRepository bookRegistryRepository;

  @PostMapping("/create") public BookRegistry registerBook(
      @Valid @RequestBody BookRegistry bookRegistry)
  {
    if (bookRegistry.getIsbn() == null || bookRegistry.getIsbn().isEmpty())
    {
      bookRegistry.setIsbn(ISBNServices.Generate());
    }

    return bookRegistryRepository.save(bookRegistry);
  }
}