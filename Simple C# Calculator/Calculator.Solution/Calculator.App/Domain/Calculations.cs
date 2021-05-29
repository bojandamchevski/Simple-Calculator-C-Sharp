

using System;
using System.IO;

namespace Calculator.App.Domain
{
    public class Calculations : BaseCalculations
    {
        public Calculations()
        {

        }

        public override double Difference(double FirstNumber, double SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }

        public override double Division(double FirstNumber, double SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }

        public override double Multiplication(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }

        public override double Percent(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * (SecondNumber / 100);
        }

        public override double Root(double FirstNumber)
        {
            return Math.Sqrt(FirstNumber);
        }

        public override double Square(double FirstNumber)
        {
            return Math.Pow(FirstNumber, 2);
        }

        public override double Sum(double FirstNumber, double SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
        public static void TextGenerator(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
        public void CalculateAction()
        {
            bool flag = true;
            while (flag)
            {
                double result = 0;
                Console.Clear();
                TextGenerator("Use: +, -, /, *, s (S), r (R), for operators.", ConsoleColor.Yellow);
                TextGenerator("Enter first number:\n", ConsoleColor.Yellow);
                bool inputFirstNumberValidation = double.TryParse(Console.ReadLine(), out double num1);

                TextGenerator("Enter operator:\n", ConsoleColor.Yellow);
                bool inputOperationValidation = char.TryParse(Console.ReadLine(), out char operation);

                if (inputFirstNumberValidation && inputOperationValidation)
                {
                    if (operation == 's' || operation == 'S')
                    {
                        result = Square(num1);
                    }
                    else if (operation == 'r' || operation == 'R')
                    {
                        result = Root(num1);
                    }
                    else
                    {

                        TextGenerator("Enter second number:\n", ConsoleColor.Yellow);
                        bool inputSecondNumberValidation = double.TryParse(Console.ReadLine(), out double num2);

                        if (inputSecondNumberValidation)
                        {
                            switch (operation)
                            {
                                case '-':
                                    result = Difference(num1, num2);
                                    break;
                                case '/':
                                    result = Division(num1, num2);
                                    break;
                                case '*':
                                    result = Multiplication(num1, num2);
                                    break;
                                case '%':
                                    result = Percent(num1, num2);
                                    break;
                                case '+':
                                    result = Sum(num1, num2);
                                    break;
                                default:
                                    TextGenerator("Error\n", ConsoleColor.Red);
                                    break;
                            }
                        }
                        else
                        {
                            TextGenerator("Invalid input. Try again.", ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }
                    TextGenerator($"The result is: {result}\n", ConsoleColor.Green);

                    string folderPath = @"..\..\..\Calculations";
                    string appPath = folderPath + @"\calculations.txt";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (!File.Exists(appPath))
                    {
                        File.Create(appPath).Close();
                    }

                    using (StreamWriter sw = new StreamWriter(appPath, true))
                    {
                        DateTime currentDate = DateTime.Now;
                        sw.WriteLine($"The result is: {result}\n{currentDate}\n");
                    }

                    TextGenerator("Press 1 to use the calculator again.\n", ConsoleColor.Cyan);
                    TextGenerator("Press 2 for previous data results.\n", ConsoleColor.Cyan);
                    TextGenerator("Press 3 to exit.\n", ConsoleColor.Cyan);

                    bool choiceFlag = true;

                    while (choiceFlag)
                    {

                        bool choiceValidation = int.TryParse(Console.ReadLine(), out int choice);

                        if (choiceValidation)
                        {
                            if (choice == 1)
                            {
                                flag = true;
                                choiceFlag = false;
                            }
                            else if (choice == 2)
                            {
                                using (StreamReader sr = new StreamReader(appPath))
                                {
                                    Console.Clear();
                                    TextGenerator("Previous data results:\n", ConsoleColor.Blue);
                                    string data = sr.ReadToEnd();
                                    Console.WriteLine(data);
                                }
                                TextGenerator("Press any key to continue:\n", ConsoleColor.Blue);
                                choiceFlag = false;
                                Console.ReadKey();
                            }
                            else if (choice == 3)
                            {
                                choiceFlag = false;
                                flag = false;
                            }
                        }
                        else
                        {
                            TextGenerator("Invalid input. Try again.", ConsoleColor.Red);
                        }
                    }
                }
                else
                {
                    TextGenerator("Invalid input. Try again.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }
    }
}
