using RestAspNet.Model;
using System.Collections.Generic;

namespace RestAspNet.Services
{
    public interface IPersonService
    {
       Person Create(Person person);
       Person Update(Person person);
       void Delete(long id);
       Person FindById(long id);
       List<Person> FindAll();

    }
}
