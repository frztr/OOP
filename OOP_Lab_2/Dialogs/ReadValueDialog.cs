using System.ComponentModel;

namespace Lab2;

public class ReadValueDialog<T> : IDialog<T>
{
    string propname;
    bool ignoreEmptyField;
    public ReadValueDialog(string propname, bool ignoreEmptyField = true)
    {
        this.propname = propname;
        this.ignoreEmptyField = ignoreEmptyField;
    }
    public T Dialog()
    {
        Console.WriteLine($@"Введите параметр '{propname}'");
        string input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            if (!ignoreEmptyField)
            {
                Console.WriteLine($@"Параметр '{propname}' не может быть пустым.");
            }
            return default(T);
        }
        if (typeof(T) == typeof(string))
        {
            return (T)(object)input;
        }
        if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
        {
            if (!int.TryParse(input, out int e))
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(T);
            }
            else
            {
                return (T)(object)e;
            }
        }
        if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
        {
            if (!double.TryParse(input, out double e))
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(T);
            }
            else
            {
                return (T)(object)e;
            }
        }
        if (typeof(T) == typeof(DataStructure) || typeof(T) == typeof(DataStructure?))
        {

            if (!int.TryParse(input, out int a))
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(T);
            }
            if (a >= 1 && a <= 3)
            {
                return (T)(object)a;
            }
            else
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(T);
            }
        }
        return default(T);
    }
}