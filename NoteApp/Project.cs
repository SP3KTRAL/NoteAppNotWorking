using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта, содержащий список всех заметок.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Возвращает и задаёт заметки.
        /// </summary>
        public List<Note> Notes { get; set; }
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Project()
        {
            Notes = new List<Note>();
        }
    }
}
