using System;

namespace game{

abstract class Enemy : Character {
        public abstract int Health{get; set;}
        public abstract int Energy{get; set;}
        public abstract int Cost1{get; set;}

        public Enemy (string name) :base(name){
            Name = name;
        }

        public abstract void Attack(ref Player player);
        public abstract void Skip_Step();
        public abstract void After_Step();
    }
}