using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SkillFactory.ToDOList.DAL;

namespace SkillFactory.ToDOList.BLL
{
    public class TaskLogic : ITaskLogic
    {
        //из логики вызываем DAO
        private readonly ITaskDao _taskDao;

        public TaskLogic(ITaskDao taskDao)
        {
            _taskDao = taskDao;
        }

        public void Add(Task task)
        {
            if (task.Name.Length == 0)
            {
                throw new ArgumentException("Name is empty.");
            }

            _taskDao.Add(task);
        }

        public void Remove(Task task)
        {
            _taskDao.Remove(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskDao.GetAll();
        }

        public Task GetByName(string name)
        {
            //var result = MemoryDao.tasks.FirstOrDefault(o => o.Value.Name == name).Key;
            //return MemoryDao.tasks[result];
            //Task result = _taskDao.GetByName(name);
            //if (result != null)
            //    return result;
            //else 
            return _taskDao.GetByName(name);
        }

        public Task GetByID(int id)
        {
            //var result = MemoryDao.tasks.FirstOrDefault(o => o.Value.Id == id).Key;
            //return MemoryDao.tasks[result];
            return _taskDao.GetByID(id);
        }

        public List<Task> SortByPriority()
        {
            var sortedListOfTasks =
                GetAll().OrderBy(o => o.Priority).Select(p => p).ToList();
            //MemoryDao.tasks.OrderByDescending(o => o.Value.Priority).Select(p => p.Value).ToList();
            return sortedListOfTasks;
        }
        
        public List<Task> SortByExpireDateThenByPriority() //сортировка сначала по дате, затем по приоритету
        {
            var sortedListOfTasks =
                GetAll().OrderBy(o => o.ExpireDate.Day).ThenBy(z=> z.Priority).Select(p => p).ToList();
            return sortedListOfTasks;
        }

        public void ChangeStatus(Task task)
        {
            _taskDao.ChangeStatus(task.Id);
            //if (task.Status == TaskStatus.taskInProcess)
            //{
            //    task.Status = TaskStatus.taskDone;
            //}

            //return task;
        }

        public void ShowAll(IEnumerable<Task> tasks)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  Id   |             Name             |Priority|  Status  | Expire Date |            Text                 ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            foreach (Task item in tasks.ToList())
            {
                Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}", item.Id.ToString().PadLeft(4, ' ').PadRight(7, ' ').Substring(0, 7), item.Name.PadRight(30,' ').Substring(0, 30), item.Priority.ToString().PadLeft(4,' ').PadRight(8,' ').Substring(0, 8), item.Status.PadRight(10, ' '), item.Text.PadRight(100, ' ').Substring(0, 100), item.ExpireDate.ToString().PadLeft(4,' ').PadRight(10,' ').Substring(0, 10));
            }
        }
    }
}