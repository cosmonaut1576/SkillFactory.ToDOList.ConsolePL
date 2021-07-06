using System.Collections.Generic;
using SkillFactory.ToDOList.Entities;

namespace SkillFactory.ToDOList.DAL.Interface
{
    public interface ITextFiles
    {
        public void Add(Task task);
        public void Remove(Task task);
        public List<string> GetAll();
        public string GetById(int id);
        public string GetByName(string name);
    }
}