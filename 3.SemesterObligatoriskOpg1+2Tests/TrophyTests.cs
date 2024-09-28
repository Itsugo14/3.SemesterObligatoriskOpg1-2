using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestClass()]
public class TrophyTests
{
    [TestMethod()]
    public void ValidateCompetitionTest()
    {
        Trophy TooShortCompetition = new Trophy(1, "Fo", 1990);
        Assert.ThrowsException<ArgumentException>(() => TooShortCompetition.ValidateCompetition());

        Trophy NullCompetition = new Trophy(2, null, 1990);
        Assert.ThrowsException<ArgumentNullException>(() => NullCompetition.ValidateCompetition());
    }

    [TestMethod()]
    public void ValidateYearTest()
    {
        Trophy YearTooEarly = new Trophy(3, "Fodbold", 1969);
        Assert.ThrowsException<ArgumentException>(() => YearTooEarly.ValidateYear());

        Trophy YearTooLate = new Trophy(4, "Fodbold", 2025);
        Assert.ThrowsException<ArgumentException>(() => YearTooLate.ValidateYear());
    }

    [TestMethod()]
    public void ValidateToStringTest()
    {
        Trophy Trophy10 = new Trophy(10, "Roning", 2002);
        Trophy10.ToString();
        Assert.AreEqual(10, Trophy10.Id, "Roning", Trophy10.Competition, 2002, Trophy10.Year);
    }
}