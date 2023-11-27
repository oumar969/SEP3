package com.via.sep3java.repository;

import com.via.sep3java.entity.User;
import jakarta.transaction.Transactional;
import org.springframework.data.repository.CrudRepository;


public interface UserRepository extends CrudRepository<User, String>
{
//    User findByEmail(String email);
    User findByUuid(String uuid);
//Transactional er en annotation som gør at vi kan lave transaktioner på vores database
//    @Transactional
//    void deleteByEmail(String email);

}
