package com.via.sep3java.repository;

import com.via.sep3java.entity.User;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface UserRepository extends CrudRepository<User, String>
{
  User findByEmail(String email);

  User findByUuid(String uuid);

  User findByFirstName(String firstName);
  List<User> findAllByEmail(String email);
  //Transactional er en annotation som gør at vi kan lave transaktioner på vores database
  //    @Transactional
  //    void deleteByEmail(String email);

}
