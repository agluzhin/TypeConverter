/// <summary>
/// Converts string type of player's input into others. 
/// </summary>
public static class TypeConverter
{
    public static T Parse<T>(string input) => (T)Parse(input, typeof(T));

    public static object Parse(string input, Type targetType)
    {
        if (String.IsNullOrEmpty(input))
        {
            throw new Exception("Type Error: Input variable is null or empty");
        }

        TypeCode targetTypeCode = Type.GetTypeCode(targetType);
        if (targetTypeCode != TypeCode.Object)
        {
            switch (targetTypeCode)
            {
                case TypeCode.String:
                    return input;
                case TypeCode.Boolean:
                    if (_CanParseBoolean(input, out bool booleanTypeResult)) return booleanTypeResult;
                    break;
                case TypeCode.Int32:
                    if (int.TryParse(input, out int intTypeResult)) return intTypeResult;
                    break;
                case TypeCode.Int64:
                    if (long.TryParse(input, out long longTypeResult)) return longTypeResult;
                    break;
                case TypeCode.Single:
                    if (float.TryParse(input, out float floatTypeResult)) return floatTypeResult;
                    break;
                case TypeCode.Double:
                    if (double.TryParse(input, out double doubleTypeResult)) return doubleTypeResult;
                    break;
                case TypeCode.DateTime:
                    if (DateTime.TryParse(input, out DateTime dateTimeTypeResult)) return dateTimeTypeResult;
                    break;
                case TypeCode.Char:
                    if (char.TryParse(input, out char charTypeResult)) return charTypeResult;
                    break;
                default:
                    throw new Exception("Type Error: Unsupported premetive parsing type");
            }
        }

        if (targetType == typeof(Array))
        {
            return input.Split(",");
        }

        throw new Exception("Type Error: Unknown parsing type");
    }

    /// <summary>
    /// Validates boolean type with another key words: on/off intead of "true/false".
    /// </summary>
    /// <param name="input">Player's input.</param>
    /// <param name="result">Thes result of parsing if it was successful.</param>
    /// <returns></returns>
    private static bool _CanParseBoolean(string input, out bool result)
    {
        result = false;
        if (input.ToLower() == "on")
        {
            result = true;
            return result;
        }
        if (input.ToLower() == "off")
        {
            return true;
        }
        return result;
    }
}