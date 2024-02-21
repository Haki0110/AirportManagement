using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Airport> airports = new List<Airport>();
    static List<FixedWing> fixedWings = new List<FixedWing>();
    static List<Helicopter> helicopters = new List<Helicopter>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Airport Management");
            Console.WriteLine("2. Fixed Wing Airplane Management");
            Console.WriteLine("3. Helicopter Management");
            Console.WriteLine("4. Close Program");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AirportManagement();
                        break;
                    case 2:
                        FixedWingAirplaneManagement();
                        break;
                    case 3:
                        HelicopterManagement();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AirportManagement()
    {
        Console.WriteLine("Airport Management Menu:");
        Console.WriteLine("1. Create New Airport");
        Console.WriteLine("2. Display List of All Airports");
        Console.WriteLine("3. Display Status of an Airport");
        Console.WriteLine("4. Add Fixed Wing Airplane to Airport");
        Console.WriteLine("5. Remove Helicopter from Airport");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    CreateNewAirport();
                    break;
                case 2:
                    DisplayAllAirports();
                    break;
                case 3:
                    DisplayAirportStatus();
                    break;
                case 4:
                    AddFixedWingToAirport();
                    break;
                case 5:
                    RemoveHelicopterFromAirport();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void FixedWingAirplaneManagement()
    {
        Console.WriteLine("Fixed Wing Airplane Management Menu:");
        Console.WriteLine("1. Display List of All Fixed Wing Airplanes");
        Console.WriteLine("2. Change Plane Type and Min Needed Runway Size");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    DisplayAllFixedWingAirplanes();
                    break;
                case 2:
                    ChangePlaneTypeAndRunwaySize();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void HelicopterManagement()
    {
        Console.WriteLine("Helicopter Management Menu:");
        Console.WriteLine("1. Display List of All Helicopters");
        Console.WriteLine("2. Add Helicopter to Airport");
        Console.WriteLine("3. Remove Helicopter from Airport");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    DisplayAllHelicopters();
                    break;
                case 2:
                    AddHelicopterToAirport();
                    break;
                case 3:
                    RemoveHelicopterFromAirport();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void CreateNewAirport()
    {
        string airportID = string.Empty;
        do
        {
            Console.WriteLine("Type your Airport ID (Started by AP: ");
            airportID = Console.ReadLine();
            if (!IsValidIDInput(airportID, 0))
            {
                Console.WriteLine("AirportID is not reach the requirement. Please retype! ");
            }
        } while (!IsValidIDInput(airportID, 0));

        Console.WriteLine("Enter Airport ID:");
        string airportId = Console.ReadLine();

        Console.WriteLine("Enter Airport Name:");
        string airportName = Console.ReadLine();

        Console.WriteLine("Enter Runway Size:");
        int runwaySize;
        if (int.TryParse(Console.ReadLine(), out runwaySize))
        {
            Console.WriteLine("Enter Max Fixedwing Parking Place:");
            int maxFixedWingParkingPlace;
            if (int.TryParse(Console.ReadLine(), out maxFixedWingParkingPlace))
            {
                Console.WriteLine("Enter Max Rotated Wing Parking Place:");
                int maxRotatedWingParkingPlace;
                if (int.TryParse(Console.ReadLine(), out maxRotatedWingParkingPlace))
                {
                    Airport newAirport = new Airport(airportId, airportName, runwaySize, maxFixedWingParkingPlace, maxRotatedWingParkingPlace);
                    airports.Add(newAirport);
                    Console.WriteLine("Airport created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input for Max Rotated Wing Parking Place. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Max Fixedwing Parking Place. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Runway Size. Please enter a valid number.");
        }
    }

    static bool IsValidIDInput(string input, int id)
    {
        if (input.Length != 7)
        {
            return false;
        }

        switch (id)
        {
            case 0:
                {
                    if (input.Substring(0, 2) != "AP")
                    {
                        return false;
                    }
                    break;
                }

            case 1:
                {
                    if (input.Substring(0, 2) != "FW")
                    {
                        return false;

                    }
                    break;
                }
            case 2:
                {
                    if (input.Substring(0, 2) != "RW")
                    {
                        return false;
                    }
                    break;
                }
        }
        return true;
    }


        static void DisplayAllAirports()
    {
        Console.WriteLine("List of All Airports:");
        foreach (var airport in airports)
        {
            Console.WriteLine(airport.ToString());
        }
    }

    static void DisplayAirportStatus()
    {
        Console.WriteLine("Enter Airport ID:");
        string airportId = Console.ReadLine();

        Airport airport = airports.FirstOrDefault(a => a.Id == airportId);
        if (airport != null)
        {
            Console.WriteLine("Airport Status:");
            Console.WriteLine(airport.ToString());
        }
        else
        {
            Console.WriteLine("Airport not found. Please enter a valid Airport ID.");
        }
    }

    static void AddFixedWingToAirport()
    {
        Console.WriteLine("Enter Fixed Wing Airplane ID:");
        string fixedWingId = Console.ReadLine();

        FixedWing fixedWing = fixedWings.FirstOrDefault(fw => fw.Id == fixedWingId);
        if (fixedWing != null)
        {
            Console.WriteLine("Enter Airport ID:");
            string airportId = Console.ReadLine();

            Airport airport = airports.FirstOrDefault(a => a.Id == airportId);
            if (airport != null)
            {
                if (fixedWing.MinNeededRunwaySize <= airport.RunwaySize)
                {
                    airport.AddFixedWing(fixedWing);
                    Console.WriteLine("Fixed Wing Airplane added to the airport successfully.");
                }
                else
                {
                    Console.WriteLine("The Min Needed Runway Size of the Fixed Wing Airplane exceeds the Airport Runway Size.");
                }
            }
            else
            {
                Console.WriteLine("Airport not found. Please enter a valid Airport ID.");
            }
        }
        else
        {
            Console.WriteLine("Fixed Wing Airplane not found. Please enter a valid Fixed Wing Airplane ID.");
        }
    }

    static void RemoveHelicopterFromAirport()
    {
        Console.WriteLine("Enter Helicopter ID:");
        string helicopterId = Console.ReadLine();

        Helicopter helicopter = helicopters.FirstOrDefault(h => h.Id == helicopterId);
        if (helicopter != null)
        {
            Console.WriteLine("Enter Airport ID:");
            string airportId = Console.ReadLine();

            Airport airport = airports.FirstOrDefault(a => a.Id == airportId);
            if (airport != null)
            {
                airport.RemoveHelicopter(helicopter);
                Console.WriteLine("Helicopter removed from the airport successfully.");
            }
            else
            {
                Console.WriteLine("Airport not found. Please enter a valid Airport ID.");
            }
        }
        else
        {
            Console.WriteLine("Helicopter not found. Please enter a valid Helicopter ID.");
        }
    }

    static void DisplayAllFixedWingAirplanes()
    {
        Console.WriteLine("List of All Fixed Wing Airplanes:");
        foreach (var fixedWing in fixedWings)
        {
            Console.WriteLine(fixedWing.ToString());
        }
    }

    static void DisplayAllHelicopters()
    {
        Console.WriteLine("List of All Helicopters:");
        foreach (var helicopter in helicopters)
        {
            Console.WriteLine(helicopter.ToString());
        }
    }

    static void ChangePlaneTypeAndRunwaySize()
    {
        Console.WriteLine("Enter Fixed Wing Airplane ID:");
        string fixedWingId = Console.ReadLine();

        FixedWing fixedWing = fixedWings.FirstOrDefault(fw => fw.Id == fixedWingId);
        if (fixedWing != null)
        {
            Console.WriteLine("Enter New Plane Type (CAG, LGR, PRV):");
            string newPlaneType = Console.ReadLine();
            fixedWing.ChangePlaneType(newPlaneType);

            Console.WriteLine("Enter New Min Needed Runway Size:");
            int newMinRunwaySize;
            if (int.TryParse(Console.ReadLine(), out newMinRunwaySize))
            {
                fixedWing.ChangeMinNeededRunwaySize(newMinRunwaySize);
                Console.WriteLine("Fixed Wing Airplane updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input for Min Needed Runway Size. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Fixed Wing Airplane not found. Please enter a valid Fixed Wing Airplane ID.");
        }
    }

    static void AddHelicopterToAirport()
    {
        Console.WriteLine("Enter Helicopter ID:");
        string helicopterId = Console.ReadLine();

        Helicopter helicopter = helicopters.FirstOrDefault(h => h.Id == helicopterId);
        if (helicopter != null)
        {
            Console.WriteLine("Enter Airport ID:");
            string airportId = Console.ReadLine();

            Airport airport = airports.FirstOrDefault(a => a.Id == airportId);
            if (airport != null)
            {
                if (helicopter.MaxTakeoffWeight <= 1.5 * helicopter.EmptyWeight)
                {
                    airport.AddHelicopter(helicopter);
                    Console.WriteLine("Helicopter added to the airport successfully.");
                }
                else
                {
                    Console.WriteLine("The Max Takeoff Weight of the Helicopter exceeds 1.5 times its Empty Weight.");
                }
            }
            else
            {
                Console.WriteLine("Airport not found. Please enter a valid Airport ID.");
            }
        }
        else
        {
            Console.WriteLine("Helicopter not found. Please enter a valid Helicopter ID.");
        }
    }
}

class Airplane
{
    private string modelCheck;
    public string Id { get; set; }
    public string Model
    {
        get => modelCheck;
        set
        {
            if (value.Length > 40)
            {
                throw new ArgumentException("Model cannot have larger than 40 characters.");
            }
            modelCheck = value;
        }
    }
    public double CruiseSpeed { get; set; }
    public double EmptyWeight { get; set; }
    public double MaxTakeoffWeight { get; set; }

    public Airplane(string id, string model, double cruiseSpeed, double emptyWeight, double maxTakeoffWeight)
    {
        Id = id;
        Model = model;
        CruiseSpeed = cruiseSpeed;
        EmptyWeight = emptyWeight;
        MaxTakeoffWeight = maxTakeoffWeight;
    }

    public virtual void Fly()
    {
        Console.WriteLine("Aircraft is flying.");
    }
}

class FixedWing : Airplane
{
    private string plane;
    public string PlaneType { get => plane;
         set 
        {
            if (value != "CAG" && value != "LGR" && value != "PRV")
            {
                throw new ArgumentException("The type of Fixed Wing PLane is not an option!");
            }
            else plane = value;
        } }
    public int MinNeededRunwaySize { get; set; }
    public FixedWing(string id, string model, double cruiseSpeed, double emptyWeight, double maxTakeoffWeight, string planeType, int minNeededRunwaySize)
        : base(id, model, cruiseSpeed, emptyWeight, maxTakeoffWeight)
    {
        PlaneType = planeType;
        MinNeededRunwaySize = minNeededRunwaySize;
    }

    public override void Fly()
    {
        Console.WriteLine("Fixed wing airplane is flying.");
    }

    public void ChangePlaneType(string newPlaneType)
    {
        PlaneType = newPlaneType;
    }

    public void ChangeMinNeededRunwaySize(int newMinRunwaySize)
    {
        MinNeededRunwaySize = newMinRunwaySize;
    }

    public override string ToString()
    {
        return $"FixedWing ID: {Id}, Model: {Model}, Plane Type: {PlaneType}, Min Needed Runway Size: {MinNeededRunwaySize}";
    }
}

class Helicopter : Airplane
{
    public double Range { get; set; }

    public Helicopter(string id, string model, double cruiseSpeed, double emptyWeight, double maxTakeoffWeight, double range)
        : base(id, model, cruiseSpeed, emptyWeight, maxTakeoffWeight)
    {
        Range = range;
    }

    public override void Fly()
    {
        Console.WriteLine("Rotated wing (helicopter) is flying.");
    }

    public override string ToString()
    {
        return $"Helicopter ID: {Id}, Model: {Model}, Range: {Range}";
    }
    public new double MaxTakeoffWeight
    {
        get => base.MaxTakeoffWeight;
        set
        {
            if (value <= 1.5 * EmptyWeight)
            {
                base.MaxTakeoffWeight = value;
            }
            else
            {
                throw new ArgumentException("Max takeoff weight cannot exceed 1.5 times the empty weight.");
            }
        }
    }
}


class Airport
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RunwaySize { get; set; }
    public int MaxFixedwingParkingPlace { get; set; }
    public List<string> FixedWingAirplaneIds { get; set; }
    public int MaxRotatedWingParkingPlace { get; set; }
    public List<string> HelicopterIds { get; set; }

    public Airport(string id, string name, int runwaySize, int maxFixedwingParkingPlace, int maxRotatedWingParkingPlace)
    {
        Id = id;
        Name = name;
        RunwaySize = runwaySize;
        MaxFixedwingParkingPlace = maxFixedwingParkingPlace;
        MaxRotatedWingParkingPlace = maxRotatedWingParkingPlace;
        FixedWingAirplaneIds = new List<string>();
        HelicopterIds = new List<string>();
    }

    public void AddFixedWing(FixedWing fixedWing)
    {
        if (FixedWingAirplaneIds.Count < MaxFixedwingParkingPlace)
        {
            FixedWingAirplaneIds.Add(fixedWing.Id);
            Console.WriteLine($"Fixed Wing Airplane {fixedWing.Id} added to the airport {Id}.");
        }
        else
        {
            Console.WriteLine($"Cannot add Fixed Wing Airplane {fixedWing.Id} to the airport {Id}. Parking place is full.");
        }
    }

    public void RemoveHelicopter(Helicopter helicopter)
    {
        HelicopterIds.Remove(helicopter.Id);
        Console.WriteLine($"Helicopter {helicopter.Id} removed from the airport {Id}.");
    }

    public void AddHelicopter(Helicopter helicopter)
    {
        if (HelicopterIds.Count < MaxRotatedWingParkingPlace)
        {
            HelicopterIds.Add(helicopter.Id);
            Console.WriteLine($"Helicopter {helicopter.Id} added to the airport {Id}.");
        }
        else
        {
            Console.WriteLine($"Cannot add Helicopter {helicopter.Id} to the airport {Id}. Parking place is full.");
        }
    }

   

    public override string ToString()
    {
        return $"Airport ID: {Id}, Name: {Name}, Runway Size: {RunwaySize}, " +
               $"Max Fixedwing Parking Place: {MaxFixedwingParkingPlace}, FixedWing Airplanes: {string.Join(", ", FixedWingAirplaneIds)}, " +
               $"Max Rotated Wing Parking Place: {MaxRotatedWingParkingPlace}, Helicopters: {string.Join(", ", HelicopterIds)}";
    }
}
