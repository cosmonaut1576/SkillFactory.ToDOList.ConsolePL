using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SkillFactory.ToDOList.DAL;

namespace SkillFactory.ToDOList.BLL
{
    public class TaskLogic : ITaskLogic
    {
        //из логики вызываем DAO
        private readonly ITaskDao _taskDao;

        public TaskLogic(ITaskDao taskDao)
        {
            _taskDao = taskDao;
        }

        public void AddTask(Task task)
        {
            if (task.Name.Length == 0)
            {
                throw new ArgumentException("Name is empty.");
            }

            _taskDao.AddTask(task);
        }

        public void Remove(Task task)
        {
            _taskDao.Remove(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskDao.GetAll();
        }

        public Task GetByName(string name)
        {
            var result = MemoryDao.tasks.FirstOrDefault(o => o.Value.Name == name).Key;
            return MemoryDao.tasks[result];
        }

        public Task GetByID(int id)
        {
            var result = MemoryDao.tasks.FirstOrDefault(o => o.Value.Id == id).Key;
            return MemoryDao.tasks[result];
        }

        public List<Task> SortByPriority()
        {
            var sortedListOfTasks =
                MemoryDao.tasks.OrderByDescending(o => o.Value.Priority).Select(p => p.Value).ToList();
            return sortedListOfTasks;
        }

        public Task ChangeStatus(Task task)
        {
            if (task.Status == TaskStatus.taskInProcess)
            {
                task.Status = TaskStatus.taskDone;
            }

            return task;
        }
    }
}