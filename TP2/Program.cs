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
            string classes = InputManager.CreateMenuFromEnum<Classe>(
                new string[] {"Archer", "Mage", "Guerrier", "Assassin",
                    "Moine", "Troll", "Goblin", "Squelette", "Faermoore"});
            Console.WriteLine(classes);
            int choixClasse = InputManager.PromptIntCursor(0, Enum.GetValues(typeof(Classe)).Length - 1,
                "Choissisez votre classe: ", "Choix invalide");
            string armes = InputManager.CreateMenuFromEnum<Arme>(
                new string[] { "Mains Nues", "Épée et bouclier", "Épée à deux mains", "Arc" });
            Console.WriteLine(armes);
            int choixArme = InputManager.PromptIntCursor(0, Enum.GetValues(typeof(Arme)).Length - 1,
                "Choissisez votre arme: ", "Choix invalide");
            return new Personnage(nom, (Classe)choixClasse, new List<Sort>(), (Arme)choixArme);
        }
    }
}