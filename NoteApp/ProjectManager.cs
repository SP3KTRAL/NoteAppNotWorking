using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджер проекта, реализующий методы сохранения
    /// объекта «Проект» в файл и загрузки проекта из 
    /// файла.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Cериализация. Метод, сохраняющий объект «Проект» в файл.
        /// </summary>
        /// <param name="project"></param>
        public static void Save(Project project)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"d:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
        /// <summary>
        /// Десериализация. Метод, загружающий проект из файла.
        /// </summary>
        public static void Load()
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(@"d:\json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }
        }
    }
}
