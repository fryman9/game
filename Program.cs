using System;
using System.IO;

namespace game
{

    class Program
    {
        static void Main(string[] args)
        {
            Player player;
            Actions.Welcome();
            string name = Actions.Name_Selection();
            Actions.Classes_About();
            player = Actions.Class_Selection(name);
            Actions.Get_PlayerInfo(player);
            Actions.Characteristics_Selection(ref player);
            Battle.Welcome();
            int record = Battle.Start(ref player);
            Actions.Endgame(player, record);
        }
    }
}
