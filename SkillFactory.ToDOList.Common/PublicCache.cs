using System;
using System.Collections.Generic;

namespace SkillFactory.ToDOList.Common
{
    public class PublicCache : IPublicCache
    {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();
        public T GetOrCreate<T>(string key, Func<T> func)
        {
            if (dictionary.TryGetValue(key, out var value))//get
                return (T)value;
            else//create
            {
                var item = func.Invoke();
                dictionary.Add(key, item);
                return item;
            }
        }

        public void Reset(string key)
        {
            dictionary.Remove(key);
        }
    }
}
