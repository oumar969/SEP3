package com.via.sep3java.service;

import com.via.sep3java.entity.User;
import com.via.sep3java.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.List;

@Component public class GenerateLibrarian
{

  @Autowired private UserRepository userRepository;

  @PostConstruct public void checkAndCreateLibrarian()
  {
    List<User> librarian = userRepository.findAllByIsLibrarian(true);
    if (librarian.isEmpty())
    {
      User newLibrarian = new User();
      newLibrarian.setUuid("librarian-admin");
      newLibrarian.setEmail("librarian@admin.net");
      newLibrarian.setPassword("12345678"); // Use proper password encryption
      newLibrarian.setFirstName("Librarian");
      newLibrarian.setLastName("Admin");
      newLibrarian.setIsLibrarian(true);
      userRepository.save(newLibrarian);
    }
  }
}
