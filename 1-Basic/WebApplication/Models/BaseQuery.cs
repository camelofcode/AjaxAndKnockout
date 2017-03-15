namespace WebApplication.Models
{
    public class BaseQuery
    {
      public int Page { get; set; }

      public string SearchText { get; set; }

       public BaseQuery()
       {
          Page = 1;
       }
    }
}
