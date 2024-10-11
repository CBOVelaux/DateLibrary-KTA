using DateLibrary.DateHelpers;

namespace DateLibrary.Tests
{
    public class JourOuvrableTest
    {
        private const string _expectedDate = "07/01/2025";

        [Fact]
        public void DateCalculPositiveJourOuvreeFromDate_MustReturn07012025()
        {
            var jourOuvrableCalculator = new JourOuvrableCalculator();

            var resultat2 = jourOuvrableCalculator.DateCalculPositiveJourOuvreeFromDate(
                nombreDeJour: 5,
                country: Countries.France,
                dateStart: new DateTime(2024, 12, 28));

            Assert.Equal("07/01/2025",resultat2.Date.ToShortDateString());
        }

        [Fact]
        public void DateCalculNegativeJourOuvree_MustReturnDate()
        {
            var jourOuvrableCalculator = new JourOuvrableCalculator();

            var resultat2 = jourOuvrableCalculator.DateCalculNegativeJourOuvree(
                nombreDeJour: 5,
                country: Countries.France
                );

            Assert.Equal(_expectedDate, resultat2.Date.ToShortDateString());
        }

    }
}