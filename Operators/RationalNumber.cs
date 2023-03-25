public class RationalNumber
{
    private int numerator;
    private int denominator;

    // Конструкторы
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю.");
        }

        // Проверка на отрицательный знаменатель
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        // Поиск НОД числителя и знаменателя
        int gcd = Gcd(numerator, denominator);

        // Деление числителя и знаменателя на НОД
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }

    public RationalNumber(int numerator) : this(numerator, 1)
    {
    }

    // Свойства
    public int Numerator
    {
        get { return numerator; }
    }

    public int Denominator
    {
        get { return denominator; }
    }

    // Арифметические операции
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.numerator * b.denominator + b.numerator * a.denominator;
        int denominator = a.denominator * b.denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.numerator * b.denominator - b.numerator * a.denominator;
        int denominator = a.denominator * b.denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.numerator * b.numerator;
        int denominator = a.denominator * b.denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        if (b.numerator == 0)
        {
            throw new DivideByZeroException("Деление на ноль.");
        }

        int numerator = a.numerator * b.denominator;
        int denominator = a.denominator * b.numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.numerator == b.numerator && a.denominator == b.denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (this.numerator << 2) ^ this.denominator;
    }

// Методы для сравнения дробей
    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator < b.numerator * a.denominator;
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator > b.numerator * a.denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator <= b.numerator * a.denominator;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator >= b.numerator * a.denominator;
    }

// Метод для вывода дроби в формате "числитель/знаменатель"
    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

// Метод для поиска НОД двух чисел
    private static int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }

        return a;
    }
}