using System;


namespace Byui.Games.Services
{
    public class MouseButton
    {
        public static readonly MouseButton Left = new MouseButton(0, "Left");
        public static readonly MouseButton Middle = new MouseButton(1, "Middle");
        public static readonly MouseButton Right = new MouseButton(2, "Right");
        public static readonly MouseButton Side = new MouseButton(3, "Side");

        private int _code;
        private string _name;
        
        public MouseButton(int code, string name)
        {
            _code = code;
            _name = name;
        }

        public bool Equals(MouseButton other)
        {
            return other != null 
                && _code == other._code 
                && _name == other._name;
        }

        public override bool Equals(object other)
        {
            return Equals(other as MouseButton);
        }

        public int GetCode()
        {
            return _code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_code, _name);
        }

        public string GetName()
        {
            return _name;
        }

        public override string ToString()
        {
            return $"MouseButton (code: {_code}, name: {_name})";
        }
    }
}