using System;

namespace game{

    class Goblin: Enemy{
        internal int cost1 = 50;

        public override int Cost1{
            get{
                return cost1;
            }
            set{
                cost1=value;
            }
        }
        private int health;
        public override int Health {
            get{
                return health;
            }
            set{
                if (value< 0) health=0;
                else health=value;
            }
        }
        private int energy;
        public override int Energy {
            get{
                return energy;
            }
            set{
                if (value< 0) energy=0;
                else energy=value;
            }
        }

        public Goblin (string name, int health, int energy) : base(name){
            Name=name;
            Health=health;
            Energy=energy;
        }
        public Goblin (string name) : base(name){
            Name = name;
            Health = 100;
            Energy = 100;
        }

        public override void Attack(ref Player player){
            player.Health-=(int) Math.Round((50/(((double)player.Defence/100)+1)));
            player.Energy-=(int) Math.Round((25/(((double)player.Defence/100)+1)));
            Energy-=cost1;
        }

        public override void Skip_Step(){
            Energy=(int) Math.Round((double)((Energy*0.25)+1));
            Health=(int) Math.Round((double)((Health*0.1)+1));
            Console.WriteLine("\nПротивник пропустил ход...\n");
        }
        public override void After_Step(){
            Energy+=50;
        }

    }
}