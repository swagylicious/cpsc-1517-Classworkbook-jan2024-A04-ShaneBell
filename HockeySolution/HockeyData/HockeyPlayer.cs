﻿
using ValidationUtilities;

namespace Hockey.Data
{
    public class HockeyPlayer
    {
        //Data fields
        //store the data in the object
        //prefix _ for private fields
        //camel case
        //The green squiggles are saying they are strings and therefore not nullable
        //can use ? after string to allow nulls
        //This can also be managed in the constructor
        private string _birthPlace;
        private string _firstName;
        private string _lastName;
        private int _heightInInches;
        private int _weightInPounds;
        private DateOnly _dateOfBirth;
        private int _jerseyNumber;


        //Properties
        // allow acccess to our fields (public)
        //can validate
        //must have a get
        //set can be private (only code in the class can use it)
        public List<Team> teams { get; set; } = new();
        public int NumberOfTeams
        {
            get
            {
                return teams.Count;
            }
        }
        public int JerseyNumber
        {
            get
            {
                return _jerseyNumber;
            }
            set
            {
                if (value < 1 || value > 98)
                {
                    throw new Exception("Jersey number out of range");
                }
                _jerseyNumber = value;
            }
        }
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("Birth Place cannot be empty!");
                }
                _birthPlace = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("First Name cannot be empty!");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("last Name cannot be empty!");
                }
                _lastName = value;
            }
        }

        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (value < 0)
                {
                    throw new Exception("Weight must be positive");
                }
                _weightInPounds = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (value < 0)
                {
                    throw new Exception("Height must be positive");
                }
                _heightInInches = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Cannot be born in the future!");
                }
                _dateOfBirth = value;
            }
        }


        //public string FirstName { get; set; }
        //auto implemented property
        //Creates a backing field to store the Position
        //prop tab tab
        public Position Position { get; set; }
        public Shot Shot { get; set; }


        //TODO: complete the remaing properties for the fields
        //strings must not be null,empty,whitespace
        //weight and height must be >=0


        //Default Constructor
        public HockeyPlayer()
        {
            _firstName = "bob";//string.Empty;//This is a constant for ""
            _lastName = "smith";
            _birthPlace = "a";
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Position = Position.Center;
            Shot = Shot.Right;
            JerseyNumber = 20;
        }
        public HockeyPlayer(string birthPlace, string firstName, string lastName, int heightInInches, int weightInPounds, DateOnly dateOfBirth, Position position, Shot shot, int jerseyNumber,List<Team> team)
        {
            BirthPlace = birthPlace;
            FirstName = firstName;
            LastName = lastName;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            DateOfBirth = dateOfBirth;
            Position = position;
            Shot = shot;
            JerseyNumber = jerseyNumber;
            if (team != null)
            {
                teams = team;
            }
            

        }
        //Override ToString to return firstname lastname
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        //Method to add a team to the player
        //throw an exception if the team name is already in the list of teams for the player
        public void AddTeam(string teamName, string city, Role role)
        {
            bool found = false;
            foreach(Team aTeam in teams)
            {
                if(aTeam.TeamName==teamName)
                {
                    found = true;
                }
            }
            if(found)
            {
                throw new Exception($"The {teamName} is already listed for that player");
            }
            
            teams.Add(new Team(teamName, city, role));
        }
        //Remove Team method to remove a team from the list
        //If the teamname being removed is not in the list, throw an exception
        public void RemoveTeam(string teamName)
        {
            Team foundTeam = null;
            bool found = false;
            foreach (Team aTeam in teams)
            {
                if (aTeam.TeamName == teamName)
                {
                    found = true;                    
                    foundTeam= aTeam;
                }
            }
            if (!found)
            {
                throw new Exception($"The {teamName} is not in the list for that player");
            }
            teams.Remove(foundTeam);            
        }

    }
}
