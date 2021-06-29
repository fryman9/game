using System;
using System.IO;

namespace game{

    static class Actions {
        internal static int characteristics = 45;
        internal static short changeChar = 0;


        internal static void Welcome(){
            FileStream file;
            StreamReader reader;
            string path = Directory.GetCurrentDirectory();
            path =path.Remove(path.IndexOf("bin"));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            file = new FileStream(path + @"Приветствие.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        internal static string Name_Selection(){
            string name;
            Console.Write("Введите имя вашего персонажа: ");
            do{
                name = Console.ReadLine();
                if (name.Length>16) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректное имя персонажа");
                    Console.WriteLine("Имя персонажа не должно превышать 16 символов");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (name.Length>16);
            return name;
        }

        internal static void Classes_About(){
            FileStream file;
            StreamReader reader;
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("bin"));
            Console.ForegroundColor = ConsoleColor.Black;
            file = new FileStream(path + @"Классы.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Green;
            file = new FileStream(path + @"Список_классы.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        internal static Player Class_Selection(string name){
            FileStream file;
            StreamReader reader;
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("bin"));
            Random rnd = new Random();
            while(true){
                Console.Write("Введите команду: ");
                string classChar = Console.ReadLine();
                switch(classChar){
                    case "/info 1":
                        Console.ForegroundColor = ConsoleColor.Black;
                        file = new FileStream(path + @"Воин.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "/info 2":
                        Console.ForegroundColor = ConsoleColor.Black;
                        file = new FileStream(path + @"Лучник.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "/info 3":
                        Console.ForegroundColor = ConsoleColor.Black;
                        file = new FileStream(path + @"Маг.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "/info 4":
                        Console.ForegroundColor = ConsoleColor.Black;
                        file = new FileStream(path + @"Ассасин.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "/info 5":
                        Console.ForegroundColor = ConsoleColor.Black;
                        file = new FileStream(path + @"Колдун.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "/list":
                        Console.ForegroundColor = ConsoleColor.Green;
                        file = new FileStream(path + @"Список_классы.txt", FileMode.Open, FileAccess.Read);
                        reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    case "1":
                        if(Confirm()==true){
                            return new Warrior(name);
                        } 
                    break;
                    case "2":
                        if(Confirm()==true){
                            return new Archer(name);
                        }
                    break;
                    case "3":
                        if(Confirm()==true){
                            return new Mage(name);
                        }
                    break;
                    case "4":
                        if(Confirm()==true){
                            return new Assassin(name);
                        }
                    break;
                    case "5":
                        if(Confirm()==true){
                            return new Wizard(name);
                        }
                    break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        switch(rnd.Next(0,6)){
                            case 0:
                                Console.WriteLine("Что такое вы ввели?");
                            break;
                            case 1:
                                Console.WriteLine("Вы в своём уме?");
                            break;
                            case 2:
                                Console.WriteLine("Эмм... И что я должен сделать?");
                            break;
                            case 3:
                                Console.WriteLine("Определись уже, что ты выбираешь!");
                            break;
                            case 4:
                                Console.WriteLine("А да?");
                            break;
                            case 5:
                                Console.WriteLine("Ожидаю нормальную команду...");
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                }
            }
        }

        internal static bool Confirm(){
            Console.WriteLine("Вы уверены в своём выборе?");
            Console.WriteLine("Отправьте Y или N");
            for(;;){
                string answer = Console.ReadLine();
                if(answer=="Y" || answer=="y"){
                    return true;
                } else if(answer=="N" || answer=="n"){
                    return false;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нет такого варианта ответа!!!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
        }

        internal static void Get_PlayerInfo(Player player){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Твоё имя - {player.Name}");
            Console.WriteLine($"Твоё здоровье - {player.Health}");
            Console.WriteLine($"Твоё энергия - {player.Energy}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        internal static void Get_Characteristics(Player player){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Сила - {player.Strength}");
            Console.WriteLine($"Защита - {player.Defence}");
            Console.WriteLine($"Удача - {player.Luck}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        internal static void Characteristics_Selection(ref Player player){
            while (characteristics-player.Strength-player.Defence-player.Luck!=0){
                Console.WriteLine("Чтобы узнать текущее значение характеристик, введите (/stats)");
                Console.WriteLine("Укажите какой характеристике вы хотите задать значение");
                Console.WriteLine("1 - Сила \n2 - Защита \n3 - Удача");
                string changeCharString = Console.ReadLine();
                if (changeCharString=="/stats"){
                    Get_Characteristics(player);
                } else {
                    try {
                        changeChar = Convert.ToInt16(changeCharString);
                        switch(changeChar){
                            case 1:
                                Console.Write("Введите значение силы: ");
                                try{
                                player.Strength=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Очков осталось: {characteristics-player.Strength-player.Defence-player.Luck}");
                                } catch {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Вы ввели невозможное значение!");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                            break;
                            case 2:
                                Console.Write("Введите значение защиты: ");
                                try{
                                    player.Defence=Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine($"Очков осталось: {characteristics-player.Strength-player.Defence-player.Luck}");
                                } catch {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Вы ввели невозможное значение!");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                            break;
                            case 3:
                                Console.Write("Введите значение удачи: ");
                                try{
                                    player.Luck=Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine($"Очков осталось: {characteristics-player.Strength-player.Defence-player.Luck}");
                                } catch {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Вы ввели невозможное значение!");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                            break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Вы ввели номер несуществующей характеристики!");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                    } catch {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Команда неопознана");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }
                
                if (characteristics-player.Strength-player.Defence-player.Luck==0){
                    Console.WriteLine("Вас устраивают ваши характеристики?");
                    Get_Characteristics(player);
                    if (Confirm()!=true){
                        player.Strength=0;
                        player.Defence=0;
                        player.Luck=0;
                    }
                } else if (characteristics-player.Strength-player.Defence-player.Luck<0){
                    Console.WriteLine("Распределено слишком большое количество характеристик");
                }
                changeChar = 0;
            } 
        }
        internal static void Endgame(Player player, int record){
            FileStream file;
            StreamWriter writer;
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("bin"));
            file = new FileStream(path + @"Leaderboard.txt", FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(file);
            writer.Write($"{player.Name} {record}\n");
            writer.Close();
        }
    }
}