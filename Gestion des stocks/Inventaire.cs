using System;
namespace Gestion_des_stocks
{
        /// <summary>
        /// Class Inventaire
        /// </summary>
        public class Inventaire
        {
            public List<Article> ListeArticles = new List<Article>();


            /// <summary>
            /// Methode 1 pour rechercher une référence
            /// </summary>
            /// <param name="reference"></param>
            /// <returns></returns>
            public Article RechercherReference(string reference)
            {
                // Parcourir la liste d'articles
                foreach (Article article in ListeArticles)
                {
                    // Vérifier si la référence correspond à celle recherchée
                    if (article.Reference == reference)
                    {
                        // Renvoyer l'article correspondant
                        return article;
                    }
                }

                // Renvoyer null si aucun article ne correspond à la référence
                return null;
            }

            /// <summary>
            /// Methode 2 pour ajouter articles
            /// </summary>
            /// <param name="article"></param>
            public void AjouterArticleStock(Article article)
            {
                // Vérifie si l'article existe déjà dans la liste en utilisant la référence de l'article
                if (ListeArticles.Exists(a => a.Reference == article.Reference))
                {
                    Console.WriteLine("L'article existe déjà dans la liste !");
                }
                else
                {
                    ListeArticles.Add(article);
                    Console.WriteLine("L'article a été ajouté à la liste !");
                }
            }


            /// <summary>
            /// Methode 3 pour supprimer article par référence
            /// </summary>
            /// <param name="reference"></param>
            public void SupprimeReferenceArticle(string reference)
            {
                ListeArticles.RemoveAll(a => a.Reference == reference);
            }


            /// <summary>
            /// Méthode 4 pour modifier l'article par référence
            /// </summary>
            /// <param name="reference"></param>
            /// <param name="nouvelArticle"></param>
            public void ModifierArticleParReference(string reference)
            {
                // cherche article dans la liste par la référence
                Article articleTrouve = ListeArticles.Find(a => a.Reference == reference);

                // vérifier si article trouvé
                if (articleTrouve != null)
                {
                    Article nouvelArticle = new Article();
                    //si vrai, mise à jour des attributs
                    articleTrouve.Nom = nouvelArticle.Nom;
                    articleTrouve.Reference = nouvelArticle.Reference;
                    articleTrouve.Prix = nouvelArticle.Prix;
                    articleTrouve.Stock = nouvelArticle.Stock;

                    Console.WriteLine("L'article a été modifié avec succès !");
                }
                else
                {
                    Console.WriteLine("Aucun article n'existe avec cette référence !");
                }
            }

            /// <summary>
            /// Methode 5 pour rechercher par nnom
            /// </summary>
            /// <returns></returns>
            public Article RechercherNomArticle(string nom)
            {
                foreach (Article article in ListeArticles)
                {
                    if (article.Nom == nom)
                    {
                        return article;
                    }
                }
                return null;
            }

            /// <summary>
            /// Methode 6 pour rechercher article dans une fourchette de prix
            /// </summary>
            /// <param name="prixMin"></param>
            /// <param name="prixMax"></param>
            /// <returns></returns>
            // List<Article>" est le type de retour de la méthode
            public static List<Article> RechercherPrixArticle(List<Article> articles, int prixMin, int prixMax)
            {
                // on ajoute une sous liste
                var resultats = new List<Article>();

                foreach (Article article in articles)
                {
                    if (article.Prix >= prixMin && article.Prix <= prixMax)
                    {
                        resultats.Add(article);
                    }
                }
                return resultats;
            }
        }
    }


