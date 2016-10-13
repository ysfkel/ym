using NewGen.DomainModel.Repository;
using NewGen.DomainModel.Models;
using NewGen.Infrastrcuture.Data;
      
namespace NewGen.Infrastrcuture.Data.Repository
{
    public class PostRepository : EntityBaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
