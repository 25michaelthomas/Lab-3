﻿namespace Packt.Shared;

// this file simulates an autogenerated class

public partial class Person
{
  // a readonly property defined using C# 1 - 5 syntax
  public string Origin
  {
    get
    {
      return string.Format("{0} was born on {1}",
        arg0: Name, arg1: HomePlanet);
    }
  }

  // two readonly properties defined using C# 6+ lambda expression body syntax
  public string Greeting => $"{Name} says 'Hello!'";
  public int Age => DateTime.Today.Year - DateOfBirth.Year;

  // a read-write property defined using C# 3.0 syntax
  public string? FavoriteIceCream { get; set; } // auto-syntax

  // a private field to store the property value
  private string? favoritePrimaryColor;

  // a public property to read and write to the field
  public string? FavoritePrimaryColor
  {
    get
    {
      return favoritePrimaryColor;
    }
    set
    {
      switch (value?.ToLower())
      {
        case "red":
        case "green":
        case "blue":
          favoritePrimaryColor = value;
          break;
        default:
          throw new ArgumentException(
            $"{value} is not a primary color. " +
            "Choose from: red, green, blue.");
      }
    }
  }

  // indexers
  public Person this[int index]
  {
    get
    {
      return Children[index]; // pass on to the List<T> indexer
    }
    set
    {
      Children[index] = value;
    }
  }

  public Person this[string name]
  {
    get
    {
      return Children.Find(p => p.Name == name);
    }
    set
    {
      Person found = Children.Find(p => p.Name == name);
      if (found is not null) found = value;
    }
  }

  // Is this person married to anyone?
  public bool Married => Spouses.Any();

  // Allow multiple spouses.
  public List<Person> Spouses = new();

  // static method to marry
  public static void Marry(Person p1, Person p2)
  {
    if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
    {
      throw new ArgumentException(
        string.Format("{0} is already married to {1}.",
        arg0: p1.Name, arg1: p2.Name));
    }
    else
    {
      p1.Spouses.Add(p2);
      p2.Spouses.Add(p1);
    }
  }

  // instance method to marry
  public void Marry(Person partner)
  {
    Marry(this, partner);
  }

  public void OutputSpouses()
  {
    if (Married)
    {
      string term = Spouses.Count == 1 ? "person" : "people";
      WriteLine($"{Name} is married to {Spouses.Count} {term}:");
      foreach (Person spouse in Spouses)
      {
        WriteLine($"  {spouse.Name}");
      }
    }
    else
    {
      WriteLine($"{Name} is not married.");
    }
  }

  // static method to "multiply"
  public static Person Procreate(Person p1, Person p2)
  {
    if (!p1.Spouses.Contains(p2))
    {
      throw new ArgumentException(
        string.Format("{0} must be married to {1} to procreate with them.",
        arg0: p1.Name, arg1: p2.Name));
    }

    Person baby = new()
    {
      Name = $"Baby of {p1.Name} and {p2.Name}",
      DateOfBirth = DateTime.Now
    };

    p1.Children.Add(baby);
    p2.Children.Add(baby);

    return baby;
  }

  // instance method to "multiply"
  public Person ProcreateWith(Person partner)
  {
    return Procreate(this, partner);
  }

  // operator to "marry"
  public static bool operator +(Person p1, Person p2)
  {
    Marry(p1, p2);
    return p1.Married && p2.Married; // confirm they are both now married
  }

  // operator to "multiply"
  public static Person operator *(Person p1, Person p2)
  {
    return Procreate(p1, p2);
  }

  // method with a local function
  public static int Factorial(int number)
  {
    if (number < 0)
    {
      throw new ArgumentException(
        $"{nameof(number)} cannot be less than zero.");
    }
    return localFactorial(number);

    int localFactorial(int localNumber) // local function
    {
      if (localNumber == 0) return 1;
      return localNumber * localFactorial(localNumber - 1);
    }
  }
}
