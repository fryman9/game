using System;
using System.IO;

namespace game{

    static class Battle{

        internal static void Welcome(){
            FileStream file;
            StreamReader reader;
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("bin"));
            Console.ForegroundColor = ConsoleColor.Black;
            file = new FileStream(path + @"Битва.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        internal static int Start(ref Player player){
            Enemy enemy = null;
            FileStream file;
            StreamReader reader;
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("bin"));
            int enemy_count = 0;
            string perk = "";
            while(player.Health!=0){
                if (enemy==null){
                    enemy = new Goblin("Гоблин", 500, 500);
                    Console.WriteLine("Создан гоблин");
                    Console.WriteLine("Здоровье противника - " + enemy.Health);
                }
                while(enemy.Health!=0){
                    switch(player){
                        case Warrior:
                            enterLoop:
                            Console.ForegroundColor = ConsoleColor.Black;
                            file = new FileStream(path + @"Warrior_Perks.txt", FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(file);
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            perk = Console.ReadLine();
                            switch(perk){
                                case "1":
                                    if(player.Energy>=player.Cost1){
                                        player.Attack1(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enterLoop;
                                    }
                                break;
                                case "2":
                                    if(player.Energy>=player.Cost2){
                                            player.Attack2(ref enemy);
                                            player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enterLoop;
                                    }
                                break;
                                case "3":
                                    if(player.Energy>=player.Cost3){
                                        player.Attack3(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enterLoop;
                                    }
                                break;
                                case "4":
                                    if(player.Cost1<=player.Energy){
                                        player.Attack4(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enterLoop;
                                    }
                                break;
                                case "5":
                                    player.Skip_Step();
                                break;
                                default:
                                goto enterLoop;
                            }    
                        break;
                        case Archer:
                            enter2Loop:
                            Console.ForegroundColor = ConsoleColor.Black;
                            file = new FileStream(path + @"Archer_Perks.txt", FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(file);
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            perk = Console.ReadLine();
                            switch(perk){
                                case "1":
                                    if(player.Cost1<=player.Energy){
                                        player.Attack1(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter2Loop;
                                    }
                                break;
                                case "2":
                                    if(player.Energy>=player.Cost2){
                                            player.Attack2(ref enemy);
                                            player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter2Loop;
                                    }
                                break;
                                case "3":
                                    if(player.Energy>=player.Cost3){
                                        player.Attack3(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter2Loop;
                                    }
                                break;
                                case "4":
                                    player.Skip_Step();
                                break;
                                default:
                                goto enter2Loop;
                            }
                        break;
                        case Mage:
                            enter3Loop:
                            Console.ForegroundColor = ConsoleColor.Black;
                            file = new FileStream(path + @"Mage_Perks.txt", FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(file);
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            perk = Console.ReadLine();
                            switch(perk){
                                case "1":
                                    if(player.Cost1<=player.Energy){
                                        player.Attack1(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter3Loop;
                                    }
                                break;
                                case "2":
                                    if(player.Energy>=player.Cost2){
                                            player.Attack2(ref enemy);
                                            player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter3Loop;
                                    }
                                break;
                                case "3":
                                    if(player.Energy>=player.Cost3){
                                        player.Attack3(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter3Loop;
                                    }
                                break;
                                case "4":
                                    player.Skip_Step();
                                break;
                                default:
                                goto enter3Loop;
                            }
                        break;
                        case Assassin:
                            enter4Loop:
                            Console.ForegroundColor = ConsoleColor.Black;
                            file = new FileStream(path + @"Assassin_Perks.txt", FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(file);
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            perk = Console.ReadLine();
                            switch(perk){
                                case "1":
                                    if(player.Cost1<=player.Energy){
                                        player.Attack1(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter4Loop;
                                    }
                                break;
                                case "2":
                                    if(player.Energy>=player.Cost2){
                                            player.Attack2(ref enemy);
                                            player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter4Loop;
                                    }
                                break;
                                case "3":
                                    if(player.Energy>=player.Cost3){
                                        player.Attack3(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter4Loop;
                                    }
                                break;
                                case "4":
                                    player.Skip_Step();
                                break;
                                default:
                                goto enter4Loop;
                            }
                        break;
                        case Wizard:
                            enter5Loop:
                            Console.ForegroundColor = ConsoleColor.Black;
                            file = new FileStream(path + @"Wizard_Perks.txt", FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(file);
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            perk = Console.ReadLine();
                            switch(perk){
                                case "1":
                                    if(player.Cost1<=player.Energy){
                                        player.Attack1(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter5Loop;
                                    }
                                break;
                                case "2":
                                    if(player.Energy>=player.Cost2){
                                            player.Attack2(ref enemy);
                                            player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter5Loop;
                                    }
                                break;
                                case "3":
                                    if(player.Energy>=player.Cost3){
                                        player.Attack3(ref enemy);
                                        player.After_Step();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Не хватает энергии!!!");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        goto enter5Loop;
                                    }
                                break;
                                case "4":
                                    player.Skip_Step();
                                break;
                                default:
                                goto enter5Loop;
                            }
                        break;
                    }
                    if(enemy.Health!=0){
                        if(enemy.Energy>=enemy.Cost1){
                            int comp = player.Health;
                            enemy.Attack(ref player);
                            enemy.After_Step();
                            if (comp!=player.Health){
                                Console.WriteLine("\nПротивник совершил атаку!");
                                Console.WriteLine($"Ваше здоровье = {player.Health}");
                                Console.WriteLine($"Ваша энергия = {player.Energy}\n");
                            }
                        } else {
                            enemy.Skip_Step();
                        }
                    }
                    if(player.Health==0){
                        goto endLoop;
                    }
                }
                enemy = null;
                enemy_count++;
            }
            endLoop:
            Console.WriteLine("Вы погибли. Рекорд будет записан в файл Leaderboard.txt");
            return enemy_count;
        }


    }
}