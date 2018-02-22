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
                        System.Console.WriteLine(inimigo.Nome + " recebeu " + Skill_select(jogador, option, inimigo)+ " de dano");
                        System.Console.ReadKey();
                        turno_player = false;
                        turno_atual++;
                    }
                    else {
                        inimigo.Take_dmg(jogador.Atk_base());
                        System.Console.WriteLine(inimigo.Nome + " recebeu " + jogador.Atk_base() + " de dano");
                        System.Console.ReadKey();
                        turno_player = false;
                        turno_atual++;
                    }
                }
                else {
                    if(inimigo.Nome == "Goblin") {
                        Goblin g = inimigo as Goblin;
                        jogador.Take_dmg(g.Atk_base());
                        System.Console.WriteLine("Voce recebeu:" + inimigo.Base_dmg + " de dano");
                        System.Console.ReadKey();
                        turno_player = true;
                        turno_atual++;
                    }
                }
            }
        }
        public void Display_player_status(Player jogador) {
            System.Console.WriteLine("Player:" + jogador.Nome + "\nLV:" + jogador.Lvl1);
            System.Console.Write("HP:" + jogador.Hp_atual + "/" + jogador.Hp_total);
            System.Console.WriteLine("||MP:" + jogador.Mp_atual + "/" + jogador.Mp_total);
            System.Console.WriteLine("XP:" + jogador.Xp_atual + "/" + jogador.Xp_total);
        }
        public void Display_mob_status(Mob inimigo) {
            System.Console.WriteLine("Enemy:" + inimigo.Nome + "\nLV:" + inimigo.Lvl1);
            System.Console.Write("HP:" + inimigo.Hp_atual + "/" + inimigo.Hp_total);
            System.Console.WriteLine("||MP:" + inimigo.Mp_atual + "/" + inimigo.Mp_total);
        }

        public void Display_player_menu(Player jogador) {
            System.Console.WriteLine("===================");
            System.Console.WriteLine("Atacar[1]\nSkills[2]");
        }

        public void Display_player_skills_Menu(Player jogador) {
            switch(jogador.Nome_classe) {
                case "Warrior":
                    System.Console.WriteLine("Stomp[1], Custo: 30MP");
                    break;
                default:
                    return;
            }
            
        }

        public int Skill_select(Player jogador,String skill_num, Mob inimigo) {
            int dmg_skill;
            switch (jogador.Nome_classe) {
                case "Warrior":
                    Warrior w = jogador as Warrior;
                    if(skill_num == "1") {
                        dmg_skill = w.Skill_Stomp();
                        inimigo.Take_dmg(dmg_skill);
                        return dmg_skill;
                    }
                    else {
                        return 0;
                    }
                //Casos adicionais devem ser colocados para cada classe do jogador
                default:
                    return 0;
            }

        }
    }
}
