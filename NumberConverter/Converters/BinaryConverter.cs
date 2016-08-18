using System.IO;

namespace NumberConverter.Converters
{
  class BinaryConverter : Converter
  {
    /// <summary>
    /// Constructor - Convert from binary.
    /// </summary>
    /// <param name="source">A number in binary form.</param>
    public BinaryConverter(string source) : base(source)
    {
      SourceValue = System.Convert.ToInt64(Source, BaseValues.Binary);
    }

    /// <summary>
    /// Convert from binary to the provided format.
    /// </summary>
    /// <param name="destinationFormat">The output format.</param>
    /// <returns>A string of the source number in the desired format.</returns>
    public override string Convert(NumberFormat destinationFormat)
    {
      switch (destinationFormat)
      {
        case NumberFormat.Binary:
        {
          string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.BinaryPrefix : string.Empty;
          return prefix + Source;
        }
        case NumberFormat.Octal:
          return ToOctal();
        case NumberFormat.Decimal:
          return ToDecimal();
        case NumberFormat.Hexadecimal:
          return ToHex();
        default:
          throw new InvalidDataException("Number format not recognized.");
      }
    }

    private string ToOctal()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.OctalPrefix : string.Empty;

      return prefix + System.Convert.ToString(SourceValue, BaseValues.Octal);
    }

    private string ToDecimal()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.DecimcalPrefix : string.Empty;

      return prefix + System.Convert.ToString(SourceValue, BaseValues.Decimal);
    }

    private string ToHex()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.HexPrefix : string.Empty;
      string result = System.Convert.ToString(SourceValue, BaseValues.Hexadecimal);
      return prefix + ((Properties.Settings.Default.UppercaseHex) ? result.ToUpperInvariant() : result);
    }
  }
}
