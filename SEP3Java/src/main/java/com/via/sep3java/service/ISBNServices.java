package com.via.sep3java.service;

import java.util.Random;

public class ISBNServices
{
  public static String Generate(){
    Random rand = new Random();
    int[] isbn = new int[13];
    int sum = 0;

    // Generate first 12 digits randomly
    for (int i = 0; i < 12; i++) {
      isbn[i] = rand.nextInt(10);
    }

    // Calculate the check digit
    for (int i = 0; i < 12; i++) {
      sum += ((i % 2 == 0) ? 1 : 3) * isbn[i];
    }

    // The check digit is the number which adds the calculated sum to nearest multiple of 10
    isbn[12] = (10 - (sum % 10)) % 10;

    StringBuilder sb = new StringBuilder();
    for (int number : isbn) {
      sb.append(number);
    }

    return sb.toString();
  }
}
