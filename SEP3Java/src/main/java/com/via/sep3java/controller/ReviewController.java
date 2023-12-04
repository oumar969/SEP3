package com.via.sep3java.controller;

import com.via.sep3java.entity.Review;
import com.via.sep3java.repository.ReviewRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@RequestMapping("/review")
public class ReviewController {
    @Autowired
    private ReviewRepository reviewRepository;

    @PostMapping("/create")
    public ResponseEntity<?> createReview(
            @RequestBody Review review) {
        return new ResponseEntity<>(reviewRepository.save(review),
                HttpStatus.CREATED);
    }

    @PutMapping("/update/{uuid}")
    public ResponseEntity<?> updateReview(
            @PathVariable String uuid, @RequestBody Map<String, String> body) {
        Review review = reviewRepository.findByUuid(uuid);
        if (review == null) {
            return new ResponseEntity<>("Review with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        String comment = body.get("comment");
        if (comment != null && !comment.isEmpty()) {
            review.setComment(comment);
        }
        String score = body.get("score");
        if (score != null && !score.isEmpty()) {
            review.setScore(Integer.parseInt(score));
        }
        reviewRepository.save(review);
        return new ResponseEntity<>(
                "Review with UUID " + uuid + " updated successfully.", HttpStatus.OK);
    }

    @DeleteMapping("/delete/{uuid}")
    public ResponseEntity<?> deleteReview(
            @PathVariable String uuid) {
        Review review = reviewRepository.findByUuid(uuid);
        if (review == null) {
            return new ResponseEntity<>("Review with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        reviewRepository.delete(review);
        return new ResponseEntity<>(
                "Review with UUID " + uuid + " deleted successfully.", HttpStatus.OK);
    }

    @GetMapping("/get/{uuid}")
    public ResponseEntity<?> getReview(
            @PathVariable String uuid) {
        Review review = reviewRepository.findByUuid(uuid);
        if (review == null) {
            return new ResponseEntity<>("Review with UUID " + uuid + " not found.",
                    HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(review, HttpStatus.OK);
    }

//    @GetMapping("/get/byBook/{bookUuid}")
//    public ResponseEntity<?> getReviewByBook(
//            @PathVariable String bookUuid) {
//        Review review = reviewRepository.findByBookUuid(bookUuid);
//        if (review == null) {
//            return new ResponseEntity<>("Review with Book UUID " + bookUuid + " not found.",
//                    HttpStatus.NOT_FOUND);
//        }
//        return new ResponseEntity<>(review, HttpStatus.OK);
//    }

}