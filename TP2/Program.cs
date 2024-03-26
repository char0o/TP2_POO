namespace TP2
{
    class Program
    {

        public static void Main(string[] args)
        {
            Personnage joueur = CreerPersonnage();
            Console.WriteLine(joueur.ToString());
        }
        public static Personnage CreerPersonnage()
        {
            string nom = InputManager.PromptStringCursor("Entrez le nom du personnage: ", "Le nom est invalide");
            string classes = Utility.CreateMenuFromList( Personnage.ClassesPermises, new string[] {"Archer", "Mage", "Guerrier", "Assassin", "Moine" });
            Console.WriteLine(classes);

            int choixClasse = InputManager.PromptIntCursor(0, Personnage.ClassesPermises.Count - 1,
                    "Choissisez votre classe: ", "Choix invalide");

            Classe classeChoisis = (Classe)choixClasse;

            AfficherArmesDisponibles(classeChoisis);
            int choixArme = -1;
            while (choixArme < 0 || !Personnage.ArmesPermises[classeChoisis].Contains((Arme)choixArme))
            {
                choixArme = InputManager.PromptIntCursor(0, Enum.GetValues(typeof(Arme)).Length,
                    "Choississez votre arme: ", "Entree non valide");
            }

            return new Personnage(nom, classeChoisis, new List<Sort>(), (Arme)choixArme);
        }
        public static void AfficherArmesDisponibles(Classe classe)
        {
            int index = 0;
            foreach (Arme arme in Enum.GetValues(typeof(Arme)))
            {
                if (Personnage.ArmesPermises[classe].Contains(arme))
                {
                    Utility.PrintColoredText($"{index}. " +  arme.ToString(), ConsoleColor.Green);
                }
                else
                {
                    Utility.PrintColoredText($"{index}. " + arme.ToString(), ConsoleColor.Red);
                }
                Console.WriteLine();
                index++;
            }
        }
    }
}