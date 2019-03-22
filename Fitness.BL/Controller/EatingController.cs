using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Логика приема пищи
    /// </summary>
    public class EatingController : ControllerBase
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Продукты
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Еда
        /// </summary>
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавить информацию о продукте и весе
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.FoodName == food.FoodName);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Загрузить еду
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        /// <summary>
        /// Сохранить продукты
        /// </summary>
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() {Eating});
        }

        /// <summary>
        /// Получить список продуктов
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
    }
}
