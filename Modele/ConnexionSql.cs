//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : FERNANDEZ Tony
//Created On: ‎samedi ‎6 ‎mars ‎2021, ‏‎02:55:34
//Last Modified on : ‎dimanche ‎21 ‎mars ‎2021, ‏‎10:06:00
//‎Copy Rights : GSB
//Description : Classe de connexion
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data.MySqlClient;


namespace WindowsServiceClotureDeFiche
{
    /// <summary>
    /// Classe de connexion
    /// </summary>
    public class ConnexionSql
    {
        // propriétés
        private  bool finCurseur=true; // fin du curseur atteinte
        private static string chaineConnection = "Database=gsb_frais;Data Source=localhost;User Id=root;password=;";
        private  MySqlConnection connexion; // chaine de connexion
        private  MySqlCommand command; // envoi de la requête à la base de données
        private  MySqlDataReader reader; // gestion du curseur
        private static ConnexionSql connexionGSB = null;
        
        // constructeur
        private  ConnexionSql()
        {
            this.connexion = new MySqlConnection(chaineConnection);
            this.connexion.Open();
        }

        /// <summary>
        /// Créer une connexion
        /// </summary>
        /// <returns>Retourne un objet de type ConnexionSql</returns>
        public static ConnexionSql GetConnexionSql()
        {
            connexionGSB = null;
            connexionGSB = new ConnexionSql();
            
            return connexionGSB;
        }

        /// <summary>
        /// Execution d'une requête select
        /// </summary>
        /// <param name="chaineRequete">La requête</param>
        public void ReqSelect(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.reader = this.command.ExecuteReader();
            this.finCurseur = false;
            this.Suivant();
        }

        /// <summary>
        /// Execution d'une requête update
        /// </summary>
        /// <param name="chaineRequete">La requête</param>
        public void ReqUpdate(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.command.ExecuteNonQuery();
            this.finCurseur = true;
        }

        /// <summary>
        /// Récupération d'un champ
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <returns>Retourne le nom d'un champ</returns>
        public Object Champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }

        /// <summary>
        /// Passage à la ligne suivante du curseur
        /// </summary>
        public void Suivant()
        {
            if (!this.finCurseur)
            {
                this.finCurseur = !this.reader.Read();
            }
        }

        /// <summary>
        /// Test de la fin du curseur
        /// </summary>
        /// <returns>Retourne vrai ou faux</returns>
        public Boolean Fin()
        {
            return this.finCurseur;
        }

        /// <summary>
        /// Fermeture de la connexion
        /// </summary>
        public void Close()
        {
            this.connexion.Close();
        }
    }

}
