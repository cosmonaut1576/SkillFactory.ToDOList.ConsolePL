using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SkillFactory.ToDOList.DAL.Interface;
using SkillFactory.ToDOList.Entities;

namespace TExtFiesDao
{
    class TextFiles
    {
        private readonly string filePath = " ";
        public void Add(Task task)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(task.Id + task.Priority + task.Name + task.Text + task.Status + task.ExpireDate);
                }
            }
        }

        public void Remove(Task task)
        {
            var text = File.ReadAllLines(filePath).ToList();
            foreach (var taskLine in text)
            {
                if (taskLine.Contains(task.Name))
                {
                    text.Remove(taskLine);
                }
            }

            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var taskLineUpdated in text)
                {
                    sw.WriteLine(taskLineUpdated);
                }
            }
        }

        public List<string> GetAll()/*изменил возвращаемое значение, поскольку из файла мы возвращаем строки*/
        {
            var list = new List<string>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string tsk = " ";
                while ((tsk = sr.ReadLine()) != null)
                {
                    list.Add(tsk);
                }
            }
            return list;
        }

        public string GetByID(int id) /*изменил возвращаемое значение, поскольку из файла мы возвращаем строки*/
        {
            string taskById = " ";
            var text = File.ReadAllLines(filePath).ToList();
            foreach (var taskLine in text)
            {
                if (taskLine.StartsWith((char) id))
                {
                    taskById = taskLine;
                }
            }
            return taskById;
        }

        public string GetByName(string name) /*изменил возвращаемое значение, поскольку из файла мы возвращаем строки*/
        {
            string taskByName = " ";
            var text = File.ReadAllLines(filePath).ToList();
            foreach (var taskLine in text)
            {
                if (taskLine.Contains(name))
                {
                    taskByName = taskLine;
                }
            }
            return taskByName;
        }
    }
}