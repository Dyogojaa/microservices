using RestAspNet.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestAspNet.Services.Implementations
{
    public class PersonServicesImplamentation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            

            for (int i = 0; i < 10; i++)            
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }        

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Dyogo",
                LastName = "Almeida",
                Address = "Uberlandia - Minas - Brasil",
                Gender = "Macho"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }


        private Person MockPerson(int id)
        {

            return new Person
            {
                Id = IncrementeGet(),
                FirstName = "Persona Name " + id,
                LastName = "Almeida Last " + id,
                Address = "Endereço" + id,
                Gender = id % 2 == 0 ? "Macho" : "Femea"
            };
        }

        private long IncrementeGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
