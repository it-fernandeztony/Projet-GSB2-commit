
using System;
using System.ServiceProcess;
using System.Timers;
using WindowsServiceClotureDeFiche.Modele;

namespace WindowsServiceClotureDeFiche
{
    static class Program
    {
        private static System.Timers.Timer unTimer;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            SetTimer();
            Console.ReadLine();
            unTimer.Stop();
            unTimer.Dispose();
        }

        /// <summary>
        /// Création du timer
        /// </summary>
        private static void SetTimer()
        {
            // Créer un timer avec un interval de 2 secondes
            unTimer = new System.Timers.Timer(2000);
            // Ajout d'un événement lorsque le timer est écoulé 
            unTimer.Elapsed += OnTimedEvent;
            unTimer.AutoReset = true;
            unTimer.Enabled = true;
        }

        /// <summary>
        /// Evénement fin de timer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            // Connexion à la bdd et récupération du curseur:

            ConnexionSql crs = ConnexionSql.getConnexionSql();

            // On vérifie qu'on est bien entre le 1 et le 10 du mois:
            if (GestionDeDates.Entre(1, 10) == true)
            {

                // Récupération des fiches du mois précédent et maj de celles-ci:
                // Récupération du mois précédent et son année
                string moisPrecedent = GestionDeDates.GetMoisPrecedent();
                string annee = DateTime.Today.AddMonths(-1).ToString("yyyy");
                string mois = annee + moisPrecedent;
                crs.reqUpdate("UPDATE fichefrais SET idetat='CL' WHERE mois =" + mois + " AND idetat='CR'");
            }
            // Si on est après le 20 du mois:
            if (GestionDeDates.Entre(20, 31) == true)
            {
                ;
                // Récupération des fiches du mois précédent et maj de celles-ci:
                string moisPrecedent = GestionDeDates.GetMoisPrecedent();
                string annee = DateTime.Today.AddMonths(-1).ToString("yyyy");
                string mois = annee + moisPrecedent;

                crs.reqUpdate("UPDATE fichefrais SET idetat='RB' WHERE mois = " + mois + " AND idetat='VA'");

            }
            crs.close();
        }
    }
}
