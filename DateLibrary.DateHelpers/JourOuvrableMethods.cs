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

        /// <summary>
        /// Vérifie si le jour passé un weekend
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns>bool</returns>
        public  bool IsWeekend(DateTime currentDate)
        {
            return currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// Vérifie si le jour passé est un jour de vacances
        /// </summary>
        /// <param name="franceHolidays"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public  bool IsHoliday(IList<DateTime> franceHolidays, DateTime currentDate)
        {
            return franceHolidays.Any(day => day == currentDate);
        }

        /// <summary>
        /// Vérifie si le jour retournée est ouvré, si non prends le jour qui précède
        /// </summary>
        /// <param name="holidaysDates"></param>
        /// <param name="currentDate"></param>
        /// <returns>Date</returns>
        public DateTime GetPreviousDayIfCurrentDateIsDateOff(IList<DateTime> holidaysDates, DateTime currentDate)
        {
            while (!IsNotDayOff(holidaysDates, currentDate))
            {
                currentDate = currentDate.AddDays(-1);
            }
            return currentDate;
        }

        /// <summary>
        /// Vérifie si le jour retournée est ouvré, si non prends le jour qui suit
        /// </summary>
        /// <param name="holidaysDates"></param>
        /// <param name="currentDate"></param>
        /// <returns>Date</returns>
        public DateTime GetNextDayIfCurrentDateIsDateOff(IList<DateTime> holidaysDates, DateTime currentDate)
        {
            while (!IsNotDayOff(holidaysDates, currentDate))
            {
                currentDate = currentDate.AddDays(1);
            }
            return currentDate;
        }

        /// <summary>
        /// Récupère la lsite de sjours fériés par pays 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public IList<DateTime> GetHolidaysDates(Countries country, DateTime dateCourante)
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
