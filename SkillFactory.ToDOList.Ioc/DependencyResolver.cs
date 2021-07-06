using SkillFactory.ToDOList.BLL;
using SkillFactory.ToDOList.BLL.Interface;
using SkillFactory.ToDOList.DAL;
using SkillFactory.ToDOList.TextFilesDAL;
using SkillFactory.ToDOList.DAL.Interface;
using System;
using SkillFactory.ToDOList.Entities.Configuration;
using SkillFactory.ToDOList.Common;
using SkillFactory.ToDOList.TextFilesLayer;

namespace SkillFactory.ToDOList.Ioc
{
    public class DependencyResolver
    {
        private ITaskDao _taskDao { get; }
        private PublicCache _publicCache { get; }
        private ITextFiles _textFiles { get; }
       public ITaskLogic TaskLogic { get; }
        

        public DependencyResolver(ConfigurationDAL configurationDAL)
        {
            _taskDao = GetTaskDaoByType(configurationDAL.Type);
            _publicCache = new PublicCache();
            _textFiles = new TaskTextFileDao();

            TaskLogic = new TaskLogic(_taskDao, _publicCache, _textFiles);
            //IniSettings INI = new IniSettings(Environment.ExpandEnvironmentVariables(@"%userprofile%\Documents\config.ini"));
            //INI.Write("Settings", "DALType", "2");
            //int dalType = Convert.ToInt32(INI.ReadINI("Settings", "DALType"));
            //if (dalType != 0)
            //{
            //    if (dalType == 1)
            //        TaskDao = new TaskMemoryDao();
            //    else if (dalType == 2)
            //        TaskDao = new TaskXMLFilesDao();

            //    TaskLogic = new TaskLogic(TaskDao);
            //}


        }

        private ITaskDao GetTaskDaoByType(TypeOfDao typeOfDao)
        {
            switch (typeOfDao)
            {
                case TypeOfDao.File:
                    return new TaskXMLFilesDao();
                case TypeOfDao.Memory:
                    return new TaskMemoryDao();
                default:
                    throw new ArgumentException
                        ("Can't resolve type for TaskDao!");
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
