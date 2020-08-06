using DependencyContainer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DependencyContainer
{
    public class InMemoryDatabase
    {
        public void SeedData()
        {
            Persons = new List<Person>()
            {
                new Person()
                {
                    DateOfBirth = new System.DateTime(1992,10,15),
                    Gender = "Male",
                    LastName = "Roselt",
                    Name = "Nico"
                },
                new Person()
                {
                    DateOfBirth = new System.DateTime(1994,10,15),
                    Gender = "Male",
                    LastName = "Slabbert",
                    Name = "Brandon"
                },
                new Person()
                {
                    DateOfBirth = new System.DateTime(1950,10,15),
                    Gender = "Male",
                    LastName = "Lurie",
                    Name = "Juan"
                }
            }.AsQueryable();
        }

        public IQueryable<Person> Persons { get; set; }
    }
}
