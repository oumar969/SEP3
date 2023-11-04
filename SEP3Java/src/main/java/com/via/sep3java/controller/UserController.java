package main.java.com.via.sep3java.controller;

import main.java.com.via.sep3java.entity.User;
import main.java.com.via.sep3java.repository.UserRepository;

@RestController
@CrossOrigin
@RequestMapping(value = "/user")
public class UserController {

    private UserRepository userRepository;

    public UserController(UserRepository userRepository) {
        this.userRepository = userRepository;
    }


    @PostMapping("/user")
    public User addUser(@RequestBody User user) {
        return repository.save(user);
    }
}
