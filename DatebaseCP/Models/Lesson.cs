﻿namespace DatebaseCP.Models
{
    class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public Lesson(bool isSelected = false)
        {
            IsSelected = isSelected;
        }

        public Lesson(int id, string name, bool isSelected = false) : this(isSelected)
        {
            Id = id;
            Name = name;
        }
    }
}
