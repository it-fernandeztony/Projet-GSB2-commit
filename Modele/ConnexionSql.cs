using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Sql;


namespace WindowsServiceClotureDeFiche
{
    class ConnexionSql
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
        public static ConnexionSql getConnexionSql()
        {
            connexionGSB = null;
            connexionGSB = new ConnexionSql();
            
            return connexionGSB;
        }

        /// <summary>
        /// Execution d'une requête select
        /// </summary>
        /// <param name="chaineRequete"></param>
        public void reqSelect(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.reader = this.command.ExecuteReader();
            this.finCurseur = false;
            this.suivant();
        }

        /// <summary>
        /// Execution d'une requête update
        /// </summary>
        /// <param name="chaineRequete"></param>
        public void reqUpdate(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.command.ExecuteNonQuery();
            this.finCurseur = true;
        }

        /// <summary>
        /// Récupération d'un champ
        /// </summary>
        /// <param name="nomChamp"></param>
        /// <returns>Retourne le nom d'un champ</returns>
        public Object champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }

        /// <summary>
        /// Passage à la ligne suivante du curseur
        /// </summary>
        public void suivant()
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
        public Boolean fin()
        {
            return this.finCurseur;
        }

        /// <summary>
        /// Fermeture de la connexion
        /// </summary>
        public void close()
        {
            this.connexion.Close();
        }
    }

}
