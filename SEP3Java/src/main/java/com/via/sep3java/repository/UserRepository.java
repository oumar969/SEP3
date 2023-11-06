package com.via.sep3java.repository;

import com.via.sep3java.entity.User;
import org.springframework.data.repository.CrudRepository;


public interface UserRepository extends CrudRepository<User, String>
{
    User findByUUID(String uuid);



}
