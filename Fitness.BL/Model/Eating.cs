using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{    
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Время приема пищи
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }
        #endregion

        #region Конструкторы
        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        #endregion

        /// <summary>
        /// Добавить запись о приеме пищи
        /// </summary>
        /// <param name="food"> Еда </param>
        /// <param name="weight"> Вес </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.FoodName.Equals(food.FoodName));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
