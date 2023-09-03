using CityInfo.API2.Models;

namespace CityInfo.API2
{
    public class CitiesDataStore
    {

        public List<CityDto> Cities { get; set; }


        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {

         Cities = new List<CityDto>()
          {
            new CityDto()
            {
                Id = 1,
                Name = "New York City",
                Description = "The one with that big park"
                ,PointsOfInterest = new List <PointOfInterestDto>()
                { 
                new PointOfInterestDto()
                    {
                    Id=1,
                    Name="Central Park",
                    Description="the most visited urban park in USA"
                    },
                new PointOfInterestDto()
                    {
                     Id=2,
                    Name="Statue of Liberty",
                    Description="a gift from the French to USA to celebrate freedom"
                    }

                }
            },
            new CityDto()
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished" //lolto je i barselona,a i tehnicki Bg iakoje crkva/hram a ne katedrala,
                ,PointsOfInterest = new List <PointOfInterestDto>()
                {
                new PointOfInterestDto()
                    {
                    Id=3,
                    Name="unfinished cathedral",
                    Description="it's unfinished "
                    },
                new PointOfInterestDto()
                    {
                     Id=4,
                    Name="i dunno probably a cool museum or something",
                    Description="most probably has a nice collection"
                    }

                }
            },
            new CityDto()
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower"
                ,PointsOfInterest = new List <PointOfInterestDto>()
                {
                new PointOfInterestDto()
                    {
                    Id=5,
                    Name="Eiffel tower",
                    Description="the big pointy metal building you can go up to the top at"
                    },
                new PointOfInterestDto()
                    {
                     Id=6,
                    Name="Arc of Triumph",
                    Description="cool gate to celebrate french troops"
                    }

                }
            },
            new CityDto()
            {
                Id = 4,
                Name = "Moscow",
                Description = "The one with that big red castle"
            ,PointsOfInterest = new List <PointOfInterestDto>()
                {
                new PointOfInterestDto()
                    {
                    Id=7,
                    Name="Oktobarskaya station",
                    Description="one of the coolest metro stations in the world"
                    },
                new PointOfInterestDto()
                    {
                     Id=8,
                    Name="Kremlin",
                    Description="the big fancy red castle"
                    }

                }
            }
          };
        }

    }
}
