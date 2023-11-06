package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

import java.util.Objects;

@Entity
public class User
{
    @Id
    public String UUID;
    @Column(nullable = false)
    public String FirstName;
    @Column(nullable = false)
    public String LastName;
    @Column(nullable = false)
    public String Password;
    @Column(nullable = false)
    public String Email;
    @Column(nullable = false)
    public String Role;

    public User(String UUID, String firstName, String lastName, String password, String email, String role) {
        this.UUID = UUID;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Role = role;
    }

    public User(String firstName, String lastName, String password, String email, String role) {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Role = role;
    }

    public User() {
    }

    public String getUUID() {
        return String.valueOf(UUID);
    }

    public void setUUID(String UUID) {
        this.UUID = UUID;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        LastName = lastName;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public String getRole() {
        return Role;
    }

    public void setRole(String role) {
        Role = role;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        User user = (User) o;
        return UUID == user.UUID && Objects.equals(FirstName, user.FirstName) && Objects.equals(LastName, user.LastName) && Objects.equals(Password, user.Password) && Objects.equals(Email, user.Email) && Objects.equals(Role, user.Role);
    }

    @Override
    public int hashCode() {
        return Objects.hash(UUID, FirstName, LastName, Password, Email, Role);
    }

    @Override
    public String toString() {
        return "User{" +
                "UUID=" + UUID +
                ", FirstName='" + FirstName + '\'' +
                ", LastName='" + LastName + '\'' +
                ", Password='" + Password + '\'' +
                ", Email='" + Email + '\'' +
                ", Role='" + Role + '\'' +
                '}';
    }
}
