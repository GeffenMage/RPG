using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    class Goblin : Mob {

        public Goblin() {
            Nome = "Goblin";
            Hp_total = 300;Hp_atual = Hp_total;
            Mp_total = 150;Mp_atual = Mp_total;
            Given_xp = 100;Lvl = 5;
            Base_def = 20;Base_dmg = 50;
        }



    }
}
