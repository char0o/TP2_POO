using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class GestionJeu
    {
        #region Properties
        private Personnage joueur;
        private Personnage ennemi;
        private int noTableau;
        private List<Personnage> ennemis;

        public List<Personnage> Ennemis
        {
            get { return ennemis; }
            private set {
                if (value is null)
                    throw new ArgumentNullException();
                ennemis = value; 
            }
        }

        public int NoTableau
        {
            get { return noTableau; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                noTableau = value;
            }
        }
        public Personnage Ennemi
        {
            get { return ennemi; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                ennemi = value;
            }
        }
        public Personnage Joueur
        {
            get { return joueur; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                joueur = value;
            }
        }
        #endregion
        public GestionJeu(Personnage joueur)
        {
            this.Joueur = joueur;
            this.NoTableau = 0;
            this.Ennemis = new List<Personnage>();
            this.CreerEnnemis();
            this.CreerDonjon();
        }

        private void CreerDonjon()
        {
            while (this.NoTableau < this.Ennemis.Count)
            {
                bool victoire = this.Engager();
                if (victoire)
                {
                    Utility.PrintColoredText($"Vous avez éliminé le {this.Ennemi.Nom}\n", ConsoleColor.Green);
                    RecueillirRecompense();
                    Console.ReadKey();
                }
                else
                {
                    Utility.PrintColoredText("Défaite...\n", ConsoleColor.Red);
                    return;
                }
            }
            Console.WriteLine("Vous avez battu tous les ennemis!");
        }

        private void CreerEnnemis()
        {
            StatsPersonnages statsSquelette = new StatsPersonnages(Config.SQUELETTE_PDV, Config.SQUELETTE_ATQ, Config.SQUELETTE_DEF);
            Ennemis.Add(new Personnage("Skelette", Classe.Squelette, new List<Sort>(), Arme.MainsNues, statsSquelette));
            StatsPersonnages statsGoblin = new StatsPersonnages(Config.GOBLIN_PDV, Config.GOBLIN_ATQ, Config.GOBLIN_DEF);
            Ennemis.Add(new Personnage("Goblin", Classe.Goblin, new List<Sort>(), Arme.MainsNues, statsGoblin));
            StatsPersonnages statsDragon = new StatsPersonnages(Config.DRAGON_PDV, Config.DRAGON_ATQ, Config.DRAGON_DEF);
            Ennemis.Add(new Personnage("Faermoore", Classe.Squelette, new List<Sort>(), Arme.MainsNues, statsDragon));
            StatsPersonnages statsTroll = new StatsPersonnages(Config.TROLL_PDV, Config.TROLL_ATQ, Config.TROLL_DEF);
            Ennemis.Add(new Personnage("Troll", Classe.Troll, new List<Sort>(), Arme.MainsNues, statsTroll));
        }

        public bool Engager()
        {
            this.Ennemi = this.Ennemis[noTableau];
            this.Joueur.DegatsDernierCombat.Clear();
            Console.Clear();
            Utility.PrintColoredText($"Un {Ennemi.Nom} vous attaque!\n", ConsoleColor.Red);
            Console.ReadKey();

            bool tourJoueur = DeterminerPremierPersonnage();
            Console.ReadKey();
            int tour = 0;
            while (!this.Joueur.EstMort() && !this.Ennemi.EstMort())
            {
                if (tourJoueur)
                {
                    ChoisirAction(tourJoueur, tour);
                    Console.ReadKey();
                    tourJoueur = false;
                }
                else
                {
                    this.Ennemi.Attaquer(joueur);
                    AfficherStatutCombat(tourJoueur, tour);
                    Console.ReadKey();
                    tourJoueur = true;
                }
                tour++;
            }
            noTableau++;
            return this.Ennemi.EstMort();
        }

        private bool DeterminerPremierPersonnage()
        {
            bool tourJoueur = Utility.DemanderNombreEntreMinEtMax(0, 1) == 0;
            if (tourJoueur)
            {
                Utility.PrintColoredText("Vous attaquez en premier\n", ConsoleColor.Green);
            }
            else
            {
                Utility.PrintColoredText($"Le {ennemi.Nom} attaque en premier\n", ConsoleColor.Red);
            }
            return tourJoueur;
        }

        public void ChoisirAction(bool tourJoueur, int tour)
        {
            int max = 1;

            Utility.PrintColoredText("1. Attaquer\n", ConsoleColor.Yellow);
            if (this.Joueur.NbPotions > 0)
            {
                Utility.PrintColoredText("2. Boire une potion\n", ConsoleColor.Cyan);
                max = 2;
            }
            int action = InputManager.PromptIntCursor(1, max, "Choix: ", "Choix invalide");
            int cursorTop = Console.CursorTop;
            for (int i = 1; i < max + 2; i++)
            {
                InputManager.ClearLine(cursorTop - i);
            }
            switch (action)
            {
                case 1:
                    this.Joueur.Attaquer(this.Ennemi);
                    AfficherStatutCombat(tourJoueur, tour);
                    break;
                case 2:
                    this.Joueur.BoirePotion();
                    int vie = joueur.Stats.PtsVie;
                    int vieMax = joueur.Stats.PtsVieMax;
                    Utility.PrintColoredText($"Vous buvez une potion. Vous avez maintenant {vie}/{vieMax} points de vie.\n", ConsoleColor.Green);
                    this.Joueur.DegatsDernierCombat.Add(0);
                    this.Ennemi.DegatsDernierCombat.Add(0);
                    break;
            }
        }
        public void AfficherStatutCombat(bool tourJoueur, int tour)
        {
            if (tourJoueur)
            {
                int degats = Math.Abs(Joueur.DegatsDernierCombat[tour]);
                int vie = ennemi.Stats.PtsVie;
                int vieMax = ennemi.Stats.PtsVieMax;
                if (degats == 0)
                {
                    Utility.PrintColoredText($"Vous avez manqué le {ennemi.Nom}. Il lui reste {vie}/{vieMax} points de vie\n", ConsoleColor.Green);
                }
                else
                {
                    Utility.PrintColoredText($"Vous avez infligé {degats} de dégats au {ennemi.Nom}. Il lui reste {vie}/{vieMax} points de vie\n", ConsoleColor.Green);
                }
            }
            else
            {
                int degats = Math.Abs(Joueur.DegatsDernierCombat[tour]);
                int vie = joueur.Stats.PtsVie;
                int vieMax = joueur.Stats.PtsVieMax;
                if (degats == 0)
                {
                    Utility.PrintColoredText($"Le {ennemi.Nom} vous a manqué. Il vous reste {vie}/{vieMax} de points de vie\n", ConsoleColor.Red);
                }
                else
                {
                    Utility.PrintColoredText($"Le {ennemi.Nom} vous a infligé {degats} de degats. Il vous reste {vie}/{vieMax} de points de vie\n", ConsoleColor.Red);
                }

            }
        }
        public void RecueillirRecompense()
        {
            int rdm = Utility.DemanderNombreEntreMinEtMax(0, 100);
            this.Joueur.DonnerExperience(50);
            if (rdm <= 30)
            {
                this.Joueur.NbPotions++;
                Utility.PrintColoredText("Vous gagnez une potion!\n", ConsoleColor.Yellow);
            }
            else if (rdm <= 60)
            {
                joueur.Stats.PtsVieMax += 5;
                Utility.PrintColoredText("Vous gagnez 5 points de vie!\n", ConsoleColor.Yellow);
            }
            else
            {
                Utility.PrintColoredText("Vous ne gagnez rien!\n", ConsoleColor.Red);
            }
        }
    }
}
