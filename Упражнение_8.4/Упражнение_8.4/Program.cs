using System;

class Program
{
    //Проверка через оператор is
    public static bool CheckIs(object obj)
    {
        if (obj is IFormattable)
        {
            return true;
        }
        return false;
        
    }

    //Проверка через оператор as
    public static bool CheckAs(object obj)
    {
        IFormattable formattableObj = obj as IFormattable;

        if (formattableObj != null)
        {
            return true;
        }
        return false;
    }
}

