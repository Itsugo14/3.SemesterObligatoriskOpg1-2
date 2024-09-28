public class Trophy
{
    public int Id { get; set; }
    public string? Competition { get; set; }
    public int Year { get; set; }

    public Trophy(int id, string? competition, int year)
    {
        Id = id;
        Competition = competition;
        Year = year;
    }

    public Trophy(Trophy other)
    {
        Id = other.Id;
        Competition = other.Competition;
        Year = other.Year;
    }

    public void ValidateCompetition()
    {
        if (Competition?.Length < 3)
        {
            throw new ArgumentException("Competition name needs to be at least 3 characters long");
        }

        if (Competition == null)
        {
            throw new ArgumentNullException("Competition name cannot be null");
        }
    }

    public void ValidateYear()
    {
        if (Year < 1970)
        {
            throw new ArgumentException("Year is invalid");
        }

        if (Year > 2024)
        {
            throw new ArgumentException("Year is invalid");
        }
    }

    public void Validate()
    {
        ValidateCompetition();
        ValidateYear();
    }

    public override string ToString()
    {
        return ($"Troyphy Id: {Id}, Competition: {Competition}, Year:{Year}");
    }
}
