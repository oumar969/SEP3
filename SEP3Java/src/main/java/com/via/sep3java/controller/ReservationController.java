package com.via.sep3java.controller;

import com.via.sep3java.entity.User;
import com.via.sep3java.entity.UserReservation;
import com.via.sep3java.repository.ReservationRepository;
import com.via.sep3java.repository.UserRepository;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value = "/reservation")
public class ReservationController {

    private ReservationRepository reservationRepository;





}
