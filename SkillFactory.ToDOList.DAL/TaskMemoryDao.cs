using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillFactory.ToDOList.DAL
{
    public class TaskMemoryDao : ITaskDao
    {

        public void Add(Task task)
        {
            int id = GetLastId() + 1;
            task.Id = id;
            MemoryDao.tasks.Add(id, task);
        }

        public int GetLastId()
        {
            int lastId;
            if (MemoryDao.tasks.Count == 0)
            {
                lastId = 0;
            }
            else
            {
                lastId = MemoryDao.tasks.Keys.Max();
            }
            return lastId;
        }

        public List<Task> GetAll()
        {
            return MemoryDao.tasks.Values.ToList();
        }

        public Task GetByID(int id)
        {
            if (!MemoryDao.tasks.TryGetValue(id, out var task))
            {
                return null;
            }

            return task;
        }
    }
}
