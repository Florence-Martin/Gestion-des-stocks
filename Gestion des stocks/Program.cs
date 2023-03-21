// See https://aka.ms/new-console-template for more information
using Gestion_des_stocks;

/*
1) Rechercher un article par référence.
2) Ajouter un article au stock en vérifiant l’unicité de la référence.
3) Supprimer un article par référence.
4) Modifier un article par référence.
5) Rechercher un article par nom.
6) Rechercher un article par intervalle de prix de vente.
7) Afficher tous les articles.
8) Quitter 
 */

public class Programme
{
    private static Inventaire Inventaire = new Inventaire();


    public static void Main(String[] args)
    {
        int retour = -1;

        while (retour != 0)
        {
            Console.WriteLine("1) Rechercher un article par référence");
            Console.WriteLine("2) Ajouter un article au stock");
            Console.WriteLine("3) Supprimer un article par référence");
            Console.WriteLine("4) Modifier un article par référence");
            Console.WriteLine("5) Rechercher un article par nom");
            Console.WriteLine("6) Rechercher un article par intervalle de prix de vente");
            Console.WriteLine("7) Afficher tous les articles");
            Console.WriteLine("8) Quitter");

            retour = Int32.Parse(Console.ReadLine());

            switch (retour)
            {
                case 1:
                    RechercherReference();
                    break;

                case 2:
                    AjouterArticleStock();
                    break;

                case 3:
                    SupprimeReferenceArticle();
                    break;
                /*
                case 4:
                    ModifierArticleParReference();
                    break;
                */
                case 5:
                    RechercherNomArticle();
                    break;
                /*
                case 6:
                    RechercherPrixArticle();
                    break;
                */
                case 7:
                    ConsulterArticles();
                    break;

                default:
                    break;
            }
        }
    }


    /// <summary>
    /// Methode 1 rechercher article par référence
    /// </summary>
    public static void RechercherReference()
    {
        Console.Write("Entrez la référence de l'article à rechercher : ");
        string reference = Console.ReadLine();

        // Recherche de l'article existant dans l'inventaire
        Article article = Inventaire.RechercherReference(reference);

        if (article == null)
        {
            Console.WriteLine("Aucun article trouvé avec la référence spécifiée.");
            return;
        }
        else
        {
            Console.WriteLine(article.ToString());
        }

    }

    /// <summary>
    /// Methode 2 ajouter un article au stock
    /// </summary>
    public static void AjouterArticleStock()
    {
        Article article = new Article();


        // Saisie des valeurs des propriétés
        Console.Write("Saisir le nom de l'article : ");
        article.Nom = Console.ReadLine();

        Console.Write("Saisir la référence de l'article : ");
        article.Reference = Console.ReadLine();

        Console.Write("Saisir le stock : ");
        article.Stock = int.Parse(Console.ReadLine());

        Console.Write("Saisir le prix : ");
        article.Prix = int.Parse(Console.ReadLine());

        // Ajout de l'article à l'inventaire
        Inventaire.AjouterArticleStock(article);
    }

    /// <summary>
    /// Methode 3 Supprimer un article par référence
    /// </summary>
    public static void SupprimeReferenceArticle()
    {
        Console.Write("Entrez la référence de l'article à supprimer : ");
        string reference = Console.ReadLine();

        // Recherche de l'article existant dans l'inventaire
        Article article = Inventaire.RechercherReference(reference);

        if (article == null)
        {
            Console.WriteLine("Aucun article trouvé avec la référence spécifiée.");
            return;
        }
        else
        {
            //Console.WriteLine("Votre article a été supprimé.");
            Inventaire.SupprimeReferenceArticle(reference);
        }
    }

    /*
    /// <summary>
    /// Methode 4 Modifier un article par référence
    /// </summary>
    public static void ModifierArticleParReference()
    {
        bool continuer = true;
        while (continuer)
        {
            Console.WriteLine("Entrez la référence de l'article à modifier : ");
            string reference = Console.ReadLine();

            Console.WriteLine("Entrez le nouveau nom de l'article : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Entrez le nouveau prix de l'article : ");
            double prix = double.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le nouveau stock de l'article : ");
            int stock = int.Parse(Console.ReadLine());

            Article nouvelArticle = new Article();
            Inventaire.ModifierArticleParReference(reference, nouvelArticle);

            Console.WriteLine("Voulez-vous modifier un autre article ? (o/n)");
            string reponse = Console.ReadLine();

            if (reponse.ToLower() == "n")
            {
                continuer = false;
            }
        }
    }
    */

    /// <summary>
    /// Methode 5 Rechercher un article par nom
    /// </summary>
    public static void RechercherNomArticle()
    {
        Console.WriteLine("Entrez le nom de l'article à rechercher");
        string nom = Console.ReadLine();

        // Recherche de l'article existant dans l'inventaire
        Article article = Inventaire.RechercherNomArticle(nom);

        if (article == null)
        {
            Console.WriteLine("Aucun article de ce nom trouvé.");
            return;
        }
        else
        {
            Console.WriteLine(article.ToString());
        }
    }

    /// <summary>
    /// Methode 6 Rechercher un article par interval de prix
    /// </summary>
    /// <param name="articles"></param>
    public static void RechercherPrixArticle(List<Article> articles)
    {
        Console.WriteLine("Recherche par prix min et prix max :");

        int prixMin;
        int prixMax;


        // Boucle pour saisir l'intervalle de prix
        while (true)
        {
            Console.Write("Entrez un prix minimum : ");
            if (int.TryParse(Console.ReadLine(), out prixMin))
            {
                break;
            }
            Console.WriteLine("Veuillez entrer un nombre valide.");
        }
        while (true)
        {
            Console.Write("Entrez un prix maximum : ");
            if (int.TryParse(Console.ReadLine(), out prixMax))
            {
                break;
            }
            Console.WriteLine("Veuillez entrer un nombre valide.");
        }

        // Recherche des articles dans l'intervalle de prix
        List<Article> resultats = Inventaire.RechercherPrixArticle(articles, prixMin, prixMax);

        // Affichage des articles trouvés
        Console.WriteLine("Articles trouvés :");
        foreach (Article article in resultats)
        {
            Console.WriteLine($"- {article.Nom} : {article.Prix}");
        }
    }


    /// <summary>
    /// Methode 7 Afficher tous les articles
    /// </summary>
    public static void ConsulterArticles()
    {
        foreach (Article article in Inventaire.ListeArticles)
        {
            Console.WriteLine($"Nom : {article.Nom}");
            Console.WriteLine($"Référence : {article.Reference}");
            Console.WriteLine($"Stock : {article.Stock}");
            Console.WriteLine($"Prix : {article.Prix}");
            Console.WriteLine();
        }
    }
}

