using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; } 

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории на 100гр продукта
        /// </summary>
        public double Calories { get; set; }
        #endregion

        #region Конструкторы
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO Проверка

            FoodName = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        #endregion

        public override string ToString()
        {
            return FoodName;
        }
    }
}
