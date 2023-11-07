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
    this.uuid = UUID.randomUUID().toString();
  }

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "isbn")
  private BookRegistry bookRegistry;


  @Column(nullable = false)
  @Min(1)
  @Max(10)
  private int score;

  @Column(nullable = false)
  private String reviewerUuid;

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
}
