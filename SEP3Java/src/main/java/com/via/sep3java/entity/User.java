package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

import java.util.Objects;

@Entity
public class User
{
    @Id
    public String uuid;
    @Column(nullable = false)
    public String firstName;
    @Column(nullable = false)
    public String lastName;
    @Column(nullable = false)
    public String password;
    @Column(nullable = false)
    public String email;
    @Column(nullable = false)
    public String role;

    public User(String uuid, String firstName, String lastName, String password, String email, String role) {
        this.uuid = uuid;
        this.firstName = firstName;
        this.lastName = lastName;
        this.password = password;
        this.email = email;
        this.role = role;
    }

    public User(String firstName, String lastName, String password, String email, String role) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.password = password;
        this.email = email;
        this.role = role;
    }

    public User() {
    }

    public String getUuid() {
        return String.valueOf(uuid);
    }

    public void setUuid(String uuid) {
        this.uuid = uuid;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        lastName = lastName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        email = email;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        role = role;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        User user = (User) o;
        return uuid == user.uuid && Objects.equals(firstName

, user.firstName

) && Objects.equals(lastName

, user.lastName

) && Objects.equals(password

, user.password

) && Objects.equals(email

, user.email

) && Objects.equals(role

, user.role

);
    }

    @Override
    public int hashCode() {
        return Objects.hash(uuid, firstName, lastName

, password

, email

, role

);
    }

    @Override
    public String toString() {
        return "User{" +
                "UUID=" + uuid +
                ", firstName ='" + firstName + '\'' +
                ", lastName ='" + lastName + '\'' + ", password ='" + password + '\'' +
                ", email ='" + email + '\'' +
                ", role ='" + role + '\'' +
                '}';
    }
}
