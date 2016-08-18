using System;
using System.Windows;
using System.Windows.Controls;

namespace NumberConverter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private const string ErrorText = "(error)";
    private const string OverflowError = "Error: Overflow! The number is too large.";
    private const string FormatError = "Error: Check your source format.";
    private const string BadValueError = "Error: Please report this error.";

    public MainWindow()
    {
      InitializeComponent();
      RestoreSettings();
    }

    private void SourceTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
      try
      {
        UpdateControls();
      }
      catch (FormatException)
      {
        ReportError(FormatError);
      }
      catch (ArgumentNullException)
      {
        ReportError(BadValueError);
      }
      catch (OverflowException)
      {
        ReportError(OverflowError);
      }
    }

    private void SourceTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      try
      {
        UpdateControls();
      }
      catch (FormatException)
      {
        ReportError(FormatError);
      }
      catch (ArgumentNullException)
      {
        ReportError(BadValueError);
      }
      catch (OverflowException)
      {
        ReportError(OverflowError);
      }
    }

    private void DestinationTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      try
      {
        UpdateControls();
      }
      catch (FormatException)
      {
        ReportError(FormatError);
      }
      catch (ArgumentNullException)
      {
        ReportError(BadValueError);
      }
      catch (OverflowException)
      {
        ReportError(OverflowError);
      }
    }

    private void ShowPrefixesMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
      try
      {
        Properties.Settings.Default.IncludePrefix = ShowPrefixesMenuItem.IsChecked;
        Properties.Settings.Default.Save();
        UpdateControls();
      }
      catch (FormatException)
      {
        ReportError(FormatError);
      }
      catch (ArgumentNullException)
      {
        ReportError(BadValueError);
      }
      catch (OverflowException)
      {
        ReportError(OverflowError);
      }
    }

    private void UppercaseHexMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
      try
      {
        Properties.Settings.Default.UppercaseHex = UppercaseHex.IsChecked;
        Properties.Settings.Default.Save();
        UpdateControls();
      }
      catch (FormatException)
      {
        ReportError(FormatError);
      }
      catch (ArgumentNullException)
      {
        ReportError(BadValueError);
      }
      catch (OverflowException)
      {
        ReportError(OverflowError);
      }
    }

    private void UpdateControls()
    {
      if (null == DestinationTypeComboBox ||
          null == SourceTypeComboBox ||
          null == SourceTextBox ||
          null == DestinationTextBox)
      {
        return;
      }

      WarningLabel.Content = string.Empty;
      string result = NumberFormatConverter.Convert(
                        SourceTextBox.Text,
                        (NumberFormat)SourceTypeComboBox.SelectedItem,
                        (NumberFormat)DestinationTypeComboBox.SelectedItem);

      DestinationTextBox.Text = result;
    }

    private void ReportError(string message)
    {
      DestinationTextBox.Text = ErrorText;
      WarningLabel.Content = message;
    }

    private void RestoreSettings()
    {
      ShowPrefixesMenuItem.IsChecked = Properties.Settings.Default.IncludePrefix;
      UppercaseHex.IsChecked = Properties.Settings.Default.UppercaseHex;
    }
  }
}
