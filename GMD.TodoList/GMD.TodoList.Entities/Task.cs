using System;

namespace GMD.TodoList.Entities
{
    [Serializable]
    public class Task
    {
        public Task(string name, int priority, string text, Guid id, bool done)
        {
            ID = id;
            Name = name;
            Priority = priority;
            Text = text;
            CreationDate = DateTime.Now;
            Done = done;
        }

        public Guid ID { get; private set; }

        public string Name { get; private set; }

        public int Priority { get; private set; }

        public string Text { get; private set; }

        public DateTime CreationDate { get; }

        public bool Done { get; set; }

    }
}
