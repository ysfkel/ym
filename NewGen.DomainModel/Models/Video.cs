
using System;
using System.Collections.Generic;

namespace  NewGen.DomainModel.Models
{
    public class Video:IEntityBase<int>
    {
        public int Id{get;set;}
      
        public string Title{get;set;}
        public string Url{get;set;}
        public string Description{get;set;}
        public DateTime DatePosted{get;set;}

    }
}