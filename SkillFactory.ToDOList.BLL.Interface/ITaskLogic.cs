using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.BLL.Interface
{
    public interface ITaskLogic
    {
        public void AddTask(Task task);
        public void Remove(Task task);
        public IEnumerable<Task> GetAll();
        public Task GetByName(string name);
        public Task GetByID(int id);
        public List<Task> SortByPriority();
        public void ChangeStatus(Task task);
        public void ShowAll(IEnumerable<Task> tasks);
    }
}