using FluentAssertions;
using Hockey.Data;
using System.Reflection.Metadata;

namespace HockeyTestProject
{
    public class HockeyPlayerTest
    {
        const string FIRST_NAME = "Shane";
        const string LAST_NAME = "Bell";
        const string BIRTH_PLACE = "Edmonton";
        const int HEIGHT_IN_INCHES = 70;
        const int WEIGHT_IN_POUNDS = 190;
        const Position PLAYER_POSITION = Position.Goalie;
        const Shot PLAYER_SHOT = Shot.Right;
        //Cannot create constants from date/time. 
        //can make it readonly to ensure it is not changed
        readonly DateOnly DATE_OF_BIRTH = new DateOnly(1972, 01, 20);
        const string TO_STRING_VALUE = $"{FIRST_NAME} {LAST_NAME}";

        //Method to generate a greedy Hockey Player
        public HockeyPlayer GenerateGreedyTestPlayer()
        {
            return new HockeyPlayer(BIRTH_PLACE, FIRST_NAME, LAST_NAME, HEIGHT_IN_INCHES, WEIGHT_IN_POUNDS, DATE_OF_BIRTH, PLAYER_POSITION, PLAYER_SHOT);
        }

        //TEST FOR GREEDY CONSTRUCTOR
        [Fact]
        public void HockeyPlayer_Create_GreedyConstructorHockeyPlayer()
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();
            player.Should().NotBeNull();//If it is not null then the constructor returned a valid instance of Hockey Player
        }

        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]//This attribute in front of a method indicates it is a testing method.
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void AddOnePlusOne()
        {
            //Test if 1 + 1 =2
            //Arrange
            int a = 1;
            int b = 1;
            int actual;
            //Act
            actual = a + b;
            //Assert
            //XUnit syntax
            //Assert.Equal(2, actual);
            //FluentAssertions
            actual.Should().Be(2);
        }
        [Fact]
        public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
        {
            //Arrange
            string actual;
            HockeyPlayer player = GenerateTestPlayer();
            const string NAME = "test";
            player.FirstName = NAME;
            //Act
            actual = player.FirstName;
            //Assert
            actual.Should().Be(NAME);
        }
        [Fact]
        public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArgument()
        {
            HockeyPlayer player = GenerateTestPlayer();
            const string Empty_Name = "";
            //We want to create an action that will run in the assertion only.
            //create an action called act. This is like a mini method that can be called/executed in the assertion
            Action act = () => player.FirstName = Empty_Name;

            act.Should().Throw<Exception>().WithMessage("First name cannot be empty!");
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnCorrectValue()
        {
            //Arrange
            HockeyPlayer player = GenerateGreedyTestPlayer();
            string actual;
            //Act
            actual = player.ToString();
            //Assert
            actual.Should().Be(TO_STRING_VALUE);
        }
        //create a test for a JerseyNumber Property. Test Get/Set for success. valid jersey number is 1-98.
        //
        [Theory]
        [InlineData(1)]
        [InlineData(98)]

        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;
            actual.Should().Be(value);
        }
        //test for invalid data throwing an exception(0,99)
        [Theory]
        [InlineData(0)]
        [InlineData(99)]

        public void HockeyPlayer_JerseyNumber_BadSetThrowsException(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();

            Action act=()=> player.JerseyNumber = value;

            act.Should().Throw<Exception>().WithMessage("Jersey number out of range");
        }



    }
}