

using System.Collections.Generic;

namespace  NewGen.DomainModel.Models
{
    public class Tag:IEntityBase<int>
    {
          public int Id{get;set;}
          public string Name{get;set;}

          public List<PostTag>PostTags{get;set;}
    }
}