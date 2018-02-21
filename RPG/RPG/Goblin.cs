using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    class Goblin : Mob {

        public Goblin() {
            nome = "Goblin";
            hp_total = 300;hp_atual = hp_total;
            mp_total = 150;mp_atual = mp_total;
            given_xp = 100;Lvl = 5;
            base_def = 20;base_dmg = 50;
        }



    }
}
