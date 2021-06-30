using GMD.TodoList.BLL.Interfaces;
using GMD.TodoList.Entities;
using GMD.TodoList.DAL.Interfaces;
using GMD.TodoList.JsonDAL;
using System.Collections.Generic;

namespace GMD.TodoList.StandartBLL
{
    public class TasksLogic : ITasksLogic
    {
        private ITasksDAO _tasksDAO;

        public TasksLogic(ITasksDAO tasksDAO) => 
            _tasksDAO = tasksDAO;

        public void AddTask(Task task) => 
            _tasksDAO.AddTask(task);

        public void DoneTask(string name) =>
            _tasksDAO.DoneTask(name);

        public Task Find(string name) =>
            _tasksDAO.Find(name);

        public IEnumerable<Task> GetAll() =>
            _tasksDAO.GetAll();

        public void RemoveTask(string name) =>
            _tasksDAO.RemoveTask(name);

    }
}
