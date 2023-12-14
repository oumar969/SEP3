package com.via.sep3java.service;

import java.util.Random;

public class ISBNServices
{
  public static String Generate()
  {
    Random rand = new Random();
    int[] isbn = new int[13];
    int sum = 0;

    for (int i = 0; i < 12; i++)
    {
      isbn[i] = rand.nextInt(10);
    }

    for (int i = 0; i < 12; i++)
    {
      sum += ((i % 2 == 0) ? 1 : 3) * isbn[i];
    }

    isbn[12] = (10 - (sum % 10)) % 10;

    StringBuilder sb = new StringBuilder();
    for (int number : isbn)
    {
      sb.append(number);
    }

    return sb.toString();
  }
}
