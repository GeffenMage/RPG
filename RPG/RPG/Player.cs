using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Player 
    {
       public String nome;
       public int hp_atual, hp_total;
       public int mp_atual, mp_total;
       public int xp_atual, xp_total,Lvl;
       public int base_dmg, base_def;
       public String nome_classe;

        //Implementar interface gráfica de movimento para o personagem
        public bool IsLvUP() {
            if (xp_atual == xp_total) {
                Lvl++;
                xp_total *= 2;
                return true;
            }
            else {
                return false;
            }
        }

        public void Gain_xp(int xp_gain) {
            xp_atual += xp_gain;
            if(IsLvUP()== true) {
                xp_atual = xp_atual - xp_total;
            }
            else {
                return;
            }
        }


        public bool IsManaAvaliable(int custo_de_mana) {
            if (mp_atual >= custo_de_mana) {
                return true;
            }
            else {
                return false;
            }

            
        }

        public bool IsAlive() {
            if (hp_atual > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        //Necessario modificar esse método caso quiser adicionar modificadores para ataque
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
