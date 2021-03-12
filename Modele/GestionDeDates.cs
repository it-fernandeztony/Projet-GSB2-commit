using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceClotureDeFiche.Modele
{
    public abstract class GestionDeDates
    {
        /// <summary>
        /// Retourne le mois précédent le mois actuel
        /// </summary>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisPrecedent()
        {
            DateTime dateDuJour = DateTime.Today; // Permet d'avoir la date d'aujourd'hui
            
            return GetMoisPrecedent(dateDuJour); // Appel de la méthode GetMoisPrecedant avec paramètre
        }

        /// <summary>
        /// Retourne le mois précédent la date entrée en paramètre 
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisPrecedent(DateTime date)
        {
            return date.AddMonths(-1).ToString("MM");
        }

        /// <summary>
        /// Retourne le mois suivant du mois actuel
        /// </summary>
        /// <returns>Retourne un mois sous la forme -MM- de type string/returns>
        public static string GetMoisSuivant()
        {
            return GetMoisSuivant(DateTime.Today); // Appel de la méthode GetMoisSuivant qui prend un paramètre
        }

        /// <summary>
        /// Retourne le mois suivant de la date entrée en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisSuivant(DateTime date)
        {
            return date.AddMonths(1).ToString("MM"); 
        }

        /// <summary>
        /// Retourne vrai si la date du jour se trouve entre les deux jours entrés en paramètre
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <returns>Retourne vrai ou faux</returns>
        public static Boolean Entre(int jour1, int jour2)
        {

            return Entre(jour1, jour2, DateTime.Today);

        }

        /// <summary>
        /// Retourne vrai si la date entrée en paramètre se trouve entre les deux jours 
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <param name="date"></param>
        /// <returns>Retourne vrai ou faux</returns>
        public static Boolean Entre(int jour1, int jour2, DateTime date)
        {
            int jour = date.Day;

            if (jour1 <= jour & jour <= jour2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
