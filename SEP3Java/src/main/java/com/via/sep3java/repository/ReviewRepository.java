package com.via.sep3java.repository;

import com.via.sep3java.entity.Review;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ReviewRepository extends CrudRepository<Review, String> {
    Review findByUuid(String uuid);

    Review findByBookUuid(String bookUuid);

    List<Review> findAllByBookUuid(String bookUuid);

    List<Review> findAllByScore(int score);
}