using GMD.TodoList.BLL.Interfaces;
using GMD.TodoList.StandartBLL;
using GMD.TodoList.DAL.Interfaces;
using GMD.TodoList.JsonDAL;

namespace GMD.TodoList.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;
        public static DependencyResolver Instance => _instance ??= new DependencyResolver();

        #endregion

        public ITasksDAO tasksDAO => new TasksJsonDAO();

        public ITasksLogic tasksLogic => new TasksLogic(tasksDAO);
    }
}
