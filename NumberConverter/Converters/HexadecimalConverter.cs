using System.IO;

namespace NumberConverter.Converters
{
  class HexadecimalConverter : Converter
  {
    /// <summary>
    /// Constructor - Convert from hexadecimal.
    /// </summary>
    /// <param name="source">A number in hexadecimal form.</param>
    public HexadecimalConverter(string source) : base(source)
    {
      SourceValue = System.Convert.ToInt64(Source, BaseValues.Hexadecimal);
    }

    /// <summary>
    /// Convert from hexadecimal to the provided format.
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
          return ToDecimal();
        case NumberFormat.Hexadecimal:
        {
          string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.HexPrefix : string.Empty;
          return prefix + Source;
        }
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

    private string ToDecimal()
    {
      string prefix = Properties.Settings.Default.IncludePrefix ? BaseValues.DecimcalPrefix : string.Empty;

      return prefix + System.Convert.ToString(SourceValue, BaseValues.Decimal);
    }
  }
}
