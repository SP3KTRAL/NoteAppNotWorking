using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Методы, реализующие сохранения
    /// объекта «Проект» в файл и загрузки проекта из 
    /// файла.
    /// </summary>
    public static class ProjectManager
    {
        public static string appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string path = $@"{appdataFolder}\Belov\NoteApp\";

        /// <summary>
        /// Cериализация. Метод, сохраняющий объект «Проект» в файл.
        /// </summary>
        /// <param name="project"></param>
        public static void Save(Project project)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path + "notes.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Десериализация. Метод, загружающий проект из файла.
        /// </summary>
        public static Project Load(Project project)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(path + "notes.json"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            if (project == null)
            {
                project = new Project();
            }

            return project;
        }
    }
}
