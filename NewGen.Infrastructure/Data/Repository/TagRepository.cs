using NewGen.DomainModel.Repository;
using NewGen.DomainModel.Models;
using NewGen.Infrastrcuture.Data;
      
namespace NewGen.Infrastrcuture.Data.Repository
{
    public class TagRepository : EntityBaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
