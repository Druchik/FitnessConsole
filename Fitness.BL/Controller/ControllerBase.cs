using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataManager manager = new SerializableManager();

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="filename"> Имя файла </param>
        /// <param name="item"> Объект </param>
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        /// <summary>
        /// Загрузка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"> Имя файла </param>
        /// <returns></returns>
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
