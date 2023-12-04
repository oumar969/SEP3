package com.via.sep3java.controller;

import com.via.sep3java.entity.User;
import com.via.sep3java.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/user")
public class UserController {

    @Autowired
    private UserRepository userRepository;

    @PostMapping("/create")
    public ResponseEntity<?> addUser(
            @RequestBody User user) {
        User existingUser = userRepository.findByUuid(user.getUuid());
        if (existingUser != null) {
            return new ResponseEntity<>(
                    "User with UUID " + user.getUuid() + " already exists.",
                    HttpStatus.BAD_REQUEST);
        }
        System.out.println("user json");
        System.out.println(user.toString());

        User savedUser = userRepository.save(user);
        return new ResponseEntity<>(savedUser, HttpStatus.CREATED);
    }

    @GetMapping("/get/all")
    public Iterable<User> getAllUsers() {
        return userRepository.findAll();
    }

    @GetMapping("/get/{uuid}")
    public ResponseEntity<?> getUser(
            @PathVariable String uuid) {
        User existingUser = userRepository.findByUuid(uuid);
        if (existingUser == null) {
            return new ResponseEntity<>("User with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(existingUser, HttpStatus.OK);
    }

    @GetMapping("/get/byEmail/{email}")
    public ResponseEntity<?> getUserByEmail(
            @PathVariable String email) {
        User existingUser = userRepository.findByEmail(email);
        if (existingUser == null) {
            return new ResponseEntity<>("User with Email " + email + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(existingUser, HttpStatus.OK);
    }

    @PutMapping("/edit/{uuid}")
    public ResponseEntity<?> editUser(
            @PathVariable String uuid, @RequestBody User user) {
        User existingUser = userRepository.findByUuid(uuid);
        if (existingUser == null) {
            return new ResponseEntity<>("User with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        existingUser.setFirstName(user.getFirstName());
        existingUser.setLastName(user.getLastName());
        existingUser.setEmail(user.getEmail());
        existingUser.setPassword(user.getPassword());
        existingUser.setIsLibrarian(user.getIsLibrarian());
        //existingUser.setUuid(user.getUuid());
        userRepository.save(existingUser);
        return new ResponseEntity<>(existingUser, HttpStatus.OK);
    }

    @PutMapping("/edit/{email}")
    public ResponseEntity<?> editUserByEmail(
            @PathVariable String email, @RequestBody User user) {
        User existingUser = userRepository.findByEmail(email);
        if (existingUser == null) {
            return new ResponseEntity<>("User with Email " + email + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        existingUser.setFirstName(user.getFirstName());
        existingUser.setLastName(user.getLastName());
        existingUser.setEmail(user.getEmail());
        existingUser.setPassword(user.getPassword());
        existingUser.setIsLibrarian(user.getIsLibrarian());
        //existingUser.setUuid(user.getUuid());
        userRepository.save(existingUser);
        return new ResponseEntity<>(existingUser, HttpStatus.OK);
    }

    @DeleteMapping("/delete/{uuid}")
    public ResponseEntity<?> deleteUser(
            @PathVariable String uuid) {
        User existingUser = userRepository.findByUuid(uuid);
        if (existingUser == null) {
            return new ResponseEntity<>("User with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        userRepository.delete(existingUser);
        return new ResponseEntity<>(
                "User with UUID " + uuid + " deleted successfully.", HttpStatus.OK);
    }

}
