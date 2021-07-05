using SkillFactory.ToDOList.BLL;
using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL;
using SkillFactory.ToDOList.TextFilesDAL;
using SkillFactory.ToDOList.DAL.Interface;
using System;

namespace SkillFactory.ToDOList.Ioc
{
    public static class DependencyResolver
    {
        private static ITaskDao TaskDao { get; }
        public static ITaskLogic TaskLogic { get; }

        static DependencyResolver()
        {
            IniSettings INI = new IniSettings(Environment.ExpandEnvironmentVariables(@"%userprofile%\Documents\config.ini"));
            INI.Write("Settings", "DALType", "2");
            int dalType = Convert.ToInt32(INI.ReadINI("Settings", "DALType"));
            if (dalType != 0)
            {
                if (dalType == 1)
                    TaskDao = new TaskMemoryDao();
                else if (dalType == 2)
                    TaskDao = new TaskXMLFilesDao();

                TaskLogic = new TaskLogic(TaskDao);

            }
        }
    
        
        //private static ITaskDao taskDao { get; } = new TaskMemoryDao();
        //private static ITaskDao TaskDao { get { return GetTaskDao(); } }
        

        //private static ITaskDao GetTaskDao() {
        //    IniSettings iniSet = new IniSettings();
        //    switch (iniSet._dalType)
        //    {
        //        case 1:
        //            return new TaskMemoryDao();
        //        case 2:
        //            return new TaskTextFilesDao();
        //        default:
        //            return new TaskMemoryDao();
        //    }
            //{
            //    get {
            //        return TaskDao;
            //    }
            //    set {

            //    }
            //}
            // = new TaskTextFilesDao();
        //}
    }
}
