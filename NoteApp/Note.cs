using System;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о названии, категории
    /// заметки, тексте заметки, дате создания и дате последнего
    /// изменения.
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _title;

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _noteCategory;

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _noteText;

        /// <summary>
        /// Дата создания заметки.
        /// </summary>
        private DateTime _created;

        /// <summary>
        /// Дата сохранения заметки.
        /// </summary>
        private DateTime _modified;

        /// <summary>
        /// Возвращает и задаёт название заметки.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {

                if (value.Length == 0)
                {
                    value = "Без названия";
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException($"The name should not exceed 50 characters, but it was: { value.Length }!");
                }

                _title = value;
                _modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задаёт категорию заметки.
        /// </summary>
        public NoteCategory NoteCategory
        {
            get
            {
                return _noteCategory;
            }
            set
            {
                _noteCategory = value;
                _modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задаёт текст заметки.
        /// </summary>
        public string NoteText
        {
            get
            {
                return _noteText;
            }
            set
            {
                _noteText = value;
                _modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задаёт время последнего изменения.
        /// </summary>
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        /// <summary>
        /// Возвращает время создания.
        /// </summary>
        public DateTime Created
        {
            get { return _created; }
            private set { _created = value; }
        }

        /// <summary>
        /// Конструктор, задающий время создания.
        /// </summary>
        public Note()
        {
            _modified = DateTime.Now;
            _created = DateTime.Now;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
