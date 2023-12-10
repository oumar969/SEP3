package com.via.sep3java.repository;

import com.via.sep3java.entity.Book;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface BookRepository extends CrudRepository<Book, String> {
    Book findByIsbn(String isbn);

    Book findByUuid(String uuid);

    List<Book> findAllByIsbn(String isbn);

    List<Book> findAllByLoanerUuid(String loanerUuid);
}