using System;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Создать новый тип
        /// </summary>
        /// <param name="name"> Имя пола. </param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
