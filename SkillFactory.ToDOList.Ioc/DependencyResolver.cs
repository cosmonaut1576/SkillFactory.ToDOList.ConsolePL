using SkillFactory.ToDOList.BLL;
using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL;
using SkillFactory.ToDOList.DAL.Interface;
using System;

namespace SkillFactory.ToDOList.Ioc
{
    public static class DependencyResolver
    {
        private static ITaskDao taskDao { get; } = new TaskMemoryDao();
        public static ITaskLogic taskLogic { get; } = new TaskLogic(taskDao);
    }
}
