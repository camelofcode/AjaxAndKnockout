namespace WebApplication.Models
{
   using Enums;

   public class ItemQuery : BaseQuery
   {
      public ItemSortOrder SortOrder { get; set; }
   }
}