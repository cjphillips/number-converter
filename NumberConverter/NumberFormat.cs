using System.ComponentModel;

namespace NumberConverter
{
  public enum NumberFormat
  {
    [Description("Binary")]
    Binary,
    [Description("Octal")]
    Octal,
    [Description("Decimal")]
    Decimal,
    [Description("Hexadecimal")]
    Hexadecimal
  }
}
