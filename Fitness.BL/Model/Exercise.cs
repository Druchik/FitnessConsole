using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Упражнение
    /// </summary>
    [Serializable]
    public class Exercise
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Начало упражнения
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Конец упражнения
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// ID активности
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Упражнение
        /// </summary>
        public virtual Activity Activity { get; set; }

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
        public Exercise() { }

        /// <summary>
        /// Создание нового упражнения
        /// </summary>
        /// <param name="start"> Начало </param>
        /// <param name="finish"> Конец </param>
        /// <param name="activity"> Упражнение </param>
        /// <param name="user"> Пользователь </param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
        #endregion
    }
}
