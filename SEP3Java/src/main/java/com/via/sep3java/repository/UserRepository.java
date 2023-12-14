package com.via.sep3java.repository;

import com.via.sep3java.entity.User;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface UserRepository extends CrudRepository<User, String>
{
  User findByEmail(String email);

  User findByUuid(String uuid);

  User findByFirstName(String firstName);

  List<User> findAllByIsLibrarian(boolean isLibrarian);

}
