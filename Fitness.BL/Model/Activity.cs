using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Активность
    /// </summary>
    [Serializable]
    public class Activity
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Упражнения
        /// </summary>
        public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Расход калорий в минуту
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        #endregion

        #region Конструкторы
        public Activity() { }

        /// <summary>
        /// Создание новой активности
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caloriesPerMinute"></param>
        public Activity(string name, double caloriesPerMinute)
        {
            // проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
