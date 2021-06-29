using System;

namespace game{

    class Mage : Player {
        Random rnd = new Random();
        private int cost1 = 100;
        private int cost2 = 200;
        private int cost3 = 500;
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
        private int health = 300;
        public override int Health {
            get{return health;}
            set{
                int attacked = rnd.Next(0,100);
                if (attacked<70){
                    if (value< 0) health=0;
                    else if (value> 300){
                        health=300;
                    } else health=value;
                } else {
                    Console.WriteLine("\nМагический щит спас вас. Энергия всё равно потрачена");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                }
            }
        }
        private int energy = 750;
        public override int Energy {
            get {return energy;}
            set{
                if (value< 0) energy=0;
                else if (value>750){
                    energy=750;
                } else energy=value;
            }
        }

        public Mage (string name): base(name){
            Name=name;
        }

        internal override void Attack1(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((50*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((50*(((double)Strength/100)+1)));
            Energy-=Cost1;
            Console.WriteLine($"\nМагический шар достиг противника! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

        internal override void Attack2(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((75*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((150*(((double)Strength/100)+1)));
            Energy-=Cost2;
            Console.WriteLine($"\nЭлектрический разряд поразил противника! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

        internal override void Attack3(ref Enemy enemy){
            int miss = rnd.Next(0,100);
            if (miss<65){
                enemy.Health-=(int) Math.Round((200*(((double)Strength/100)+1)));
                enemy.Energy-=(int) Math.Round((50*(((double)Strength/100)+1)));
                Console.WriteLine($"\nКамнепад повалил противника! Количество здоровья противника = {enemy.Health}");
            } else {
                enemy.Health-=(int) Math.Round(((200*(((double)Strength/100)+1))*0.25));
                enemy.Energy-=(int) Math.Round(((50*(((double)Strength/100)+1))*0.25));
                Console.WriteLine($"\nЧасть камней не попала в противника! Количество здоровья противника = {enemy.Health}");
            }
            Energy-=Cost3;
            Console.WriteLine($"Количество вашей энергии = {Energy}");
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
            Energy+=150;
            Console.WriteLine("Восстановлено 150 единиц энергии!");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
    }
}