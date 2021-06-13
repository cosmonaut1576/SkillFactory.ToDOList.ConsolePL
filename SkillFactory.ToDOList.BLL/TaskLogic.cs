using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

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
        public int Add(Task task)
        {
            if(task.Name.Length <= 0)
            {
                throw new ArgumentException("Name is empty.");
            }
            return _taskDao.Add(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskDao.GetAll();
        }

        public Task GetByID(int id)
        {
            return _taskDao.GetByID(id);
        }
    }
}
