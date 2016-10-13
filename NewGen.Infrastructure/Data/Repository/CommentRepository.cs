using NewGen.DomainModel.Repository;
using NewGen.DomainModel.Models;
using NewGen.Infrastrcuture.Data;
      
namespace NewGen.Infrastrcuture.Data.Repository
{
    public class CommentRepository : EntityBaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
