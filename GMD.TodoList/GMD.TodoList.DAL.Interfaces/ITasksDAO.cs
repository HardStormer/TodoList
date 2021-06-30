using System.Collections.Generic;
using GMD.TodoList.Entities;

namespace GMD.TodoList.DAL.Interfaces
{
    public interface ITasksDAO
    {
        void AddTask(Task task);
        void RemoveTask(string name);
        IEnumerable<Task> GetAll();
        Task Find(string name);
        void DoneTask(string name);

    }
}
