using System;


namespace Byui.Games.Services
{
    public class KeyboardKey
    {
        public static readonly KeyboardKey A = new KeyboardKey(65, "A");
        public static readonly KeyboardKey B = new KeyboardKey(66, "B");
        public static readonly KeyboardKey C = new KeyboardKey(67, "C");
        public static readonly KeyboardKey D = new KeyboardKey(68, "D");
        public static readonly KeyboardKey E = new KeyboardKey(69, "E");
        public static readonly KeyboardKey F = new KeyboardKey(70, "F");
        public static readonly KeyboardKey G = new KeyboardKey(71, "G");
        public static readonly KeyboardKey H = new KeyboardKey(72, "H");
        public static readonly KeyboardKey I = new KeyboardKey(73, "I");
        public static readonly KeyboardKey J = new KeyboardKey(74, "J");
        public static readonly KeyboardKey K = new KeyboardKey(75, "K");
        public static readonly KeyboardKey L = new KeyboardKey(76, "L");
        public static readonly KeyboardKey M = new KeyboardKey(77, "M");
        public static readonly KeyboardKey N = new KeyboardKey(78, "N");
        public static readonly KeyboardKey O = new KeyboardKey(79, "O");
        public static readonly KeyboardKey P = new KeyboardKey(80, "P");
        public static readonly KeyboardKey Q = new KeyboardKey(81, "Q");
        public static readonly KeyboardKey R = new KeyboardKey(82, "R");
        public static readonly KeyboardKey S = new KeyboardKey(83, "S");
        public static readonly KeyboardKey T = new KeyboardKey(84, "T");
        public static readonly KeyboardKey U = new KeyboardKey(85, "U");
        public static readonly KeyboardKey V = new KeyboardKey(86, "V");
        public static readonly KeyboardKey W = new KeyboardKey(87, "W");
        public static readonly KeyboardKey X = new KeyboardKey(88, "X");
        public static readonly KeyboardKey Y = new KeyboardKey(89, "Y");
        public static readonly KeyboardKey Z = new KeyboardKey(90, "Z");
        public static readonly KeyboardKey One = new KeyboardKey(49, "1");
        public static readonly KeyboardKey Two = new KeyboardKey(50, "2");
        public static readonly KeyboardKey Three = new KeyboardKey(51, "3");
        public static readonly KeyboardKey Four = new KeyboardKey(52, "4");
        public static readonly KeyboardKey Five = new KeyboardKey(53, "5");
        public static readonly KeyboardKey Six = new KeyboardKey(54, "6");
        public static readonly KeyboardKey Seven = new KeyboardKey(55, "7");
        public static readonly KeyboardKey Eight = new KeyboardKey(56, "8");
        public static readonly KeyboardKey Nine = new KeyboardKey(57, "9");
        public static readonly KeyboardKey Zero = new KeyboardKey(48, "0");
        public static readonly KeyboardKey Down = new KeyboardKey(40, "Down");
        public static readonly KeyboardKey Enter = new KeyboardKey(13, "Enter");
        public static readonly KeyboardKey Escape = new KeyboardKey(27, "Escape");
        public static readonly KeyboardKey Left = new KeyboardKey(37, "Left");
        public static readonly KeyboardKey Right = new KeyboardKey(39, "Right");
        public static readonly KeyboardKey Space = new KeyboardKey(32, "Space");
        public static readonly KeyboardKey Up = new KeyboardKey(38, "Up");
        
        private int _code;
        private string _name;
        
        public KeyboardKey(int code, string name)
        {
            _code = code;
            _name = name;
        }

        public bool Equals(KeyboardKey other)
        {
            return other != null 
                && _code == other._code 
                && _name == other._name;
        }

        public override bool Equals(object other)
        {
            return Equals(other as KeyboardKey);
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
            return $"KeyboardKey (code: {_code}, name: {_name})";
        }
    }
}