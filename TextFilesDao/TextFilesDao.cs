using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkillFactory.ToDOList.TextFilesDAL
{
    public static class TextFilesDao
    {
        //public static Dictionary<int, Task> tasks = new Dictionary<int, Task>();

        static string path = @"C:\Users\BerezhnykhI\Documents\test.txt";

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

        public static void Add(Task task)
        {
            //int id = GetLastId() + 1;
            //task.Id = id;
            //MemoryDao.tasks.Add(id, task);
            //return id;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(name);
                    sw.WriteLine(mark1);
                    sw.WriteLine(mark2);
                    sw.WriteLine(mark3);
                }

                //using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                //{
                //    sw.WriteLine("Дозапись");
                //    sw.Write(4.5);
                //}
                //Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void Remove()
        {

        }
        public static void GetSortedListByPriority()
        {

        }

        public static IEnumerable<Task> GetAll()
        {
            //return MemoryDao.tasks.Values.ToList();
        }
Console.WriteLine("Нажмите Enter, чтобы продолжить, или Escape, чтобы выйти:\n");
                //key = Console.ReadKey();
            }

            int avg_mark1 = 0, avg_mark2 = 0, avg_mark3 = 0, temp = 0;
using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
{
    string line;
    int i = 0;
    while ((line = sr.ReadLine()) != null)
    {
        i++;

        switch (i % 4)
        {
            case 2:
                if (Int32.TryParse(line, out temp))
                {
                    avg_mark1 += temp;
                }
                break;
            case 3:
                if (Int32.TryParse(line, out temp))
                {
                    avg_mark2 += temp;
                }
                break;
            case 0:
                if (Int32.TryParse(line, out temp))
                {
                    avg_mark3 += temp;
                }
                break;
            default:
                break;
        }
    }

    sr.Close();

    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark1 / (i / 4), 2));
    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark2 / (i / 4), 2));
    Console.WriteLine("Средняя оценка качества услуг: {0}", System.Math.Round((decimal)avg_mark3 / (i / 4), 2));
}
    }
}
