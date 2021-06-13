using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.DAL.Interface
{
    public interface ITaskDao
    {
        public int Add(Task task);
        public IEnumerable<Task> GetAll();
        public Task GetByID(int id);
    }
}
