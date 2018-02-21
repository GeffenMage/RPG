using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleController btc = new BattleController();
            Warrior p1 = new Warrior("Jogador_teste");
            Goblin g1 = new Goblin();
            btc.Battle(p1, g1);

            Console.ReadKey();
        }
    }
}
