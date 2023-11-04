package main.java.com.via.sep3java.repository;

import main.java.com.via.sep3java.entity.User;

import java.io.IOException;

public interface UserRepository {
    User GetUser(String username)
            throws IOException, ClassNotFoundException;

    void AddUser(User user)
            throws IOException, ClassNotFoundException;
    User editUser(User user);
    void deleteUser(int id);

}
