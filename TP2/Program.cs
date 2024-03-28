namespace TP2
{
    class Program
    {

        public static void Main(string[] args)
        {
            Personnage joueur = CreerJoueur();
            GestionJeu donjon = new GestionJeu(joueur);
        }
        public static Personnage CreerJoueur()
        {
            string nom = InputManager.PromptStringCursor("Entrez le nom du personnage: ", "Le nom est invalide");
            string classes = Utility.CreateMenuFromList( Personnage.ClassesPermises, new string[] {"Archer", "Mage", "Guerrier", "Assassin", "Moine" });
            Utility.PrintColoredText(classes, ConsoleColor.DarkYellow);

            int choixClasse = InputManager.PromptIntCursor(0, Personnage.ClassesPermises.Count - 1, "Choissisez votre classe: ", "Choix invalide");

            Classe classeChoisis = (Classe)choixClasse;

            AfficherArmesDisponibles(classeChoisis);
            Arme armeChoisis = Personnage.ArmesPermises[classeChoisis][InputManager.PromptIntCursor(0, Personnage.ArmesPermises[classeChoisis].Count() - 1, "Choississez votre arme: ", "Choix non valide")];
            List<Sort> sortsChoisis = new List<Sort>();
            if (classeChoisis == Classe.Mage)
            {
                AfficherSortsDisponibles();
                sortsChoisis.Add(ChoisirSort());
            }
            return new Personnage(nom, classeChoisis, sortsChoisis, armeChoisis);
        }

        private static Sort ChoisirSort()
        {
            int longueur = Personnage.SortsDisponible.Count();
            int choixSort = InputManager.PromptIntCursor(0, longueur, "Choissisez votre sort: ", "Entrée invalide");
            return Personnage.SortsDisponible[choixSort];
        }

        private static void AfficherSortsDisponibles()
        {
            int i = 0;
            foreach (Sort sort in Personnage.SortsDisponible)
            {
                Utility.PrintColoredText($"{i}. {sort.Nom}\n", ConsoleColor.DarkYellow);
                i++;
            }
        }

        public static void AfficherArmesDisponibles(Classe classe)
        {
            int index = 0;
            foreach (Arme arme in Personnage.ArmesPermises[classe])
            {
                Utility.PrintColoredText($"{index}. " +  arme.ToString() + "\n", ConsoleColor.DarkYellow);
                index++;
            }
        }
    }
}