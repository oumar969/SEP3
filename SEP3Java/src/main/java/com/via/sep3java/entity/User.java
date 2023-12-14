package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

import java.util.Objects;

@Entity public class User
{
  @Id @Column(nullable = false) public String uuid;
  @Column(nullable = false) public String firstName;
  @Column(nullable = false) public String lastName;
  @Column(nullable = false) public String password;
  @Column(nullable = false) public String email;
  @Column(nullable = false) public boolean isLibrarian;

  public User(String uuid, String firstName, String lastName, String password,
      String email, boolean isLibrarian)
  {
    this.uuid = uuid;
    this.firstName = firstName;
    this.lastName = lastName;
    this.password = password;
    this.email = email;
    this.isLibrarian = isLibrarian;
  }

  public User()
  {
  }

  public String getUuid()
  {
    return String.valueOf(uuid);
  }

  public void setUuid(String uuid)
  {
    this.uuid = uuid;
  }

  public String getFirstName()
  {
    return firstName;
  }

  public void setFirstName(String firstName)
  {
    this.firstName = firstName;
  }

  public String getLastName()
  {
    return lastName;
  }

  public void setLastName(String lastName)
  {
    this.lastName = lastName;
  }

  public String getPassword()
  {
    return password;
  }

  public void setPassword(String password)
  {
    this.password = password;
  }

  public String getEmail()
  {
    return email;
  }

  public void setEmail(String email)
  {
    this.email = email;
  }

  public boolean getIsLibrarian()
  {
    return isLibrarian;
  }

  public void setIsLibrarian(boolean isLibrarian)
  {
    this.isLibrarian = isLibrarian;
  }

  @Override public boolean equals(Object o)
  {
    if (this == o)
      return true;
    if (o == null || getClass() != o.getClass())
      return false;
    User user = (User) o;
    return uuid == user.uuid && Objects.equals(firstName

        , user.firstName

    ) && Objects.equals(lastName

        , user.lastName

    ) && Objects.equals(password

        , user.password

    ) && Objects.equals(email

        , user.email

    ) && Objects.equals(isLibrarian

        , user.isLibrarian

    );
  }

  @Override public int hashCode()
  {
    return Objects.hash(uuid, firstName, lastName

        , password

        , email

        , isLibrarian

    );
  }

  @Override public String toString()
  {
    return "User{" + "UUID=" + uuid + ", firstName ='" + firstName + '\''
        + ", lastName ='" + lastName + '\'' + ", password ='" + password + '\''
        + ", email ='" + email + '\'' + ", isLibrarian ='" + isLibrarian + '\''
        + '}';
  }
}