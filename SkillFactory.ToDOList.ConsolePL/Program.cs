﻿using SkillFactory.ToDOList.BLL;
using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL;
using SkillFactory.ToDOList.Ioc;
using System;

namespace SkillFactory.ToDOList.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            //PL всегда работает с логикой и только, иначе грубое нарушение
            //ITaskLogic taskLogic = new TaskLogic(new TaskDAO()); 

            //теперь PL не знает о реализации классов, он знает только об абстракциях
            //(интерфейсах) - принципы SOLID
            //зависимости - буква D (Dependency Inversion) - модули нижних уровней не должны зависеть от модулей верхних уровней
            var taskLogic = DependencyResolver.TaskLogic;
            //taskLogic.Add(new Entities.Task
            //{
            //    Name = "Отпраздновать заключение первого контракта",
            //    Priority = 0,
            //    Text = "Вы лучшие и пусть весь мир подождёт",
            //    Status = "В процессе"
            //});

            //string searchingName = Console.ReadLine();
            //var task = taskLogic.GetByName(searchingName);
            var task = taskLogic.GetByID(1);
            Console.WriteLine(task.Name + ". " + task.Text);
            taskLogic.ShowAll(taskLogic.GetAll());
            taskLogic.ChangeStatus(taskLogic.GetByID(8));
            //taskLogic.Remove(taskLogic.GetByID(5));
            taskLogic.ShowAll(taskLogic.SortByPriority());
        }
    }
}
