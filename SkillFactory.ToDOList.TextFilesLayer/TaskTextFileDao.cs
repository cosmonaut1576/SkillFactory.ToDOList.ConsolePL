using System.Collections.Generic;
using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using SkillFactory.ToDOList.TextFilesDAL;

namespace SkillFactory.ToDOList.TextFilesLayer
{
    public class TaskTextFileDao: ITextFiles
    {
        private TextFiles _textFiles;

        public void Add(Task task)
        {
            _textFiles.Add(task);
        }

        public void Remove(Task task)
        {
            _textFiles.Remove(task);
        }

        public List<string> GetAll()
        {
            return _textFiles.GetAll();
        }

        public string GetById(int id)
        {
            return _textFiles.GetByID(id);
        }

        public string GetByName(string name)
        {
            return _textFiles.GetByName(name);
        }
    }
}