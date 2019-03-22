using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class DatabaseDataManager : IDataManager
    {
        /// <summary>
        /// Загрузка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(t => true).ToList();
            }
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
