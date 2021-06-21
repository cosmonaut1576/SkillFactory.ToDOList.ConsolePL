using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SkillFactory.ToDOList.TextFilesDAL
{
    public class TextFilesDao
    {
        public TextFilesDao()
        {
            GetTasks();
        }

        public Dictionary<int, Task> _cache = new Dictionary<int, Task>();
        string _path = Environment.ExpandEnvironmentVariables(@"%userprofile%\Documents\tasks.txt");
        public IEnumerable<Task> GetTasks()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    Task task = null;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Id")
                        {
                            if (_cache.TryGetValue(Int32.Parse(childnode.InnerText), out var _temp))
                                break;
                            task = new Task();
                            task.Id = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "Name")
                            task.Name = childnode.InnerText;
                        if (childnode.Name == "Priority")
                            task.Priority = Int32.Parse(childnode.InnerText);
                        if (childnode.Name == "Text")
                            task.Text = childnode.InnerText;
                        if (childnode.Name == "Status")
                            task.Status = childnode.InnerText;
                    }
                    if(task != null)
                        _cache.Add(task.Id, task);
                }
            }
            catch (FileNotFoundException e_f)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }
            
            
            return _cache.Values.ToList();
        }
        public void Add(Task task)
        {
            _cache.Add(task.Id, task);

            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;
            }
            catch (FileNotFoundException e_f)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }

            XmlElement taskElem = xDoc.CreateElement("task");

            XmlElement idElem = xDoc.CreateElement("Id");
            XmlText idText = xDoc.CreateTextNode(task.Id.ToString());
            idElem.AppendChild(idText);

            XmlElement nameElem = xDoc.CreateElement("Name");
            XmlText nameText = xDoc.CreateTextNode(task.Name);
            nameElem.AppendChild(nameText);
            
            XmlElement priorityElem = xDoc.CreateElement("Priority");
            XmlText priorityText = xDoc.CreateTextNode(task.Priority.ToString());
            priorityElem.AppendChild(priorityText);
            
            XmlElement textElem = xDoc.CreateElement("Text");
            XmlText textText = xDoc.CreateTextNode(task.Text);
            textElem.AppendChild(textText);
            
            XmlElement statusElem = xDoc.CreateElement("Status");
            XmlText statusText = xDoc.CreateTextNode(task.Status);
            statusElem.AppendChild(statusText);

            taskElem.AppendChild(idElem);
            taskElem.AppendChild(nameElem);
            taskElem.AppendChild(priorityElem);
            taskElem.AppendChild(textElem);
            taskElem.AppendChild(statusElem);

           /* if(xDoc.DocumentElement == null)
                xDoc.AppendChild(taskElem);
            else
                xDoc.DocumentElement.AppendChild(taskElem);*/
            xRoot.AppendChild(taskElem);

            xDoc.Save(_path);
        }
        public void Remove(Task task)
        {
            if (task != null)
            {
                _cache.Remove(task.Id);

                XmlDocument xDoc = new XmlDocument();
                try
                {
                    xDoc.Load(_path);
                }
                catch (FileNotFoundException e_f)
                {
                    XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement xRoot = xDoc.CreateElement("tasks");
                    xDoc.AppendChild(xRoot);
                    xDoc.InsertBefore(xmlDeclaration, xRoot);
                    xDoc.Save(_path);
                }
                XmlNode nodeToDelete = xDoc.SelectSingleNode("/tasks/task[Id=" + task.Id + "]");
                if (nodeToDelete != null)
                {
                    nodeToDelete.ParentNode.RemoveChild(nodeToDelete);
                    xDoc.Save(_path);
                }
            }
        }

        public int Count()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;
            }
            catch (FileNotFoundException e_f)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }
            return xRoot.ChildNodes.Count;
        }

        public int Max()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;

                XmlNode lastNode = xDoc.DocumentElement.LastChild;
                if (lastNode == null)
                    return 0;
                foreach (XmlNode childnode in lastNode.ChildNodes)
                {
                    if (childnode.Name == "Id")
                    {
                        return Int32.Parse(childnode.InnerText);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }
            //catch (NullReferenceException)
            //{
            //}
            Console.WriteLine("error");
            return 0;
        }
        public bool TryGetValue(string name, out Task task)
        {
            foreach (Task item in _cache.Values.ToList())
            {
                if (item.Name == name)
                {
                    task = item;
                    return true;
                }
            }

            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;
            }
            catch (FileNotFoundException e_f)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }
            Task _task = null;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name" && childnode.InnerText != name)
                        break;
                    else
                    {
                        _task = new Task();
                        _task.Name = childnode.InnerText;
                        if (childnode.Name == "Id")
                            _task.Id = Int32.Parse(childnode.InnerText);
                        if (childnode.Name == "Priority")
                            _task.Priority = Int32.Parse(childnode.InnerText);
                        if (childnode.Name == "Text")
                            _task.Text = childnode.InnerText;
                        if (childnode.Name == "Status")
                            _task.Status = childnode.InnerText;
                    }
                }
                if (_task != null)
                {
                    task = _task;
                    return true;
                }
            }
            task = null;
            return false;
        }

        public bool TryGetValue(int id, out Task task)
        {
            if (_cache.TryGetValue(id, out task))
                return true;
            else
            {
                XmlDocument xDoc = new XmlDocument();
                XmlElement xRoot;
                try
                {
                    xDoc.Load(_path);
                    xRoot = xDoc.DocumentElement;
                }
                catch (FileNotFoundException e_f)
                {
                    XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xRoot = xDoc.CreateElement("tasks");
                    xDoc.AppendChild(xRoot);
                    xDoc.InsertBefore(xmlDeclaration, xRoot);
                    xDoc.Save(_path);
                }
                Task _task = null;
                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Id" && Int32.Parse(childnode.InnerText) != id)
                            break;
                        else
                        {
                            _task = new Task();
                            _task.Id = Int32.Parse(childnode.InnerText);
                            if (childnode.Name == "Name")
                                _task.Name = childnode.InnerText;
                            if (childnode.Name == "Priority")
                                _task.Priority = Int32.Parse(childnode.InnerText);
                            if (childnode.Name == "Text")
                                _task.Text = childnode.InnerText;
                            if (childnode.Name == "Status")
                                _task.Status = childnode.InnerText;
                        }
                    }
                    if (_task != null)
                    {
                        task = _task;
                        return true;
                    }
                }
                return false;
            }
        }

        public void ChangeStatus(int id)
        {
            Task task = null;
            if (_cache.TryGetValue(id, out task))
                task.Status = TaskStatus.taskDone;

            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot;
            try
            {
                xDoc.Load(_path);
                xRoot = xDoc.DocumentElement;
            }
            catch (FileNotFoundException e_f)
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xRoot = xDoc.CreateElement("tasks");
                xDoc.AppendChild(xRoot);
                xDoc.InsertBefore(xmlDeclaration, xRoot);
                xDoc.Save(_path);
            }

            bool isFinished = false;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Id" && Int32.Parse(childnode.InnerText) != id)
                        break;
                    else
                    {
                        if (childnode.Name == "Status")
                        {
                            childnode.InnerText = TaskStatus.taskDone;
                            isFinished = true;
                            xDoc.Save(_path);
                        }
                    }
                }
                if (isFinished)
                    break;
            }
        }
    }
}

            

        //ConsoleKeyInfo key;

        //Console.WriteLine("Нажмите Enter, чтобы продолжить, или Escape, чтобы выйти:\n");
        //    while (Console.ReadKey(true).Key != ConsoleKey.Escape)  
        //    {
        //        Console.Write("Введите ФИО:");
        //        string name = Console.ReadLine();
        //Console.Write("Введите оценку качества услуг:");
        //        string mark1 = Console.ReadLine();
        //Console.Write("Введите оценку скорости обслуживания:");
        //        string mark2 = Console.ReadLine();
        //Console.Write("Введите оценку доброжелательности персонала:");
        //        string mark3 = Console.ReadLine();

