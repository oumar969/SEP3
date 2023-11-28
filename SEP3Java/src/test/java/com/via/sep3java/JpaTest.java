package com.via.sep3java;

import com.via.sep3java.entity.Book;
import com.via.sep3java.entity.BookRegistry;
import com.via.sep3java.entity.User;
import com.via.sep3java.repository.BookRepository;
import com.via.sep3java.repository.UserRepository;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.MethodOrderer;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestMethodOrder;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
 @SpringBootTest
    @TestMethodOrder(MethodOrderer.OrderAnnotation.class)
    public class JpaTest {
        @Autowired
        private UserRepository userRepository;
        @Autowired
        private BookRepository bookRepository;
     @Test
     void testUserRepositoryInjection() {
         Assertions.assertThat(userRepository).isNotNull();
     }

     @Test
     void testBookRepositoryInjection() {
         Assertions.assertThat(bookRepository).isNotNull();
     }

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

 }
