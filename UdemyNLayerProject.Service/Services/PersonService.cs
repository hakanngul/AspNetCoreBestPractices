using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class PersonService :  Service<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Person> repository) : base(unitOfWork, repository)
        {
        }
    }
}