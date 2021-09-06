using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly Context _context;

        public DataController(Context context)
        {
            _context = context;
        }

        // POST: api/Default
        [HttpPost]
        public IActionResult Post()
        {
            var country = new List<Country>
            {
                new Country
                {
                    Name="France"
                },
                new Country
                {
                    Name="Germany"
                },
                new Country
                {
                    Name="Serbia"
                },
                new Country
                {
                    Name="Spain"
                },
                new Country
                {
                    Name="Italy"
                }
            };

            var city = new List<City>
            {
                new City
                {
                    Name="Paris",
                    Country=country.ElementAt(0)
                },
                new City
                {
                    Name="Berlin",
                    Country=country.ElementAt(1)
                },
                new City
                {
                    Name="Munchen",
                    Country=country.ElementAt(1)
                },
                new City
                {
                    Name="Belgrade",
                    Country=country.ElementAt(2)
                },
                new City
                {
                    Name="Barcelona",
                    Country=country.ElementAt(3)
                },
                new City
                {
                    Name="Madrid",
                    Country=country.ElementAt(3)
                },
                new City
                {
                    Name="Roma",
                    Country=country.ElementAt(4)
                },
                new City
                {
                    Name="Milano",
                    Country=country.ElementAt(4)
                }
            };

            var destination = new List<Destination>
            {
                new Destination
                {
                    CityFrom=city.ElementAt(0),
                    CityTo=city.ElementAt(1),
                    Duration=90
                },
                new Destination
                {
                    CityFrom=city.ElementAt(1),
                    CityTo=city.ElementAt(0),
                    Duration=90
                },
                new Destination
                {
                    CityFrom=city.ElementAt(2),
                    CityTo=city.ElementAt(3),
                    Duration=90
                },
                new Destination
                {
                    CityFrom=city.ElementAt(2),
                    CityTo=city.ElementAt(4),
                    Duration=160
                },
                new Destination
                {
                    CityFrom=city.ElementAt(5),
                    CityTo=city.ElementAt(6),
                    Duration=135
                },
                new Destination
                {
                    CityFrom=city.ElementAt(7),
                    CityTo=city.ElementAt(3),
                    Duration=120
                },
                new Destination
                {
                    CityFrom=city.ElementAt(3),
                    CityTo=city.ElementAt(7),
                    Duration=120
                }

            };


            var timetable = new List<Timetable>
            {
                new Timetable
                {
                    Destination=destination.ElementAt(0),
                    DepartureDate=DateTime.Parse("9/7/2021")
                },
                new Timetable
                {
                    Destination=destination.ElementAt(1),
                    DepartureDate=new DateTime(2021, 9, 10, 8, 30, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(2),
                    DepartureDate=new DateTime(2021, 9, 10, 9, 25, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(3),
                    DepartureDate=new DateTime(2021, 9, 10, 15, 45, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(4),
                    DepartureDate=new DateTime(2021, 9, 10, 19, 0, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(5),
                    DepartureDate=new DateTime(2021, 9, 10, 18, 0, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(6),
                    DepartureDate=new DateTime(2021, 9, 10, 16, 15, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(6),
                    DepartureDate=new DateTime(2021, 9, 11, 16, 15, 0)
                },
                new Timetable
                {
                    Destination=destination.ElementAt(1),
                    DepartureDate=new DateTime(2021, 9, 11, 8, 30, 0)
                }
            };

            var price = new List<Price>
            {
                new Price
                {
                    Timetable=timetable.ElementAt(0),
                    DateFrom=DateTime.Now,
                    PriceValue=50
                },
                new Price
                {
                    Timetable=timetable.ElementAt(1),
                    DateFrom=DateTime.Now,
                    PriceValue=95
                },
                new Price
                {
                    Timetable=timetable.ElementAt(2),
                    DateFrom=DateTime.Now,
                    PriceValue=105
                },
                new Price
                {
                    Timetable=timetable.ElementAt(3),
                    DateFrom=DateTime.Now,
                    PriceValue=80
                },
                new Price
                {
                    Timetable=timetable.ElementAt(4),
                    DateFrom=DateTime.Now,
                    PriceValue=45
                },
                new Price
                {
                    Timetable=timetable.ElementAt(5),
                    DateFrom=DateTime.Now,
                    PriceValue=110
                },
                new Price
                {
                    Timetable=timetable.ElementAt(6),
                    DateFrom=DateTime.Now,
                    PriceValue=109
                },
                new Price
                {
                    Timetable=timetable.ElementAt(7),
                    DateFrom=DateTime.Now,
                    PriceValue=105
                },
                new Price
                {
                    Timetable=timetable.ElementAt(8),
                    DateFrom=DateTime.Now,
                    PriceValue=120
                }
            };


            var user = new List<User>
            {
                new User
                {
                    FirstName="Djordje",
                    LastName="Markovic",
                    Email="user@gmail.com",
                    Password="f1dc735ee3581693489eaf286088b916"
                },
                new User
                {
                    FirstName="Djordje",
                    LastName="Markovic",
                    Email="admin@gmail.com",
                    Password="f1dc735ee3581693489eaf286088b916"
                }
            };

            //user
            var userUseCases = Enumerable.Range(1, 20).ToList();
            //admin
            var adminUseCases = Enumerable.Range(1, 50).ToList();

            userUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user.ElementAt(0),
                IdUseCase = useCase
            }));

            adminUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user.ElementAt(1),
                IdUseCase = useCase
            }));


            _context.Users.AddRange(user);
            _context.Countries.AddRange(country);
            _context.Cities.AddRange(city);
            _context.Destinations.AddRange(destination);
            _context.Timetables.AddRange(timetable);
            _context.Prices.AddRange(price);

            _context.SaveChanges();


            return Ok();
        }

    }
}
