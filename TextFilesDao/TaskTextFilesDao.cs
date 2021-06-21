using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.TextFilesDAL
{
    public class TaskTextFilesDao : ITaskDao
    {
        readonly TextFilesDao textFile = new TextFilesDao();
        
        public void Add(Task task)
        {
            int id = GetLastId() + 1;
            task.Id = id;
            textFile.Add(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return textFile.GetTasks();
        }

        public Task GetByID(int id)
        {
            if(!textFile.TryGetValue(id, out var task))
                return null;

            return task;
        }

        public Task GetByName(string name)
        {
            if (!textFile.TryGetValue(name, out var task))
                return null;

            return task;
        }

        public int GetLastId()
        {
            return textFile.Max();
        }

        public void Remove(Task task)
        {
            textFile.Remove(task);
        }

        public void ChangeStatus(int id)
        {
            //if (task.Status == TaskStatus.taskInProcess)
            //{
            //    task.Status = TaskStatus.taskDone;
            //}
            textFile.ChangeStatus(id);
        }
    }
}
