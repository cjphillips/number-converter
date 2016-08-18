using System;
using System.IO;
using NumberConverter.Converters;

namespace NumberConverter
{
  public static class NumberFormatConverter
  {
    /// <summary>
    /// Convert the provided number from its source format to a destination format.
    /// </summary>
    /// <param name="source">The source number (expected to be in the same format as 'sourceFormat'.</param>
    /// <param name="sourceFormat">The input format.</param>
    /// <param name="destinationFormat">The output format.</param>
    /// <returns>A string representation of the provided number in the desired format.</returns>
    /// <exception cref="System.FormatException"/>
    /// <exception cref="System.OverflowException"/>
    /// <exception cref="System.ArgumentNullException"/>
    public static string Convert(string source, NumberFormat sourceFormat, NumberFormat destinationFormat)
    {
      if (String.IsNullOrWhiteSpace(source))
      {
        return string.Empty;
      }

      return _Convert(source, sourceFormat, destinationFormat);
    }

    private static string _Convert(string source, NumberFormat sourceFormat, NumberFormat destinationFormat)
    {
      Converter converter;

      switch (sourceFormat)
      {
        case NumberFormat.Binary:
        {
          converter = new BinaryConverter(source);
          break;
        }
        case NumberFormat.Octal:
        {
          converter = new OctalConverter(source);
          break;
        }
        case NumberFormat.Decimal:
        {
          converter = new DecimalConverter(source);
          break;
        }
        case NumberFormat.Hexadecimal:
        {
          converter = new HexadecimalConverter(source);
          break;
        }
        default:
          throw new InvalidDataException("Number format not recognized.");
      }

      return converter.Convert(destinationFormat);
    }
  }
}
