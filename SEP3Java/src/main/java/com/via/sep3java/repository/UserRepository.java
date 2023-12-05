package com.via.sep3java.repository;

import com.via.sep3java.entity.User;
import org.springframework.data.repository.CrudRepository;


public interface UserRepository extends CrudRepository<User, String> {
    User findByEmail(String email);

    User findByUuid(String uuid);

    User findByFirstName(String firstName);
//Transactional er en annotation som gør at vi kan lave transaktioner på vores database
//    @Transactional
//    void deleteByEmail(String email);

}
