using System;
using System.IO;

namespace NumberConverter.Extensions
{
  public static class StringExtensions
  {
    public static void ThrowIfNullOrWhiteSpace(this string value)
    {
      if (value == String.Empty)
      {
        throw new InvalidDataException("Cannot be empty.");
      }

      if (String.IsNullOrWhiteSpace(value))
      {
        throw new NullReferenceException("Cannot be null.");
      }
    }

    public static bool IsValidNumberFormat(this string value, NumberFormat format)
    {
      string lowerVariant = value.ToLowerInvariant();

      switch (format)
      {
        case NumberFormat.Binary:
        {
          return lowerVariant.Length > 2 && lowerVariant[0] == '0' && lowerVariant[1] == 'b';
        }
        case NumberFormat.Hexadecimal:
        {
          return lowerVariant.Length > 2 && lowerVariant[0] == '0' && lowerVariant[1] == 'x';
        }
        case NumberFormat.Octal:
        {
          return lowerVariant.Length > 2 && lowerVariant[0] == '0' && lowerVariant[1] == 'o';
        }
        case NumberFormat.Decimal:
        {
          return true;
        }
        default:
        {
          throw new InvalidDataException("Number format not recognized");
        }
      }
    }
  }
}
