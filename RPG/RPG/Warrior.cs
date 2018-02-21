using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
    class Warrior : Player {

        //Construtor setando os valores base do warrior
        public Warrior(String nome) {
            this.nome = nome;
            Lvl = 1; xp_atual = 0; xp_total = 1000;
            hp_total = 500; hp_atual = hp_total;
            mp_total = 250; mp_atual = mp_total;
            base_def = 30; base_dmg = 80;
            nome_classe = "Warrior";
        }


        //Skill de teste
        public int Skill_Stomp() {
            int custo_skill = 30;
            int dano_skill = 250;

            if (IsManaAvaliable(custo_skill) == true) {
                mp_atual -= custo_skill;
                return dano_skill;
            }
            else {
                return -1;
            }
        }
        
    }
}
