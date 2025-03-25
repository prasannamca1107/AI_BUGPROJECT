using System;

namespace BuggyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Buggy Console App!");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Perform Addition (BuggyMath.Add)");
                Console.WriteLine("2. Perform Division (BuggyMath.Divide)");
                Console.WriteLine("3. Reverse a String (BuggyStringManipulator.ReverseString)");
                Console.WriteLine("4. Access Array Element (BuggyArrayProcessor.PrintArrayElement)");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            BuggyMath math = new BuggyMath();
                            Console.WriteLine("Enter two numbers to add:");
                            int a = Convert.ToInt32(Console.ReadLine());
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Result: {math.Add(a, b)}");
                            break;

                        case "2":
                            BuggyMath mathDiv = new BuggyMath();
                            Console.WriteLine("Enter two numbers to divide:");
                            int num1 = Convert.ToInt32(Console.ReadLine());
                            int num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Result: {mathDiv.Divide(num1, num2)}");
                            break;

                        case "3":
                            BuggyStringManipulator strManipulator = new BuggyStringManipulator();
                            Console.WriteLine("Enter a string to reverse:");
                            string input = Console.ReadLine();
                            Console.WriteLine($"Reversed String: {strManipulator.ReverseString(input)}");
                            break;

                        case "4":
                            BuggyArrayProcessor arrayProcessor = new BuggyArrayProcessor();
                            int[] arr = { 1, 2, 3 };
                            Console.WriteLine("Enter array index to access (0-2):");
                            int index = Convert.ToInt32(Console.ReadLine());
                            arrayProcessor.PrintArrayElement(arr, index);
                            break;

                        case "5":
                            Console.WriteLine("Exiting program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogError("Program", "Main", ex);
                }
            }
        }

        static void LogError(string className, string methodName, Exception ex)
        {
            Console.WriteLine($"[ERROR] Class: {className}, Method: {methodName}, Message: {ex.Message}");
        }
    }

    class BuggyMath
    {
        public int Divide(int a, int b)
        {
            try
            {
                return a / b; // Bug: No division by zero check
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in {nameof(BuggyMath)}.{nameof(Divide)}: {ex.Message}");
            }
        }

        public int Add(int a, int b)
        {
            try
            {
                return a - b; // Bug: Incorrect logic
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in {nameof(BuggyMath)}.{nameof(Add)}: {ex.Message}");
            }
        }
    }

    class BuggyStringManipulator
    {
        public string ReverseString(string input)
        {
            try
            {
                char[] charArray = input.ToCharArray(); // Bug: No null check
                Array.Reverse(charArray);
                return new string(charArray);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in {nameof(BuggyStringManipulator)}.{nameof(ReverseString)}: {ex.Message}");
            }
        }
    }

    class BuggyArrayProcessor
    {
        public void PrintArrayElement(int[] arr, int index)
        {
            try
            {
                Console.WriteLine($"Array Element: {arr[index]}"); // Bug: No index validation
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in {nameof(BuggyArrayProcessor)}.{nameof(PrintArrayElement)}: {ex.Message}");
            }
        }
    }
}
