package com.via.sep3java.repository;

import com.via.sep3java.entity.Book;
import org.springframework.data.repository.CrudRepository;

public interface BookRepository extends CrudRepository<Book, String>
{
  Book findByIsbn(String isbn);
  Book findByUuid(String uuid);
  Iterable<Book> findAllByIsbn(String isbn);
}