using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    class Warrior : Player {

        //Construtor setando os valores base do warrior
        public Warrior(String nome) {
            this.Nome = nome;
            Lvl = 1; Xp_atual = 0; Xp_total = 1000;
            Hp_total = 500; Hp_atual = Hp_total;
            Mp_total = 250; Mp_atual = Mp_total;
            Base_def = 30; Base_dmg = 80;
            Nome_classe = "Warrior";
        }


        //Skill de teste
        public int Skill_Stomp() {
            int custo_skill = 30;
            int dano_skill = 250;

            if (IsManaAvaliable(custo_skill) == true) {
                Mp_atual -= custo_skill;
                return dano_skill;
            }
            else {
                return -1;
            }
        }
        
    }
}
