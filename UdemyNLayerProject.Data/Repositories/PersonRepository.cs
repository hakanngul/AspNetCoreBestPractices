using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private AppDbContext _appDbContext
        {
            get => _context as AppDbContext;
        }

        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}