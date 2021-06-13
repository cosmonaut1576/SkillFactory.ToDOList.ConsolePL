using SkillFactory.ToDOList.BLL;
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
            var taskLogic = DependencyResolver.taskLogic;

            var id = taskLogic.Add(new Entities.Task
            {
                Name = "Написать ПО",
                Priority = 1,
                Text = "Дедлайн горит, чем быстрее, тем лучше"
            });

            string searchingName = Console.ReadLine();
            var task = taskLogic.GetByName(searchingName);

            Console.WriteLine(task.Name + ". " + task.Text);
        }
    }
}
