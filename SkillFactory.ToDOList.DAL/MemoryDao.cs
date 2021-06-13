using SkillFactory.ToDOList.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillFactory.ToDOList.DAL
{
    public static class MemoryDao
    {
        public static Dictionary<int, Task> tasks = new Dictionary<int, Task>();
    }
}
