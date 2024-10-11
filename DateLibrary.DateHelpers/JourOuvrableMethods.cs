using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateLibrary.DateHelpers
{
    public class JourOuvrableMethods
    {
        /// <summary>
        /// Appelle les deux méthodes qui teste si c'est vacances ou WE.
        /// </summary>
        /// <param name="holidaysDates"></param>
        /// <param name="currentDate"></param>
        /// <returns>bool</returns>
        public  bool IsNotDayOff(IList<DateTime> holidaysDates, DateTime currentDate)
        {
            return !IsHoliday(holidaysDates, currentDate)
                                && !IsWeekend(currentDate);
        }

        public  bool IsWeekend(DateTime currentDate)
        {
            return currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday;
        }

        public  bool IsHoliday(IList<DateTime> franceHolidays, DateTime currentDate)
        {
            return franceHolidays.Any(day => day == currentDate);
        }

        /// <summary>
        /// Récupère la lsite de sjours fériés par pays 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public  IList<DateTime> GetHolidaysDates(Countries country, DateTime dateCourante)
        {
            var anneeCourante = dateCourante.Year;
            switch (country)
            {
                case Countries.France:
                    return new FrancePublicHoliday().PublicHolidays(anneeCourante);
                case Countries.Belgique:
                    return new BelgiumPublicHoliday().PublicHolidays(anneeCourante);
                case Countries.Autralie:
                    return new AustraliaPublicHoliday().PublicHolidays(anneeCourante);
                case Countries.Espagne:
                    return new SpainPublicHoliday().PublicHolidays(anneeCourante);
                default:
                    return new FrancePublicHoliday().PublicHolidays(anneeCourante);
            }
        }

    }
}
