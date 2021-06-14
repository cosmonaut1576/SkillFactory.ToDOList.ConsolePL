using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.BLL.Interface
{
    public interface ITaskLogic
    {
        public void Add(Task task);
        public void Remove(Task task);
        public List<Task> GetAll();
        public Task GetByName(string name);
        public Task GetByID(int id);
    }
}