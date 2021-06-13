using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.BLL.Interface
{
    public interface ITaskLogic
    {
        public int Add(Task task);
        public int Remove(Task task);
        public IEnumerable<Task> GetAll();
        public Task GetByName(string name);
    }
}