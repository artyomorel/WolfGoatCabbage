﻿namespace ConsoleApp1
{
    public abstract class GameObject
    {

        public GameObject(string name)
        {
            _name = name;
        }
        private bool _onRightCoast = false;
        private readonly string _name;
        public void Move()
        {
            _onRightCoast = !_onRightCoast;
        }

        public bool GetPosition()
        {
            return _onRightCoast;
        }

        public string GetName()
        {
            return _name;
        }
        
    }
}