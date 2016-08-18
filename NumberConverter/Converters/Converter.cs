namespace NumberConverter.Converters
{
  public abstract class Converter : INumberConverter
  {
    protected readonly string Source;
    protected long SourceValue;

    protected Converter(string source)
    {
      Source = source;
    }

    public abstract string Convert(NumberFormat destinationFormat);
  }
}
