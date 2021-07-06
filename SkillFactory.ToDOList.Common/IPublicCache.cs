using System;
using System.Collections.Generic;
using System.Text;

namespace SkillFactory.ToDOList.Common
{
    interface IPublicCache
    {
        T GetOrCreate<T>(string key, Func<T> func);
        void Reset(string key);
    }
}
