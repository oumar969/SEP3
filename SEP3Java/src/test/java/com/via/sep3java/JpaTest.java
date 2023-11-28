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
import org.springframework.boot.test.context.SpringBootTest;
import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;
import static org.junit.jupiter.api.Assertions.assertThrows;


@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
 @DataJpaTest
 public class JpaTest {
        @Autowired
        private UserRepository userRepository;
        @Autowired
        private BookRepository bookRepository;
        @Autowired
        private BookRegistryRepository bookRegistryRepository;
        @Autowired
        private TestEntityManager entityManager;
     @Test
     void testUserRepositoryInjection() {
         Assertions.assertThat(userRepository).isNotNull();
     }
    //testUserRepositoryInjection er en test der tester om userRepository er null eller ej
     @Test
     void testBookRepositoryInjection() {
         Assertions.assertThat(bookRegistryRepository).isNotNull();
     }

     @Test
     void testBookInjection() {
            Assertions.assertThat(bookRepository).isNotNull();
        }
    //testUserEntity testes om grundlæggende funktionalitet relateret til oprettelse, gemning og hentning af brugerobjekter fungerer korrekt.
        @Test
     void testUserEntity() {
         // Opret en bruger til test
         User user = new User();
         user.setUuid("1");
         user.setFirstName("John");
         user.setLastName("Doe");
         user.setPassword("password123");
         user.setEmail("john.doe@example.com");
         user.setIsLibrarian("false");

         // Gem brugeren i databasen
         User savedUser = userRepository.save(user);

         // Hent brugeren fra databasen
         User retrievedUser = userRepository.findById(savedUser.getUuid()).orElse(null);

         // Verificer, at brugeren er blevet gemt og hentet korrekt
         Assertions.assertThat(retrievedUser).isNotNull();
         Assertions.assertThat(retrievedUser.getFirstName()).isEqualTo(user.getFirstName());
         Assertions.assertThat(retrievedUser.getLastName()).isEqualTo(user.getLastName());
         Assertions.assertThat(retrievedUser.getPassword()).isEqualTo(user.getPassword());
         Assertions.assertThat(retrievedUser.getEmail()).isEqualTo(user.getEmail());
         Assertions.assertThat(retrievedUser.getIsLibrarian()).isEqualTo(user.getIsLibrarian());
     }

     @Test
     void testBookEntity() {
         // Create a book for the test
         Book book = new Book();
         book.setIsbn("9788700631625"); // Set the ISBN correctly
         book.setLoanerUuid("1");

         // Save the book to the database
         Book savedBook = entityManager.persistAndFlush(book);

         // Retrieve the book from the database
         Book retrievedBook = bookRepository.findById(savedBook.getUuid()).orElse(null);

         // Verify that the book has been saved and retrieved correctly
         assertThat(retrievedBook).isNotNull();
         assertThat(retrievedBook.getIsbn()).isEqualTo(book.getIsbn());
         assertThat(retrievedBook.getLoanerUuid()).isEqualTo(book.getLoanerUuid());
     }
             @Test
        void testBookRegistryEntity() {
            // Create a book registry for the test
            BookRegistry bookRegistry = new BookRegistry();
            bookRegistry.setIsbn("9788700631625");
            bookRegistry.setTitle("Test Book");
            bookRegistry.setAuthor("Test Author");
            bookRegistry.setDescription("Test Description");
            bookRegistry.setGenre("Test Genre");
            bookRegistry.setReviews("Test Reviews");

            // Save the book registry to the database
            BookRegistry savedBookRegistry = bookRegistryRepository.save(bookRegistry);

            // Retrieve the book registry from the database
            BookRegistry retrievedBookRegistry = bookRegistryRepository.findById(savedBookRegistry.getIsbn()).orElse(null);

            // Verify that the book registry has been saved and retrieved correctly
            assertThat(retrievedBookRegistry).isNotNull();
            assertThat(retrievedBookRegistry.getIsbn()).isEqualTo(bookRegistry.getIsbn());
            assertThat(retrievedBookRegistry.getTitle()).isEqualTo(bookRegistry.getTitle());
            assertThat(retrievedBookRegistry.getAuthor()).isEqualTo(bookRegistry.getAuthor());
            assertThat(retrievedBookRegistry.getDescription()).isEqualTo(bookRegistry.getDescription());
            assertThat(retrievedBookRegistry.getGenre()).isEqualTo(bookRegistry.getGenre());
            assertThat(retrievedBookRegistry.getReviews()).isEqualTo(bookRegistry.getReviews());
        }
        @Test
        void testBookEntity1() {
            // Create a book for the test
            Book book = new Book();
            book.setIsbn("john.doe@example.com"); // Set a sample ISBN with '@' and '.com'
            book.setLoanerUuid("user12345678"); // Set a sample UUID longer than 8 characters

            // Save the book to the database
            Book savedBook = entityManager.persistAndFlush(book);

            // Retrieve the book from the database
            Book retrievedBook = bookRepository.findById(savedBook.getUuid()).orElse(null);

            // Verify that the book has been saved and retrieved correctly
            assertThat(retrievedBook).isNotNull();
            assertThat(retrievedBook.getIsbn()).isEqualTo(book.getIsbn());
            assertThat(retrievedBook.getLoanerUuid()).isEqualTo(book.getLoanerUuid());

            // Additional validation for ISBN and loanerUuid
            assertThat(retrievedBook.getIsbn()).contains("@"); // Check if ISBN contains '@'
            assertThat(retrievedBook.getIsbn()).contains(".com"); // Check if ISBN contains '.com'
            assertThat(retrievedBook.getLoanerUuid().length()).isGreaterThan(8); // Check if UUID is longer than 8 characters
        }


        // JUnit-test
        @Test
        void setEmail_ValidEmail_ShouldNotThrowException() {
            // Arrange
            User user = new User();

            // Act & Assert
            assertDoesNotThrow(() -> user.setEmail("test@example.com"));
            assertThat(user.getEmail()).isEqualTo("test@example.com");
        }
    // hvis vi sætter setEmail og setPassword som er ikke valid, så skal den kaste en exception
        @Test
        void setEmail_InvalidEmail_ShouldThrowException() {
            // Arrange
            User user = new User();

            // Act & Assert
            assertThrows(IllegalArgumentException.class, () -> user.setEmail("invalid-email"));
            assertThat(user.getEmail()).isNull(); // Make sure email is not set if it's invalid
        }

        @Test
        void setPassword_ValidPassword_ShouldNotThrowException() {
            // Arrange
            User user = new User();

            // Act & Assert
            assertDoesNotThrow(() -> user.setPassword("validPassword123"));
            assertThat(user.getPassword()).isEqualTo("validPassword123");
        }

    @Test
    void setPassword_InvalidPassword_ShouldThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertThrows(IllegalArgumentException.class, () -> user.setPassword("short"));
        assertThat(user.getPassword()).isNull(); // Make sure password is not set if it's invalid
    }

    @Test
    void setFirstName_ValidFirstName_ShouldNotThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertDoesNotThrow(() -> user.setFirstName("John"));
        assertThat(user.getFirstName()).isEqualTo("John");
    }
    // Make sure that they are in an invalid format.
    // Make sure that they are in an invalid format.
    // Make sure that they are in an invalid format.
    @Test
    void setEmail_InvalidEmailFormat_ShouldThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertThrows(IllegalArgumentException.class, () -> user.setEmail("invalid-email-format"));
        assertThat(user.getEmail()).isNull(); // Make sure email is not set if it's in an invalid format
    }

    @Test
    void setEmail_NullEmail_ShouldThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertThrows(IllegalArgumentException.class, () -> user.setEmail(null));
        assertThat(user.getEmail()).isNull(); // Make sure email is not set if it's null
    }

    @Test
    void setPassword_NullPassword_ShouldThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertThrows(IllegalArgumentException.class, () -> user.setPassword(null));
        assertThat(user.getPassword()).isNull(); // Make sure password is not set if it's null
    }

    @Test
    void setPassword_EmptyPassword_ShouldThrowException() {
        // Arrange
        User user = new User();

        // Act & Assert
        assertThrows(IllegalArgumentException.class, () -> user.setPassword(""));
        assertThat(user.getPassword()).isNull(); // Make sure password is not set if it's empty
    }
    }
