namespace ConsoleApp37
{
    public record DailyTemperature(DateTime Date, double High, double Low);
    public record StudentGrade(string Subject, double Grade);
    public record Student(string Name, StudentGrade[] Grades)
    {
        public double AverageGrade => Grades.Average(g => g.Grade);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 13;
            Console.WriteLine($"{number} is Fibonacci: {number.IsFibonacci()}");
            number = 14;
            Console.WriteLine($"{number} is Fibonacci: {number.IsFibonacci()}");
            string sentence = "This is a sample sentence for counting words.";
            Console.WriteLine($"Word count: {sentence.WordCount()}");
            string sentence2 = "This is a sample sentence.";
            Console.WriteLine($"Length of the last word: {sentence.LengthOfLastWord()}");
            string valid = "{[()]}";
            string invalid = "{[(])}";
            Console.WriteLine($"Is '{valid}' valid? {valid.AreBracketsValid()}");
            Console.WriteLine($"Is '{invalid}' valid? {invalid.AreBracketsValid()}");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Predicate<int> isEven = x => x % 2 == 0;
            int[] evenNumbers = numbers.Filter(isEven);
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
            DailyTemperature[] temperatures = {
            new DailyTemperature(new DateTime(2023, 1, 1), 15, 5),
            new DailyTemperature(new DateTime(2023, 1, 2), 18, 8),
            new DailyTemperature(new DateTime(2023, 1, 3), 20, 10),
            new DailyTemperature(new DateTime(2023, 1, 4), 12, 6)
            };
            var dayWithMaxDifference = temperatures.OrderByDescending(t => t.High - t.Low).First();
            Console.WriteLine($"Day with max temperature difference: {dayWithMaxDifference.Date.ToShortDateString()}, Difference: {dayWithMaxDifference.High - dayWithMaxDifference.Low}");
            Student[] students = {
            new Student("Alice", new[] { new StudentGrade("Math", 90), new StudentGrade("English", 80) }),
            new Student("Bob", new[] { new StudentGrade("Math", 85), new StudentGrade("English", 90) }),
            new Student("Charlie", new[] { new StudentGrade("Math", 95), new StudentGrade("English", 85) })
            };
            var topStudent = students.OrderByDescending(s => s.AverageGrade).First();
            var averageGrade = students.Average(s => s.AverageGrade);
            Console.WriteLine($"Top student: {topStudent.Name}, Average Grade: {topStudent.AverageGrade}");
            Console.WriteLine($"Average grade of all students: {averageGrade}");
        }
    }
}
public static class IntExtensions
{
    public static bool IsFibonacci(this int number)
    {
        if (number < 0) return false;
        int a = 0;
        int b = 1;
        while (b < number)
        {
            int temp = b;
            b += a;
            a = temp;
        }
        return b == number || a == number;
    }
}
public static class StringExtensions
{
    public static int WordCount(this string str)
    {
        return string.IsNullOrWhiteSpace(str) ? 0 : str.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
public static class StringExtensions2
{
    public static int LengthOfLastWord(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return 0;
        string[] words = str.Trim().Split(' ');
        return words[^1].Length;
    }
}
public static class StringExtensions3
{
    public static bool AreBracketsValid(this string str)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in str)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0) return false;
                char open = stack.Pop();
                if (!IsMatchingPair(open, ch)) return false;
            }
        }
        return stack.Count == 0;
    }
    private static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
}
public static class ArrayExtensions
{
    public static int[] Filter(this int[] array, Predicate<int> predicate)
    {
        return Array.FindAll(array, predicate);
    }
}
