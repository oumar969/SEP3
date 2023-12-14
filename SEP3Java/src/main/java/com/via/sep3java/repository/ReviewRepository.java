package com.via.sep3java.repository;

import com.via.sep3java.entity.Review;
import org.springframework.data.repository.CrudRepository;

public interface ReviewRepository extends CrudRepository<Review, String>
{
    Review findByUuid(String uuid);
}