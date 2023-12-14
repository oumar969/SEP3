package com.via.sep3java;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.entity.User;
import com.via.sep3java.repository.BookRegistryRepository;
import com.via.sep3java.repository.BookRepository;
import com.via.sep3java.repository.UserRepository;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.MethodOrderer;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;
import static org.junit.jupiter.api.Assertions.assertThrows;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class) @DataJpaTest public class JpaTest
{
  @Autowired private UserRepository userRepository;
  @Autowired private BookRepository bookRepository;
  @Autowired private BookRegistryRepository bookRegistryRepository;
  @Autowired private TestEntityManager entityManager;

  @Test void testUserRepositoryInjection()
  {
    Assertions.assertThat(userRepository).isNotNull();
  }

  @Test void testBookRepositoryInjection()
  {
    Assertions.assertThat(bookRegistryRepository).isNotNull();
  }

  @Test void testBookInjection()
  {
    Assertions.assertThat(bookRepository).isNotNull();
  }

  @Test void testUserEntity()
  {
    User user = new User();
    user.setUuid("1");
    user.setFirstName("John");
    user.setLastName("Doe");
    user.setPassword("password123");
    user.setEmail("john.doe@example.com");
    user.setIsLibrarian("false");

    User savedUser = userRepository.save(user);

    User retrievedUser = userRepository.findById(savedUser.getUuid())
        .orElse(null);

    Assertions.assertThat(retrievedUser).isNotNull();
    Assertions.assertThat(retrievedUser.getFirstName())
        .isEqualTo(user.getFirstName());
    Assertions.assertThat(retrievedUser.getLastName())
        .isEqualTo(user.getLastName());
    Assertions.assertThat(retrievedUser.getPassword())
        .isEqualTo(user.getPassword());
    Assertions.assertThat(retrievedUser.getEmail()).isEqualTo(user.getEmail());
    Assertions.assertThat(retrievedUser.getIsLibrarian())
        .isEqualTo(user.getIsLibrarian());
  }

  @Test void testBookEntity()
  {
    Book book = new Book();
    book.setIsbn("9788700631625");
    book.setLoanerUuid("1");

    Book savedBook = entityManager.persistAndFlush(book);

    Book retrievedBook = bookRepository.findById(savedBook.getUuid())
        .orElse(null);

    assertThat(retrievedBook).isNotNull();
    assertThat(retrievedBook.getIsbn()).isEqualTo(book.getIsbn());
    assertThat(retrievedBook.getLoanerUuid()).isEqualTo(book.getLoanerUuid());
  }

  @Test void testBookRegistryEntity()
  {
    BookRegistry bookRegistry = new BookRegistry();
    bookRegistry.setIsbn("9788700631625");
    bookRegistry.setTitle("Test Book");
    bookRegistry.setAuthor("Test Author");
    bookRegistry.setDescription("Test Description");
    bookRegistry.setGenre("Test Genre");
    bookRegistry.setReviews("Test Reviews");

    BookRegistry savedBookRegistry = bookRegistryRepository.save(bookRegistry);

    BookRegistry retrievedBookRegistry = bookRegistryRepository.findById(
        savedBookRegistry.getIsbn()).orElse(null);

    assertThat(retrievedBookRegistry).isNotNull();
    assertThat(retrievedBookRegistry.getIsbn()).isEqualTo(
        bookRegistry.getIsbn());
    assertThat(retrievedBookRegistry.getTitle()).isEqualTo(
        bookRegistry.getTitle());
    assertThat(retrievedBookRegistry.getAuthor()).isEqualTo(
        bookRegistry.getAuthor());
    assertThat(retrievedBookRegistry.getDescription()).isEqualTo(
        bookRegistry.getDescription());
    assertThat(retrievedBookRegistry.getGenre()).isEqualTo(
        bookRegistry.getGenre());
    assertThat(retrievedBookRegistry.getReviews()).isEqualTo(
        bookRegistry.getReviews());
  }

  @Test void testBookEntity1()
  {
    Book book = new Book();
    book.setIsbn("john.doe@example.com");
    book.setLoanerUuid("user12345678");

    Book savedBook = entityManager.persistAndFlush(book);

    Book retrievedBook = bookRepository.findById(savedBook.getUuid())
        .orElse(null);

    assertThat(retrievedBook).isNotNull();
    assertThat(retrievedBook.getIsbn()).isEqualTo(book.getIsbn());
    assertThat(retrievedBook.getLoanerUuid()).isEqualTo(book.getLoanerUuid());

    assertThat(retrievedBook.getIsbn()).contains("@");
    assertThat(retrievedBook.getIsbn()).contains(".com");
    assertThat(retrievedBook.getLoanerUuid().length()).isGreaterThan(8);
  }

  @Test void setEmail_ValidEmail_ShouldNotThrowException()
  {
    User user = new User();

    assertDoesNotThrow(() -> user.setEmail("test@example.com"));
    assertThat(user.getEmail()).isEqualTo("test@example.com");
  }

  @Test void setEmail_InvalidEmail_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class,
        () -> user.setEmail("invalid-email"));
    assertThat(user.getEmail()).isNull();
  }

  @Test void setPassword_ValidPassword_ShouldNotThrowException()
  {
    User user = new User();

    assertDoesNotThrow(() -> user.setPassword("validPassword123"));
    assertThat(user.getPassword()).isEqualTo("validPassword123");
  }

  @Test void setPassword_InvalidPassword_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class,
        () -> user.setPassword("short"));
    assertThat(user.getPassword()).isNull();
  }

  @Test void setFirstName_ValidFirstName_ShouldNotThrowException()
  {
    User user = new User();

    assertDoesNotThrow(() -> user.setFirstName("John"));
    assertThat(user.getFirstName()).isEqualTo("John");
  }

  @Test void setEmail_InvalidEmailFormat_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class,
        () -> user.setEmail("invalid-email-format"));
    assertThat(user.getEmail()).isNull();
  }

  @Test void setEmail_NullEmail_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class, () -> user.setEmail(null));
    assertThat(user.getEmail()).isNull();
  }

  @Test void setPassword_NullPassword_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class, () -> user.setPassword(null));
    assertThat(user.getPassword()).isNull();
  }

  @Test void setPassword_EmptyPassword_ShouldThrowException()
  {
    User user = new User();

    assertThrows(IllegalArgumentException.class, () -> user.setPassword(""));
    assertThat(user.getPassword()).isNull();
  }
}
