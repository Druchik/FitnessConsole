using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages",typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime(resourceManager.GetString("EnterBirthDate", culture));
                double weight = ParseDouble(resourceManager.GetString("EnterWeight", culture));
                double height = ParseDouble(resourceManager.GetString("EnterHeight", culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что Вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var (begin, end, activity) = EnterExercise();
                        exerciseController.Add(activity, begin, end);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("\nВведите название продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(food,calories,prots,fats,carbs);

            return (product, weight);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nНеверный формат.");
                }
            }
        }

        private static DateTime ParseDateTime(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("\nНекорректный ввод.");
                }
            }
        }
    }
}
