
public class TrophiesRepository
{
    private List<Trophy> trophies;
    private int nextId;

    public TrophiesRepository()
    {
        trophies = new List<Trophy>
        {
            new Trophy(1, "Fodbold", 1999),
            new Trophy(2, "Badminton", 2002),
            new Trophy(3, "Svømning", 2020),
            new Trophy(4, "Længdespring", 1976),
            new Trophy(5, "HotdogSpisning", 1987)
        };
    }

    public List<Trophy> Get(int? year = null, bool sortByCompetition = false, bool sortByYear = false)
    {
        var filteredTrophies = trophies.Select(t => new Trophy(t)).ToList();

        if (year.HasValue)
        {
            filteredTrophies = filteredTrophies.Where(t => t.Year == year.Value).ToList();
        }

        if (sortByCompetition)
        {
            filteredTrophies = filteredTrophies.OrderBy(t => t.Competition).ToList();
        }
        else if (sortByYear)
        {
            filteredTrophies = filteredTrophies.OrderBy(t => t.Year).ToList();
        }

        return filteredTrophies;
    }

    public Trophy GetById(int? id)
    {
        var trophy = trophies.FirstOrDefault(t => t.Id == id);
        if (id == null)
        {
            throw new KeyNotFoundException("The given Trophy Id could not be found");
        }
        else
        {
            Console.WriteLine($"Trophy found: Id = {id}");
        }

        return trophy = new Trophy(trophy);
    }

    public Trophy Add(Trophy trophy)
    {
        trophy.Id = nextId++;            
        trophies.Add(new Trophy(trophy)); 
        return trophy;                   
    }

    public Trophy Remove(int id)
    {
        var trophy = trophies.FirstOrDefault(t => t.Id == id);
        if (trophy == null)
        {
            throw new KeyNotFoundException("The given Trophy Id could not be found");
        }
        else
        {
            trophies.Remove(trophy);
        }
        return trophy;
        
    }

    public Trophy Update(int id, Trophy newValues)
    {
        var trophy = trophies.FirstOrDefault(t => t.Id == id);
        if (trophy == null)
        {
            throw new KeyNotFoundException("The given Trophy Id could not be found");
        }

        trophy.Competition = newValues.Competition;
        trophy.Year = newValues.Year;

        return trophy;
    }
}

