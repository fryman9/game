using System;

namespace game{

    abstract class Player : Character {
        public abstract int Health{get; set;}
        public abstract int Energy{get; set;}
        public abstract int Cost1{get; set;}
        public abstract int Cost2{get; set;}
        public abstract int Cost3{get; set;}
        private int strength = 0;
        public int Strength {
            get{return strength;}
            set {
                if (value<0){
                    Console.WriteLine("Не может быть отрицательного значения у характеристики");
                } else strength = value;
            }
        }
        private int defence = 0;    
        public int Defence {
            get {return defence;}
            set {
                if (value<0){
                    Console.WriteLine("Не может быть отрицательного значения у характеристики");
                } else defence = value;
            }
        }
        private int luck = 0;
        public int Luck {
            get{return luck;}
            set {
                if (value<0){
                    Console.WriteLine("Не может быть отрицательного значения у характеристики");
                } else luck = value;
            }
        }
        
        internal abstract void Attack1(ref Enemy enemy);
        internal abstract void Attack2(ref Enemy enemy);
        internal abstract void Attack3(ref Enemy enemy);
        internal abstract void Attack4(ref Enemy enemy);
        internal abstract void Skip_Step();
        internal abstract void After_Step();

        public Player (string name) :base (name) {
            Name = name;
        }
    }
}