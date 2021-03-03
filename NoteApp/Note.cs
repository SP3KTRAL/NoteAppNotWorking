using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о названии, категории
    /// заметки, тексте заметки, дате создания и дате последнего
    /// изменения.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _titles;
        /// <summary>
        /// Дата создания заметки.
        /// </summary>
        private DateTime _creation;
        /// <summary>
        /// Дата сохранения заметки.
        /// </summary>
        private DateTime _modified;
        /// <summary>
        /// Возвращает и задаёт название заметки.
        /// </summary>
        public string Titles
        {
            get
            {
                return _titles;
            }
            set
            {

                if (value.Length == 0)
                {
                    value = "Без названия";
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Название " +
                                                "не должно превышать 50 символов");
                }

                _titles = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт категорию заметки.
        /// </summary>
        public NoteCategory NoteCategory { get; set; }
        /// <summary>
        /// Возвращает и задаёт текст заметки.
        /// </summary>
        public string NoteText { get; set; }
        /// <summary>
        /// Возвращает время создания.
        /// </summary>
        public DateTime Creation
        {
            get
            {
                return _creation;
            }
            private set
            {
                _creation = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт время последнего изменения.
        /// </summary>
        public DateTime Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
            }
        }
        /// <summary>
        /// Конструктор, задающий время создания.
        /// </summary>
        public Note()
        {
            _creation = DateTime.Now;
        }
    }
}
