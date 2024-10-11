using DateLibrary.DateHelpers;

namespace DateLibrary.Tests
{
    public class JourOuvrableTest
    {
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
    }
}