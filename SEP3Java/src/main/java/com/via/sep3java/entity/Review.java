package com.via.sep3java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import java.util.UUID;

@Entity public class Review
{
  @Id private String uuid;
  @Column(nullable = false) private String isbn;
  @Column(nullable = false) @Min(1) @Max(10) private int score;
  @Column(nullable = false) private String reviewerUuid;
  @Column private String comment;

  public Review()
  {
    this.uuid = UUID.randomUUID().toString();
  }

  public int getScore()
  {
    return score;
  }

  public void setScore(int score)
  {
    this.score = score;
  }

  public String getReviewerUuid()
  {
    return reviewerUuid;
  }

  public void setReviewerUuid(String reviewerUuid)
  {
    this.reviewerUuid = reviewerUuid;
  }

  public String getComment()
  {
    return comment;
  }

  public void setComment(String comment)
  {
    this.comment = comment;
  }

  public String getIsbn()
  {
    return isbn;
  }

  public void setIsbn(String isbn)
  {
    this.isbn = isbn;
  }

  @Override public String toString()
  {
    return "Review{" + "uuid='" + uuid + '\'' + ", isbn='" + isbn + '\''
        + ", score=" + score + ", reviewerUuid='" + reviewerUuid + '\''
        + ", comment='" + comment + '\'' + '}';
  }
}
