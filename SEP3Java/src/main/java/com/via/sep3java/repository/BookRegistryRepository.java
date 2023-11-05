package com.via.sep3java.repository;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import org.springframework.data.repository.CrudRepository;

public interface BookRegistryRepository extends CrudRepository<BookRegistry, String>
{
  BookRegistry findByIsbn(String isbn);
}