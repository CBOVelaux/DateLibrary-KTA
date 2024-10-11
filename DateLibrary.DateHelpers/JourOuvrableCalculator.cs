using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DateLibrary.DateHelpers
{
    /// <summary>
    /// Contient des méthodes qui aident à calculer les jours ouvrables en France.
    ///     Nugget ajouté pour la gestion des jours ouvrés : https://www.nuget.org/packages/PublicHoliday
    ///     Si je veux soustraire des jours je peux passer une valeur négative dans Add days
    /// </summary>
    public class JourOuvrableCalculator
    {
        private const int _dernierJourAnnee = 31;
        private const int _dernierMoisAnnee = 12;
        private const int _premierJourAnnee = 1;
        private const int _premierMoisAnnee = 1;

        //instancie jourOuvrableMethods pour accéder aux méthodes qui sont dedans.
        JourOuvrableMethods jourOuvrableMethods = new JourOuvrableMethods();

        /// <summary>
        /// Retranche un nombre de jour ouvrés à la date actuelle.
        /// </summary>
        /// <param name="nombreDeJour"> Nombre de jours à retrancher.</param>
        /// <returns>Date calculée en retranchant les jours ouvrés.</returns>
        public DateTime DateCalculNegativeJourOuvree(int nombreDeJour, Countries country)
        {

            DateTime currentDate = DateTime.Now;
            IList<DateTime> holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentDate);

            while (nombreDeJour > 0)
            {

                if (jourOuvrableMethods.IsNotDayOff(holidaysDates, currentDate))
                {
                    nombreDeJour--;
                }

                // Si je veux soustraire des jours je peux passer une valeur négative
                currentDate = currentDate.AddDays(-1);

                //Si je suis le premier janvier alors je dois charger les jours fériés de l'année précédente
                if (currentDate.Day == _premierJourAnnee && currentDate.Month == _premierMoisAnnee)
                {
                    var currentAnnee = currentDate.AddYears(-1);
                    holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentAnnee);
                }

            }
            return currentDate;
        }
        /// <summary>
        /// Ajoute un nombre de jour ouvrés à la date actuelle
        /// </summary>
        /// <param name="nombreDeJour"> Nombre de jours à ajouter.</param>
        /// <returns>Date calculée en ajoutant les jours ouvrés.</returns>
        public DateTime DateCalculPositiveJourOuvree(Countries country, int nombreDeJour)
        {
            DateTime currentDate = DateTime.Now;
            IList<DateTime> holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentDate);

            while (nombreDeJour > 0)
            {
                if (jourOuvrableMethods.IsNotDayOff(holidaysDates, currentDate))
                {
                    nombreDeJour--;
                }
                // Si je veux soustraire des jours je peux passer une valeur négative
                currentDate = currentDate.AddDays(+1);
                //Si je suis le 31/12 alors je dois charger les jours fériés de l'année suivante
                if (currentDate.Day == _dernierJourAnnee && currentDate.Month == _dernierMoisAnnee)
                {
                    var currentAnnee = currentDate.AddYears(1);
                    holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentAnnee);
                }
            }

            return currentDate;
        }

        //Troisième methode : Ajoute un nombre de jour ouvrés à la date une date donnée
        public DateTime DateCalculPositiveJourOuvreeFromDate(Countries country, int nombreDeJour, DateTime dateStart)
        {
            DateTime currentDate = dateStart;
            IList<DateTime> holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentDate);

            // Si je veux soustraire des jours je peux passer une valeur négative dans Add days

            while (nombreDeJour > 0)
            {
                if (jourOuvrableMethods.IsNotDayOff(holidaysDates, currentDate))
                {
                    nombreDeJour--;
                }
                // Si je veux soustraire des jours je peux passer une valeur négative
                currentDate = currentDate.AddDays(+1);
                //Si je suis le 31/12 alors je dois charger les jours fériés de l'année suivante
                if (currentDate.Day == 31 && currentDate.Month == 12)
                {
                    var currentAnnee = currentDate.AddYears(1);
                    holidaysDates = jourOuvrableMethods.GetHolidaysDates(country, currentAnnee);
                }
            }

            return currentDate;
        }






    }


}
