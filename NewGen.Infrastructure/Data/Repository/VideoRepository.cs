using NewGen.DomainModel.Repository;
using NewGen.DomainModel.Models;
using NewGen.Infrastrcuture.Data;
      
namespace NewGen.Infrastrcuture.Data.Repository
{
    public class VideoRepository : EntityBaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
