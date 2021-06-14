using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.DAL.Interface
{
    public interface ITaskDao
    {
        public void Add(Task task);
        public void Remove(Task task);
        public List<Task> GetAll();
        public Task GetByID(int id);
        public int GetLastId();
    }
}
