package com.via.sep3java;

import com.via.sep3java.service.ISBNServices;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class ISBNServicesTest
{

  @Test void testGenerateISBN()
  {
    String generatedISBN = ISBNServices.Generate();

    assertThat(generatedISBN).isNotNull();
    assertThat(generatedISBN.length()).isEqualTo(13);
    assertThat(isValidISBN(generatedISBN)).isTrue();
  }

  @Test void testGenerateMultipleISBNs()
  {
    String isbn1 = ISBNServices.Generate();
    String isbn2 = ISBNServices.Generate();

    assertThat(isbn1).isNotEqualTo(isbn2);
  }

  @Test void testNullISBN()
  {
    assertThrows(IllegalArgumentException.class, () -> isValidISBN(null));
  }

  private boolean isValidISBN(String isbn)
  {
    if (isbn == null || isbn.length() != 13)
    {
      throw new IllegalArgumentException("Invalid ISBN");
    }

    int sum = 0;

    for (int i = 0; i < 12; i++)
    {
      int digit = Character.getNumericValue(isbn.charAt(i));

      sum += ((i % 2 == 0) ? 1 : 3) * digit;
    }

    int checkDigit = (10 - (sum % 10)) % 10;
    return Character.getNumericValue(isbn.charAt(12)) == checkDigit;
  }

}