//        public static void Add(Task task)
//        {
//            //int id = GetLastId() + 1;
//            //task.Id = id;
//            //MemoryDao.tasks.Add(id, task);
//            //return id;
//            try
//            {
//                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
//                {
//                    sw.WriteLine(name);
//                    sw.WriteLine(mark1);
//                    sw.WriteLine(mark2);
//                    sw.WriteLine(mark3);
//                }

//                //using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
//                //{
//                //    sw.WriteLine("Дозапись");
//                //    sw.Write(4.5);
//                //}
//                //Console.WriteLine("Запись выполнена");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }

//        }
//        public static void Remove()
//        {

//        }
//        public static void GetSortedListByPriority()
//        {

//        }

//        public static IEnumerable<Task> GetAll()
//        {
//            //return MemoryDao.tasks.Values.ToList();
//        }
//Console.WriteLine("Нажмите Enter, чтобы продолжить, или Escape, чтобы выйти:\n");
//                //key = Console.ReadKey();
//            }

//            int avg_mark1 = 0, avg_mark2 = 0, avg_mark3 = 0, temp = 0;
//using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
//{
//    string line;
//    int i = 0;
//    while ((line = sr.ReadLine()) != null)
//    {
//        i++;

//        switch (i % 4)
//        {
//            case 2:
//                if (Int32.TryParse(line, out temp))
//                {
//                    avg_mark1 += temp;
//                }
//                break;
//            case 3:
//                if (Int32.TryParse(line, out temp))
//                {
//                    avg_mark2 += temp;
//                }
//                break;
//            case 0:
//                if (Int32.TryParse(line, out temp))
//                {
//                    avg_mark3 += temp;
//                }
//                break;
//            default:
//                break;
//        }
//    }

//    sr.Close();

//    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark1 / (i / 4), 2));
//    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark2 / (i / 4), 2));
//    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark3 / (i / 4), 2));
//}
