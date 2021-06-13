using System;

namespace SkillFactory.ToDOList.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Text { get; set; }
        public string IdStatus { get; set; }
    }
}
