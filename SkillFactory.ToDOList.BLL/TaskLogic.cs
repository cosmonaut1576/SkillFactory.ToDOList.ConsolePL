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
        public void Add(Task task)
        {
            if(task.Name.Length <= 0)
            {
                throw new ArgumentException("Name is empty.");
            }
            MemoryDao.tasks.Add(_taskDao.GetLastId(), task);
        }

        public void Remove(Task task)
        {
            MemoryDao.tasks.Remove(task.Id, out task);
        }

        public List<Task> GetAll()
        {
            var list = new List<Task>();
            foreach (var task in MemoryDao.tasks)
            {
                list.Add(task.Value);
            }

            return list;

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
    }
}
