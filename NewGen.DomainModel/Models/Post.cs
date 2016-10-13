
using System;
using System.Collections.Generic;

namespace  NewGen.DomainModel.Models
{
    public class Post:IEntityBase<int>
    {
        public int Id{get;set;}
      
        public string Title{get;set;}

        
        public DateTime DatePosted{get;set;}
        public string Text{get;set;}

        public List<Comment>Comments{get;set;}

        public List<PostTag>PostTags{get;set;}

    }
}