using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass()]
public class TrophiesRepositoryTests
{
    private TrophiesRepository repository;

    [TestInitialize]
    public void Setup()
    {
        repository = new TrophiesRepository();
    }

    [TestMethod]
    public void GetTest()
    {
        var trophies = repository.Get();

        Assert.AreEqual(5, trophies.Count);
        Assert.AreEqual("Fodbold", trophies[0].Competition);
    }

    [TestMethod]
    public void GetByIdTest()
    {
        int trophyIdToFind = 1;

        var trophy = repository.GetById(trophyIdToFind);

        Assert.IsNotNull(trophy);
        Assert.AreEqual("Fodbold", trophy.Competition);
        Assert.AreEqual(1999, trophy.Year);
    }

    [TestMethod]
    public void UpdateTest()
    {
        var newValues = new Trophy(0, "Updated Trophy", 2025);
        int trophyIdToUpdate = 1;

        var updatedTrophy = repository.Update(trophyIdToUpdate, newValues);

        Assert.AreEqual("Updated Trophy", updatedTrophy.Competition);
        Assert.AreEqual(2025, updatedTrophy.Year);
    }
}