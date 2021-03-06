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
        private static string chaineConnection = "server=localhost;user id=root;database=gsb_frais;SslMode=none";
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

        // Assesseur de la connexion
        public ConnexionSql getConnexionSql()
        {
            if (connexionGSB == null)
            {
                connexionGSB = new ConnexionSql();
            }
            return connexionGSB;
        }

        // execution d'une requete select
        public void reqSelect(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.reader = this.command.ExecuteReader();
            this.finCurseur = false;
            this.suivant();
        }

        // execution d'une requete update
        public void reqUpdate(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connexion);
            this.command.ExecuteNonQuery();
            this.finCurseur = true;
        }

        // récupération d'un champ
        public Object champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }

        // passage à la ligne suivante du curseur
        public void suivant()
        {
            if (!this.finCurseur)
            {
                this.finCurseur = !this.reader.Read();
            }
        }

        // test de la fin du curseur
        public Boolean fin()
        {
            return this.finCurseur;
        }

        // fermeture de la connexion
        public void close()
        {
            this.connexion.Close();
        }
    }

}
