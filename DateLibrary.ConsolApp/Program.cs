using DateLibrary.DateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateLibrary.ConsolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JourOuvrableCalculator jourOuvrableCalculator = new JourOuvrableCalculator();
            Console.WriteLine("Date négative 2 j");
            var resultat = jourOuvrableCalculator.DateCalculNegativeJourOuvree(2, country :Countries.France);
            Console.WriteLine(resultat.ToShortDateString());

            var resultat1 = jourOuvrableCalculator.DateCalculPositiveJourOuvree(nombreDeJour: 4, country: Countries.France);
            Console.WriteLine(resultat1.ToShortDateString());

            var resultat2 = jourOuvrableCalculator.DateCalculPositiveJourOuvreeFromDate(nombreDeJour: 5, country: Countries.France, dateStart: new DateTime(2024,12,28));
            Console.WriteLine("A partir d'une date spécifiée : "); 
            Console.WriteLine(resultat2.ToShortDateString());
        }
    }
}
