package com.via.sep3java.entity;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
public class UserReservation{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    int id;
    @Column(nullable = false)
    int userId;
    @Column(nullable = false)
    private LocalDate reservationDate;
    @Column(nullable = false)
    private int bookId;
    @Column
    private String bookIsbn;
    @Column(nullable = false)
    private String bookTitle;
    @Column
    private String bookAuthor;
    @Column
    private String libraryLocation;
    @Column(nullable = false)
    private String userFirstName;
    @Column
    private String userLastName;
    private String userEmail;
    @Column(nullable = false)
    private boolean isActive;
    @Column(nullable = false)
    private LocalDate pickupDate;



    public UserReservation() {
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public LocalDate getReservationDate() {
        return reservationDate;
    }

    public void setReservationDate(LocalDate reservationDate) {
        this.reservationDate = reservationDate;
    }

    public int getBookId() {
        return bookId;
    }

    public void setBookId(int bookId) {
        this.bookId = bookId;
    }

    public String getBookTitle() {
        return bookTitle;
    }

    public void setBookTitle(String bookTitle) {
        this.bookTitle = bookTitle;
    }

    public String getUserFirstName() {
        return userFirstName;
    }

    public void setUserFirstName(String userFirstName) {
        this.userFirstName = userFirstName;
    }

    public String getUserLastName() {
        return userLastName;
    }

    public void setUserLastName(String userLastName) {
        this.userLastName = userLastName;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }

    public LocalDate getPickupDate() {
        return pickupDate;
    }

    public void setPickupDate(LocalDate pickupDate) {
        this.pickupDate = pickupDate;
    }

    public String getBookIsbn() {
        return bookIsbn;
    }

    public void setBookIsbn(String bookIsbn) {
        this.bookIsbn = bookIsbn;
    }

    public String getBookAuthor() {
        return bookAuthor;
    }

    public void setBookAuthor(String bookAuthor) {
        this.bookAuthor = bookAuthor;
    }

    public String getLibraryLocation() {
        return libraryLocation;
    }

    public void setLibraryLocation(String libraryLocation) {
        this.libraryLocation = libraryLocation;
    }

    @Override
    public String toString() {
        return "UserReservationController{" +
                "id=" + id +
                ", userId=" + userId +
                ", reservationDate=" + reservationDate +
                ", bookId=" + bookId +
                ", bookIsbn='" + bookIsbn + '\'' +
                ", bookTitle='" + bookTitle + '\'' +
                ", bookAuthor='" + bookAuthor + '\'' +
                ", libraryLocation='" + libraryLocation + '\'' +
                ", userFirstName='" + userFirstName + '\'' +
                ", userLastName='" + userLastName + '\'' +
                ", userEmail='" + userEmail + '\'' +
                ", isActive=" + isActive +
                ", pickupDate=" + pickupDate +
                '}';
    }
}
