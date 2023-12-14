package com.via.sep3java.service;

import org.hibernate.PropertyValueException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

@ControllerAdvice public class GlobalExceptionHandler
{

    private static final GlobalExceptionHandler instance = new GlobalExceptionHandler();

    private GlobalExceptionHandler()
    {
    }

    public static GlobalExceptionHandler getInstance()
    {
        return instance;
    }

    @ExceptionHandler(PropertyValueException.class) public ResponseEntity<String> handlePropertyValueException(
        PropertyValueException ex)
    {
        return ResponseEntity.status(HttpStatus.BAD_REQUEST)
            .body("Invalid request data: " + ex.getMessage());
    }
}
