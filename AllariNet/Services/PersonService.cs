using AllariNet.Interfaces;
using AllariNet.Models;

namespace AllariNet.Services
{
    public class PersonService : IPersonService
    {
        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>
            {
            new Person {Name = "John"},
            new Person {Name = "Lucy"},
            new Person {Name = "Charles"},
            new Person {Name = "Philipe"},
            new Person {Name = "Mario"},
            new Person {Name = "Another John"},
            };

            return persons;
        }
    }
}
