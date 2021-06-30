using System.Collections.Generic;
using GMD.TodoList.Entities;

namespace GMD.TodoList.BLL.Interfaces
{
    public interface ITasksLogic
    {
        void AddTask(Task tasks);

        void RemoveTask(string name);

        IEnumerable<Task> GetAll();

        Task Find(string name);

        void DoneTask(string name);

    }
}
