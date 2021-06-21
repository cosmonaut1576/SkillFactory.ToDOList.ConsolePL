using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.DAL.Interface
{
    public interface ITaskDao
    {
        public void Add(Task task);
        public void Remove(Task task);
        public IEnumerable<Task> GetAll();
        public Task GetByID(int id);
        public Task GetByName(string name);
        public int GetLastId();
        public void ChangeStatus(int id);
    }
}
