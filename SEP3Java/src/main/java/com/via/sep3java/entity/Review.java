package com.via.sep3java.entity;

import jakarta.persistence.*;

import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import java.util.UUID;

@Entity
public class Review {
  @Id
  private String uuid;

  public Review () {
    uuid = UUID.randomUUID().toString();
  }

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "isbn")
  private BookRegistry bookRegistry;


  @Column(nullable = false)
  @Min(1)
  @Max(10)
  private int score;

  @Column(nullable = false)
  private String reviewerUUID;

  @Column
  private String comment;

  public int getScore()
  {
    return score;
  }

  public void setScore(int score)
  {
    this.score = score;
  }

  public String getReviewerUUID()
  {
    return reviewerUUID;
  }

  public void setReviewerUUID(String reviewerUUID)
  {
    this.reviewerUUID = reviewerUUID;
  }

  public String getComment()
  {
    return comment;
  }

  public void setComment(String comment)
  {
    this.comment = comment;
  }
}
