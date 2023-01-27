using MyProduct.Domain;
using MyProduct.Persistence.Seedwork;

namespace MyProduct.Persistence.Repositories
{
    public class PersonRepository : RepositoryBase<Product>
    {
        public PersonRepository(MyDbContext myDbContext)
            : base(myDbContext)
        {

        }
    }
}
