using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    abstract class Mob {
        public String nome;
        public int hp_atual, hp_total;
        public int mp_atual, mp_total;
        public int Lvl,given_xp;
        public int base_dmg, base_def;

        public int Give_xp() {
            return given_xp;
        }

        public bool IsAlive() {
            if (hp_atual > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public int Atk_base() {
            return base_dmg;
        }

        public bool Take_dmg(int dmg) {
            if (dmg > base_def) {
                hp_atual -= dmg;
                return true;
            }
            else {
                return false;
            }
        }
    }
}
