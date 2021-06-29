using System;

namespace game{

    class Wizard : Player{
        private bool perk = true;
        Random rnd = new Random();
        private int cost1 = 250;
        private int cost2 = 500;
        private int cost3 = 1000;
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
                if (value< 0) health=0;
                else if (value> 200){
                    health=200;
                } else health=value;
            }
        }
        private int energy = 1500;
        public override int Energy {
            get {return energy;}
            set{
                if (value< 0) energy=0;
                else if (value>1500){
                    energy=1500;
                } else energy=value;
            }
        }

        public Wizard (string name) : base(name){
            Name=name;
        }

        internal override void Attack1(ref Enemy enemy){
            if (perk==true){
                int ash = rnd.Next(0,100);
                if (ash<5){
                    enemy.Health=0;
                    Energy-=Cost1;
                    Console.WriteLine("\nПротивник обращён в прах");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                } else {
                    enemy.Health=(int) Math.Round((double)(enemy.Health*0.25));
                    enemy.Energy-=(int) Math.Round((25*(((double)Strength/100)+1)));
                    Energy-=Cost1;
                    Console.WriteLine("\nПротивник воспротивился обращению, но он потерпел значительный урон");
                    Console.WriteLine($"Здоровье противника = {enemy.Health}");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                    perk=false;
                }
            } else{
                enemy.Health-=(int) Math.Round((75*(((double)Strength/100)+1)));
                enemy.Energy-=(int) Math.Round((25*(((double)Strength/100)+1)));
                Energy-=Cost1;
                Console.WriteLine($"\nРуки из-под земли разодрали ноги противника! Количество здоровья противника = {enemy.Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
                if(enemy.Health==0) perk=true;
            }
        }

        internal override void Attack2(ref Enemy enemy){
            if (perk==true){
                int ash = rnd.Next(0,100);
                if (ash<5){
                    enemy.Health=0;
                    Energy-=Cost2;
                    Console.WriteLine("\nПротивник обращён в прах");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                } else {
                    enemy.Health=(int) Math.Round((double)(enemy.Health*0.25));
                    enemy.Energy-=(int) Math.Round((75*(((double)Strength/100)+1)));
                    Energy-=Cost2;
                    Console.WriteLine("\nПротивник воспротивился обращению, но он потерпел значительный урон");
                    Console.WriteLine($"Здоровье противника = {enemy.Health}");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                    perk=false;
                }
            } else{
                enemy.Health-=(int) Math.Round((175*(((double)Strength/100)+1)));
                enemy.Energy-=(int) Math.Round((75*(((double)Strength/100)+1)));
                Energy-=Cost2;
                Console.WriteLine($"\nПризрачный волк покусал противника! Количество здоровья противника = {enemy.Health}");
                Console.WriteLine($"Количество вашей энергии = {Energy}");
                if(enemy.Health==0) perk=true;
            }
        }

        internal override void Attack3(ref Enemy enemy){
            if (perk==true){
                int ash = rnd.Next(0,100);
                if (ash<5){
                    enemy.Health=0;
                    Energy-=Cost3;
                    Console.WriteLine("\nПротивник обращён в прах");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                } else {
                    enemy.Health=(int) Math.Round((double)(enemy.Health*0.25));
                    enemy.Energy-=(int) Math.Round((100*(((double)Strength/100)+1)));
                    Energy-=Cost3;
                    Console.WriteLine("\nПротивник воспротивился обращению, но он потерпел значительный урон");
                    Console.WriteLine($"Здоровье противника = {enemy.Health}");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                    perk=false;
                }
            } else{
                int lose_attack = rnd.Next(0, 100);
                if (lose_attack<25){
                    Health-=rnd.Next(50, 101);
                    Console.WriteLine($"\nГипноз не удался! Количество здоровья противника = {Health}");
                    Console.WriteLine($"Ваше здоровье = {Health}");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                } else {
                    enemy.Health-=(int) Math.Round((300*(((double)Strength/100)+1)));
                    enemy.Energy-=(int) Math.Round((100*(((double)Strength/100)+1)));
                    Energy-=Cost3;
                    Console.WriteLine($"\nГипноз удался и противник нанёс себе урон! Количество здоровья противника = {enemy.Health}");
                    Console.WriteLine($"Количество вашей энергии = {Energy}");
                }
                if(enemy.Health==0) perk=true;
            }
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
            Energy+=250;
            Console.WriteLine("Восстановлено 250 единиц энергии!");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }

    }
}