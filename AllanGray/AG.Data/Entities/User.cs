﻿namespace AG.Data.Entities
{
    public class User
    {
        public string  Name { get; private set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
