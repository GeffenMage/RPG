using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG {
     class BattleController {
        public void Battle(Player jogador,Mob inimigo) {
            int turno_atual = 1;
            String option;
            bool turno_player = true;
            while (jogador.IsAlive()==true && inimigo.IsAlive()== true) {
                System.Console.Clear();
                Display_player_status(jogador);
                System.Console.WriteLine("Turno:" + turno_atual);
                System.Console.WriteLine("===================");
                Display_mob_status(inimigo);
                if (turno_player == true) {
                    Display_player_menu(jogador);
                    option = System.Console.ReadLine();
                    if(option == "2") {
                        Display_player_skills_Menu(jogador);
                        option = System.Console.ReadLine();
                        Skill_select(jogador, option,inimigo);
                        turno_player = false;
                        turno_atual++;
                    }
                    else {
                        inimigo.Take_dmg(jogador.Atk_base());
                        turno_player = false;
                        turno_atual++;
                    }
                }
                else {
                    if(inimigo.nome == "Goblin") {
                        Goblin g = inimigo as Goblin;
                        jogador.Take_dmg(g.Atk_base());
                        System.Console.WriteLine("Voce recebeu:" + inimigo.base_dmg + " de dano");
                        System.Console.ReadKey();
                        turno_player = true;
                        turno_atual++;
                    }
                }
            }
        }
        public void Display_player_status(Player jogador) {
            System.Console.WriteLine("Player:" + jogador.nome + "\nLV:" + jogador.Lvl);
            System.Console.Write("HP:" + jogador.hp_atual + "/" + jogador.hp_total);
            System.Console.WriteLine("||MP:" + jogador.mp_atual + "/" + jogador.mp_total);
            System.Console.WriteLine("XP:" + jogador.xp_atual + "/" + jogador.xp_total);
        }
        public void Display_mob_status(Mob inimigo) {
            System.Console.WriteLine("Enemy:" + inimigo.nome + "\nLV:" + inimigo.Lvl);
            System.Console.Write("HP:" + inimigo.hp_atual + "/" + inimigo.hp_total);
            System.Console.WriteLine("||MP:" + inimigo.mp_atual + "/" + inimigo.mp_total);
        }

        public void Display_player_menu(Player jogador) {
            System.Console.WriteLine("===================");
            System.Console.WriteLine("Atacar[1]\nSkills[2]");
        }

        public void Display_player_skills_Menu(Player jogador) {
            switch(jogador.nome_classe) {
                case "Warrior":
                    System.Console.WriteLine("Stomp[1], Custo: 30MP");
                    break;
                default:
                    return;
            }
            
        }

        public void Skill_select(Player jogador,String skill_num, Mob inimigo) {
            switch (jogador.nome_classe) {
                case "Warrior":
                    Warrior w = jogador as Warrior;
                    if(skill_num == "1") {
                        inimigo.Take_dmg(w.Skill_Stomp());
                        break;
                    }
                    else {
                        break;
                    }
                default:
                    return;
            }

        }
    }
}
