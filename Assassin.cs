using System;

namespace game{

    class Assassin : Player {
        private int chance = 20;
        bool cond_energy = false;
        Random rnd = new Random();
        private int cost1 = 50;
        private int cost2 = 125;
        private int cost3 = 300;
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
        private int health = 150;
        public override int Health {
            get{return health;}
            set{
                int attacked = rnd.Next(0,100);
                if (attacked<chance){
                    if (value< 0) health=0;
                    else if (value> 150){
                        health=150;
                    } else health=value;
                } else {
                    Console.WriteLine("\nВас не заметили. Поэтому атака не была совершена");
                    cond_energy = true;
                }
                chance=20;
            }
        }
        private int energy = 500;
        public override int Energy {
            get {return energy;}
            set{
                if (cond_energy==false){
                    if (value< 0) energy=0;
                    else if (value>500){
                        energy=500;
                    } else energy=value;
                } else {
                    cond_energy=false;
                }
            }
        }

        public Assassin (string name) : base(name){
            Name=name;
        }

        internal override void Attack1(ref Enemy enemy){
            enemy.Health-=(int) Math.Round((100*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((75*(((double)Strength/100)+1)));
            Energy-=Cost1;
            chance+=10;
            Console.WriteLine($"\nСкрытная атака прошла успешна! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
            Console.WriteLine("Шанс обнаружения увеличен на 10%");
        }

        internal override void Attack2 (ref Enemy enemy){
            enemy.Health-=(int) Math.Round((200*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((100*(((double)Strength/100)+1)));
            Energy-=Cost2;
            chance+=25;
            Console.WriteLine($"\nУдар в спину прошёл успешно! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
            Console.WriteLine("Шанс обнаружения увеличен на 25%");
        }

        internal override void Attack3 (ref Enemy enemy){
            enemy.Health-=(int) Math.Round((300*(((double)Strength/100)+1)));
            enemy.Energy-=(int) Math.Round((200*(((double)Strength/100)+1)));
            Energy-=Cost3;
            chance+=80;
            Console.WriteLine($"\nАтака с прыжка прошла успешна! Количество здоровья противника = {enemy.Health}");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
            Console.WriteLine("Шанс обнаружения вас 100%");
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
            Energy+=125;
            Console.WriteLine("Восстановлено 125 единиц энергии!");
            Console.WriteLine($"Количество вашей энергии = {Energy}");
        }
    }
}