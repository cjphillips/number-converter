using System;
using System.IO;

namespace NumberConverter.Converters
{
  class DecimalConverter : Converter
  {
    /// <summary>
    /// Constructor - Convert from decimal.
    /// </summary>
    /// <param name="source">A number in decimal form.</param>
    public DecimalConverter(string source) : base(source)
    {
      SourceValue = Int64.Parse(Source);
    }

    /// <summary>
    /// Convert from decimal to the provided format.
    /// </summary>
    /// <param name="destinationFormat">The output format.</param>
    /// <returns>A string of the source number in the desired format.</returns>
    public override string Convert(NumberFormat destinationFormat)
    {
      switch (destinationFormat)
      {
        case NumberFormat.Binary:
          return ToBinary();
        case NumberFormat.Octal:
          return ToOctal();
        case NumberFormat.Decimal:
        {
          string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.DecimcalPrefix : string.Empty;
          return prefix + Source;
        }
        case NumberFormat.Hexadecimal:
          return ToHex();
        default:
          throw new InvalidDataException("Number format not recognized.");
      }
    }
    private string ToBinary()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.BinaryPrefix : string.Empty;

      return prefix + System.Convert.ToString(SourceValue, BaseValues.Binary);
    }

    private string ToOctal()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.OctalPrefix : string.Empty;

      return prefix + System.Convert.ToString(SourceValue, BaseValues.Octal);
    }

    private string ToHex()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.HexPrefix : string.Empty;
      string result = System.Convert.ToString(SourceValue, BaseValues.Hexadecimal);
      return prefix + ((Properties.Settings.Default.UppercaseHex) ? result.ToUpperInvariant() : result);
    }
  }
}
