using System.Globalization;


namespace PersianDateExtension;


///<summary>Provides extension methods for converting DateTime objects to Persian date strings.</summary>
public static class PersianDateExtension
{
  ///<summary>Defines the format of the output string. US, International, or Hyphenated.</summary>
  ///<remarks>US: MM/DD/YYYY, International: DD/MM/YYYY, Hyphenated: YYYY-MM-DD</remarks>
  public enum PersianDateFormat { US, International, Hyphenated }


  ///<summary>Converts a DateOnly object to a Persian date string.</summary>
  ///<param name="date">The DateOnly object to convert.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateOnly date)
  {
    return ToPersianDate(date.ToDateTime(TimeOnly.Parse("03:00 AM")), PersianDateFormat.Hyphenated, true);
  }


  ///<summary>Converts a DateOnly object to a Persian date string.</summary>
  ///<param name="date">The DateOnly object to convert.</param>
  ///<param name="format">The format of the output string. US, International, or Hyphenated.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateOnly date, PersianDateFormat format = PersianDateFormat.Hyphenated)
  {
    return ToPersianDate(date.ToDateTime(TimeOnly.Parse("03:00 AM")), format, true);
  }


  ///<summary>Converts a DateOnly object to a Persian date string.</summary>
  ///<param name="date">The DateOnly object to convert.</param>
  ///<param name="format">The format of the output string. US, International, or Hyphenated.</param>
  ///<param name="zero">If true, the month and day will be zero-padded.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateOnly date, PersianDateFormat format = PersianDateFormat.Hyphenated, bool zero = true)
  {
    return ToPersianDate(date.ToDateTime(TimeOnly.Parse("03:00 AM")), format, zero);
  }


  ///<summary>Converts a DateTime object to a Persian date string.</summary>
  ///<param name="date">The DateTime object to convert.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateTime date)
  {
    return ToPersianDate(date, PersianDateFormat.Hyphenated, true);
  }


  ///<summary>Converts a DateTime object to a Persian date string.</summary>
  ///<param name="date">The DateTime object to convert.</param>
  ///<param name="format">The format of the output string. US, International, or Hyphenated.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateTime date, PersianDateFormat format = PersianDateFormat.Hyphenated)
  {
    return ToPersianDate(date, format, true);
  }


  ///<summary>Converts a DateTime object to a Persian date string.</summary>
  ///<param name="date">The DateTime object to convert.</param>
  ///<param name="format">The format of the output string. US, International, or Hyphenated.</param>
  ///<param name="zero">If true, the month and day will be zero-padded.</param>
  ///<returns>A string representing the Persian date.</returns>
  public static string ToPersianDate(this DateTime date, PersianDateFormat format = PersianDateFormat.Hyphenated, bool zero = true)
  {
    PersianCalendar persian = new PersianCalendar();
    string month = persian.GetMonth(date).ToString();
    if(zero) month = persian.GetMonth(date) < 10 ? "0" + month : month;

    string day = persian.GetDayOfMonth(date).ToString();
    if(zero) day = persian.GetDayOfMonth(date) < 10 ? "0" + day : day;

    switch(format)
    {
      case PersianDateFormat.US: return $"{month}/{day}/{persian.GetYear(date)}";
      case PersianDateFormat.International: return $"{day}/{month}/{persian.GetYear(date)}";
      case PersianDateFormat.Hyphenated: return $"{persian.GetYear(date)}-{month}-{day}";
    }

    return $"{persian.GetYear(date)}-{month}-{day}";
  }
}
