using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.TextFilesDAL
{
    public class TaskXMLFilesDao : ITaskDao
    {
        readonly XMLFilesDao _xmlFile = new XMLFilesDao();
        
        public void Add(Task task)
        {
            int id = GetLastId() + 1;
            task.Id = id;
            _xmlFile.Add(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _xmlFile.GetTasks();
        }

        public Task GetByID(int id)
        {
            if(!_xmlFile.TryGetValue(id, out var task))
                return null;

            return task;
        }

        public Task GetByName(string name)
        {
            if (!_xmlFile.TryGetValue(name, out var task))
                return null;

            return task;
        }

        public int GetLastId()
        {
            return _xmlFile.Max();
        }

        public void Remove(Task task)
        {
            _xmlFile.Remove(task);
        }

        public void ChangeStatus(int id)
        {
            //if (task.Status == TaskStatus.taskInProcess)
            //{
            //    task.Status = TaskStatus.taskDone;
            //}
            _xmlFile.ChangeStatus(id);
        }
    }
}
