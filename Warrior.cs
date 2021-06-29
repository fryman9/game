using System;

namespace game{

    class Warrior : Player {

        private int cost1 = 50;
        private int cost2 = 100;
        private int cost3 = 125;
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
        private int health = 350;
        public override int Health {
            get{return health;}
            set{
                if (value< 0) health=0;
                else if (value> 350){
                    health=350;
                } else health=value;
            }
        }
        private int energy = 500;
        public override int Energy {
            get {return energy;}
            set{
                if (value< 0) energy=0;
                else if (value>500){
                    energy=500;
                } else energy=value;
            }
        }
        
        Random rnd = new Random();

        public Warrior (string name) : base(name){
            Name=name;
        }

        internal override void Attack1(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((50*(((double) Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((25*(((double)Strength/100)+1)));
            Energy-=Cost1;
            Console.WriteLine($"\n Атака прошла успешна! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
        internal override void Attack2(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((50*(((double) Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((50*(((double)Strength/100)+1)));
            Energy-=Cost2;
            Console.WriteLine($"\n Атака прошла успешна! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
        internal override void Attack3(ref Enemy enemy){
            int lose_attack = rnd.Next(0, 100);
            if(lose_attack<20){
                Health-=rnd.Next(10,26);
                Energy-=Cost3;
                Console.WriteLine("Атака оказалась неудачной и противник ударил вас!");
                Console.WriteLine($"Ваше здоровье = {Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
            } else {
                enemy.Health-=(int) Math.Round((200*(((double)Strength/100)+1)));
                enemy.Energy-=(int) Math.Round((50*(((double)Strength/100)+1)));
                Energy-=Cost3;
                Console.WriteLine($"\n Атака прошла успешна! Количество здоровья противника = {enemy.Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
            }
        }
        internal override void Attack4(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((25*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((100*(((double)Strength/100)+1)));
            Energy-=Cost1;
            Console.WriteLine($"\n Атака прошла успешна! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
        internal override void Skip_Step(){
            Energy=(int) Math.Round((double)(Energy*(0.25+1)));
            Health=(int) Math.Round((double)(Health*(0.1+1)));
            Console.WriteLine("\nВы отдохнули!");
            Console.WriteLine($"Ваше здоровье = {Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
        internal override void After_Step(){
            Energy+=50;
            Console.WriteLine("Восстановлено 50 единиц энергии!");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
    }
}