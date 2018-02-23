﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    class Ogro : Mob {

        public Ogro(int lvl) {
            switch (lvl) {
                case 1:
                    Nome = "Ogro Verde";
                    Hp_total = 800; Hp_atual = Hp_total;
                    Mp_total = 100; Mp_atual = Mp_total;
                    Given_xp = 1000; Lvl = 20;
                    Base_def = 60; Base_dmg = 110;
                    break;
                case 2:
                    Nome = "Ogro Negro";
                    Hp_total = 1000; Hp_atual = Hp_total;
                    Mp_total = 150; Mp_atual = Mp_total;
                    Given_xp = 1300; Lvl = 25;
                    Base_def = 70; Base_dmg = 130;
                    break;
                case 3:
                    Nome = "Ogro Chefe";
                    Hp_total = 1200; Hp_atual = Hp_total;
                    Mp_total = 150; Mp_atual = Mp_total;
                    Given_xp = 1700; Lvl = 30;
                    Base_def = 80; Base_dmg = 150;
                    break;
            }

        }

    }
}
