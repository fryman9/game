using System;

namespace game{

    abstract class Character {
        private string name;
        public string Name {
            get {
                return name;
            }
            set{
                if(value.Length>16){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректное имя персонажа");
                    Console.WriteLine("Имя персонажа не должно превышать 16 символов");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                } else name=value;
            }
            }
        public Character(string name){
            Name = name;
        }
    }
}