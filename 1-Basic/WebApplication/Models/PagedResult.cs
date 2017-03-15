using System.Collections.Generic;

namespace WebApplication.Models
{
    public class PagedResult<T> where T : class
    {
      public int TotalPages { get; set; }

      public int CurrentPage { get; set; }

      public ICollection<T> Items { get; set; }
    }
}
