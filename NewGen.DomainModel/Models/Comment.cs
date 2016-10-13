
using System;

namespace  NewGen.DomainModel.Models
{
     public class Comment:IEntityBase<int>
     {
         public int Id{get;set;}
         public string Content{get;set;}

         public int BlogId{get;set;}

         public Post Post{get;set;}

         public DateTime DatePosted{get;set;}

         public string Email{get;set;}
     }
} 