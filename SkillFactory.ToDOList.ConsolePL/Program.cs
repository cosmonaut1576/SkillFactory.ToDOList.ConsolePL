using Microsoft.Extensions.Configuration;
using SkillFactory.ToDOList.BLL;
using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL;
using SkillFactory.ToDOList.Entities.Configuration;
using SkillFactory.ToDOList.Ioc;
using System;
using System.IO;

namespace SkillFactory.ToDOList.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

            var configurationDal = configuration.GetSection("configurationDal").Get<ConfigurationDAL>();
            var dr = new DependencyResolver(configurationDal);
            //PL всегда работает с логикой и только, иначе грубое нарушение
            //ITaskLogic taskLogic = new TaskLogic(new TaskDAO()); 

            //теперь PL не знает о реализации классов, он знает только об абстракциях
            //(интерфейсах) - принципы SOLID
            //зависимости - буква D (Dependency Inversion) - модули нижних уровней не должны зависеть от модулей верхних уровней
            var random = new Random();
            var taskLogic = dr.TaskLogic;
            taskLogic.Add(new Entities.Task
            {
                Name = "Отпраздновать заключение первого контракта",
                Priority = 0,
                Text = "Вы лучшие и пусть весь мир подождёт",
                Status = "В процессе",
                ExpireDate = System.DateTime.Now.AddDays(random.Next(1, 7)).Date
            });

            //string searchingName = Console.ReadLine();
            //var task = taskLogic.GetByName(searchingName);
            var task = taskLogic.GetByID(1);
            Console.WriteLine(task.Name + ". " + task.Text);
            taskLogic.ShowAll(taskLogic.GetAll());
            //taskLogic.ChangeStatus(taskLogic.GetByID(8)); !!!поправить вывод если не найдена задача - в методах если приходит task проверку на Null добавить

            taskLogic.ChangeStatus(taskLogic.GetByID(1));
            //taskLogic.Remove(taskLogic.GetByID(5));
            taskLogic.ShowAll(taskLogic.SortByPriority());
            taskLogic.ShowAll(taskLogic.SortByExpireDateThenByPriority());
        }
    }
}
