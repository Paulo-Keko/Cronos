using cronos.entity.Entity;
using cronos.repository.Repository.Base;

namespace cronos.repository.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IDBContext dbcontext) : base(dbcontext) { }
    }
}
