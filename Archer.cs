using System;

namespace game{

    class Archer : Player {
        Random rnd = new Random();
        bool cond_energy = false;
        private int cost1 = 75;
        private int cost2 = 125;
        private int cost3 = 200;
        public override int Cost1{
            get{
                return cost1;
            }
            set{
                cost1=value;
            }
        }
        public override int Cost2{
            get{
                return cost2;
            }
            set{
                cost2=value;
            }
        }
        public override int Cost3{
            get{
                return cost3;
            }
            set{
                cost3=value;
            }
        }
        private int health = 200;
        public override int Health {
            get{return health;}
            set{
                int attacked = rnd.Next(0,100);
                if (attacked<50){
                    if (value< 0) health=0;
                    else if (value> 200){
                        health=200;
                    } else health=value;
                } else {
                    Console.WriteLine("Противник далеко от вас. Удар не произведён."); 
                    cond_energy = true;
                } 
            }
        }
        private int energy = 250;
        public override int Energy {
            get {return energy;}
            set{
                if (cond_energy==false){
                    if (value< 0) energy=0;
                    else if (value>250){
                        energy=250;
                    } else energy=value;
                } else {
                    cond_energy=false;
                }
            }
        }
        public Archer (string name): base(name){
            Name=name;
        }

        internal override void Attack1 (ref Enemy enemy){
            enemy.Health-=(int) Math.Round((75*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((30*(((double)Strength/100)+1)));
            Energy-=Cost1;
            Console.WriteLine($"\nВыстрел успешен! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

        internal override void Attack2 (ref Enemy enemy){
            enemy.Health-=(int) Math.Round((50*(((double) Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((75*(((double) Strength/100)+1)));
            Energy-=Cost2;
            Console.WriteLine($"\nВыстрел успешен! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

        internal override void Attack3 (ref Enemy enemy){
            int miss = rnd.Next(0,100);
            if (miss<50){
                enemy.Health-=(int) Math.Round((300*(((double)Strength/100)+1)));
                enemy.Energy-=(int) Math.Round((125*(((double)Strength/100)+1)));
                Console.WriteLine($"\nЗалп стрел произведён! Количество здоровья противника = {enemy.Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
            } else {
                enemy.Health-=(int) Math.Round(((300*(((double)Strength/100)+1))*0.25));
                enemy.Energy-=(int) Math.Round(((125*(((double)Strength/100)+1))*0.25));
                Console.WriteLine($"\nЗалп стрел произведён! Но часть стрел пролетело мимо... Количество здоровья противника = {enemy.Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
            }
            Energy-=Cost3;
        }

        internal override void Attack4 (ref Enemy enemy){
            return;
        }

        internal override void Skip_Step(){
            Energy=(int) Math.Round((double)(Energy*(0.25+1)));
            Health=(int) Math.Round((double)(Health*(0.1+1)));
            Console.WriteLine("\nВы отдохнули!");
            Console.WriteLine($"Ваше здоровье = {Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

        internal override void After_Step(){
            Energy+=75;
            Console.WriteLine("Восстановлено 75 единиц энергии!");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
    }
}