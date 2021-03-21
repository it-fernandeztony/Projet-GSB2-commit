//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : FERNANDEZ Tony
//Created On: ‎samedi ‎6 ‎mars ‎2021, ‏‎18:48:43
//Last Modified on : ‎dimanche ‎21 ‎mars ‎2021, ‏‎11:16:37
//‎Copy Rights : GSB
//Description : Classe de gestion de date
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace WindowsServiceClotureDeFiche
{
    /// <summary>
    /// Classe de gestion de date
    /// </summary>
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
        /// <param name="date">Une date</param>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisPrecedent(DateTime date)
        {
            return date.AddMonths(-1).ToString("MM");
        }

        /// <summary>
        /// Retourne le mois suivant du mois actuel
        /// </summary>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisSuivant()
        {
            return GetMoisSuivant(DateTime.Today); // Appel de la méthode GetMoisSuivant qui prend un paramètre
        }

        /// <summary>
        /// Retourne le mois suivant de la date entrée en paramètre
        /// </summary>
        /// <param name="date">Une date</param>
        /// <returns>Retourne un mois sous la forme -MM- de type string</returns>
        public static string GetMoisSuivant(DateTime date)
        {
            return date.AddMonths(1).ToString("MM"); 
        }

        /// <summary>
        /// Retourne vrai si la date du jour se trouve entre les deux jours entrés en paramètre
        /// </summary>
        /// <param name="jour1">Le jour le plus petit</param>
        /// <param name="jour2">Le jour le plus grand</param>
        /// <returns>Retourne vrai ou faux</returns>
        public static Boolean Entre(int jour1, int jour2)
        {

            return Entre(jour1, jour2, DateTime.Today);

        }

        /// <summary>
        /// Retourne vrai si la date entrée en paramètre se trouve entre les deux jours 
        /// </summary>
        /// <param name="jour1">Le jour le plus petit</param>
        /// <param name="jour2">Le jour le plus grand</param>
        /// <param name="date">Une date</param>
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
