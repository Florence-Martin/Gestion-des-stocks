using System;
namespace Gestion_des_stocks
{
    /// <summary>
    /// Classe Article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Attributs/propriétés
        /// </summary>
        public string? Nom;
        public string? Reference;
        public int? Stock;
        public int? Prix;

        /// <summary>
        /// Constructeur par recopie
        /// </summary>
        /// <param name="article"></param>
        public Article(Article article)
        {
            this.Nom = article.Nom;
            this.Reference = article.Reference;
            this.Stock = article.Stock;
            this.Prix = article.Prix;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Article()
        { }

        /// <summary>
        /// Méthode ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Nom: {this.Nom}, Prix: {this.Prix}, Référence: {this.Reference}, Stock: {this.Stock} ";
        }


    }
}



