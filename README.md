# PersianDateExtension

Handy little C# DateTime extension library to output DateTime and DateOnly objects to Persian date strings. Bundled as an extension to reduce the need to write the code again.


## Usage

The extension is available on all ``DateTime`` and ``DateOnly`` objects. You can pass none, one, or some arguments.

Valid combinations are:

```C#
string output = date.ToPersianDate();
string output = date.ToPersianDate((Enum)PersianDateFormat);
string output = date.ToPersianDate((Enum)PersianDateFormat, (bool)ZeroPadding);
```

``PersianDateFormat`` includes:

|Format|Example Output|
|------|--------------|
|US|MM/DD/YYYY|
|International|DD/MM/YYYY|
|Hyphenated|YYYY-MM-DD|


``ZeroPadding`` refers to placing a 0 before days and months less than 10. For example, instead of 9 it outputs as 09.

