using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Список активности
        /// </summary>
        public List<Activity> Activities { get; }

        /// <summary>
        /// Создание нового контроллера упражнений
        /// </summary>
        /// <param name="user"></param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Получить всю активность
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Добавить упражнение в список
        /// </summary>
        /// <param name="activity"> Активность </param>
        /// <param name="begin"> Начало упражнения </param>
        /// <param name="end"> Конец упражнения </param>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if(act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        /// <summary>
        /// Получить все упражнения
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Сохранить упражнения и активность
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
