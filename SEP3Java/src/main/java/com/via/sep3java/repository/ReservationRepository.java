package com.via.sep3java.repository;

import com.via.sep3java.entity.UserReservation;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ReservationRepository extends CrudRepository<UserReservation, Integer>
//crudRepository er en interface som har en masse metoder som vi kan bruge til at lave CRUD operationer på vores database
{
    List<UserReservation> findById(int id);
    List<UserReservation> findByUserId(int id);
    void deleteById(int id);
}
