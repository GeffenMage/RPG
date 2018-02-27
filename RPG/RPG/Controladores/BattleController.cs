using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Personagens.Inimigos;

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
                    //Cada caso é um comportamento de mob
                    switch(inimigo.Nome){
                        case "Goblin":
                            jogador.Take_dmg(inimigo.Atk_base());
                            System.Console.WriteLine("Voce recebeu:" + inimigo.Base_dmg + " de dano");
                            System.Console.ReadKey();
                            turno_player = true;
                            turno_atual++;
                            break;
                        default:
                            jogador.Take_dmg(inimigo.Atk_base());
                            System.Console.WriteLine("Voce recebeu:" + inimigo.Base_dmg + " de dano");
                            System.Console.ReadKey();
                            turno_player = true;
                            turno_atual++;
                            break;
                    }
                }
            }
            if (jogador.IsAlive() == false) {
                System.Console.Clear();
                System.Console.WriteLine("GAME OVER\nVOCE MORREU");
                return;
            }
            else {
                Victory(jogador, inimigo);
                return;
            }
        }
        //Mudar retorno para string quando implementar o front-end
        public void Display_player_status(Player jogador) {
            System.Console.WriteLine("Player:" + jogador.Nome + "\nLV:" + jogador.Lvl);
            System.Console.Write("HP:" + jogador.Hp_atual + "/" + jogador.Hp_total);
            System.Console.WriteLine("||MP:" + jogador.Mp_atual + "/" + jogador.Mp_total);
            System.Console.WriteLine("XP:" + jogador.Xp_atual + "/" + jogador.Xp_total);
        }
        //Mudar retorno para string quando implementar o front-end
        public void Display_mob_status(Mob inimigo) {
            System.Console.WriteLine("Enemy:" + inimigo.Nome + "\nLV:" + inimigo.Lvl);
            System.Console.Write("HP:" + inimigo.Hp_atual + "/" + inimigo.Hp_total);
            System.Console.WriteLine("||MP:" + inimigo.Mp_atual + "/" + inimigo.Mp_total);
        }

        //Mudar retorno para string quando implementar o front-end
        public void Display_player_menu(Player jogador) {
            System.Console.WriteLine("===================");
            System.Console.WriteLine("Atacar[1]\nSkills[2]");
        }
        
        //Mudar retorno para String e criar uma variavél string que é concatenada a cada passagem do foreach
        //quando implementar o front-end
        public void Display_player_skills_Menu(Player jogador) {
            
            foreach( Skill s in jogador.Skills){
                int i = 1;
                //Será necessário modificar esse if else para skills que custem mana e hp
                if (s.Custo_hp == 0) {
                    System.Console.WriteLine(s.Skill_name + "[" + i + "] Custo:" + s.Custo_mp + "MP");
                }
                else {
                    System.Console.WriteLine(s.Skill_name + "[" + i + "] Custo:" + s.Custo_hp + "HP");
                }
                i++;
            }
            
            
        }

        public int Skill_select(Player jogador,String skill_num, Mob inimigo) {
            int dmg_skill;
            int index = Int32.Parse(skill_num);
            dmg_skill = jogador.Skills[index-1].executar(jogador);
            inimigo.Take_dmg(dmg_skill);
            return dmg_skill;
            /*
            switch (jogador.Nome_classe) {
                case "Warrior":
                    Warrior w = jogador as Warrior;
                    switch(skill_num) {
                        case "1":
                            dmg_skill = w.Skills[0].executar(jogador);
                            inimigo.Take_dmg(dmg_skill);
                            return dmg_skill;
                        default:
                            System.Console.WriteLine("Skill Inválida, tente novamente.");
                            break;
                    }
                    break;
                //Casos adicionais devem ser colocados para cada classe do jogador
                case "Mago"://Criar um switch case para cada skill da classe
                    break;
                case "Arqueiro"://Criar um switch case para cada skill da classe
                    break;
                default:
                    return 0;
            }
            return 0;
            */
        }

        public void Victory(Player jogador,Mob inimigo) {
            System.Console.Clear();
            System.Console.WriteLine("Resultados da Batalha");
            System.Console.WriteLine("====================");
            System.Console.WriteLine("HP: " + jogador.Hp_atual + "/" + jogador.Hp_total);
            System.Console.WriteLine("MP: " + jogador.Mp_atual + "/" + jogador.Mp_total);
            System.Console.WriteLine("XP: " + jogador.Xp_atual + "/" + jogador.Xp_total+" +"+inimigo.Given_xp);
            jogador.Gain_xp(inimigo.Give_xp());
            if (jogador.IsLvUP() == true) {
                jogador.LvUp();
                System.Console.WriteLine("Voce avancou para o Level " + jogador.Lvl);
            }
            else {
                return;
            }
        }
    }
}
