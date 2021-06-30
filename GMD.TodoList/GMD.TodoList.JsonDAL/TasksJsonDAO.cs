using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GMD.TodoList.DAL.Interfaces;
using GMD.TodoList.Entities;
using Newtonsoft.Json;

namespace GMD.TodoList.JsonDAL
{
    public class TasksJsonDAO : ITasksDAO
    {
        public string JSON_FILE_PATH = Path.Combine(Environment.CurrentDirectory, "data.json");

        

        private void Start()
        {
            if (!File.Exists(JSON_FILE_PATH))
            {
                try
                {
                    File.WriteAllText(JSON_FILE_PATH, "[]");
                }
                catch
                {
                    throw;
                }
            
            }
        }
        private string Serialized(object tasks)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            return json;
        }

        private List<Task> Deserialize()
        {
            Start();
            List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(JSON_FILE_PATH));
            return tasks;
        }

        private void Save(string json)
        {
            File.WriteAllText(JSON_FILE_PATH, json);
        }

        public void AddTask(Entities.Task task)
        {
            List<Task> tasks = Deserialize();

            tasks.Add(task);

            var sorted = tasks.OrderBy(o => o.Priority).ToList();

            Save(Serialized(sorted));
        }

        public void RemoveTask(Guid id)
        {
            List<Task> tasks = Deserialize();

            for (int i = 0; i < tasks.Count; ++i)
                if (tasks[i].ID == id)
                    tasks.RemoveAt(i);

            Save(Serialized(tasks));
        }
        public void RemoveTask(string name)
        {
            List<Task> tasks = Deserialize();

            for (int i = 0; i < tasks.Count; ++i)
                if (tasks[i].Name == name)
                    tasks.RemoveAt(i);

            Save(Serialized(tasks));
        }

        public IEnumerable<Task> GetAll()
        {
            List<Task> tasks = Deserialize();
            return tasks;
        }

        public Task Find(string name)
        {
            List<Task> tasks = Deserialize();
            for (int i = 0; i < tasks.Count; ++i)
            {
                if (tasks[i].Name == name)
                    return tasks[i];
            }
            return null;
          
        }

        public void DoneTask(string name)
        {
            List<Task> tasks = Deserialize();
            for (int i = 0; i < tasks.Count; ++i)
            {
                if (tasks[i].Name == name)
                    tasks[i].Done = true;
            }

            Save(Serialized(tasks));
        }
    }
}
