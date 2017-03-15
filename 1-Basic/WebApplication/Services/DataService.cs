namespace WebApplication.Services
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Enums;
   using Models;

   public class DataService : IDataService
   {
      public PagedResult<Item> Query( ItemQuery query )
      {
         //This is all in lieu of any kind of real data. I would not advise ever doing anything like the below...

         var items = BuildData();


         if (!string.IsNullOrWhiteSpace( query.SearchText ))
         {
            items =
               items.Where( p => p.Name.ToLower().Contains( query.SearchText.ToLower()) || p.Description.ToLower().Contains( query.SearchText.ToLower() ) )
                  .ToList();
         }

         switch (query.SortOrder)
         {
            case ItemSortOrder.NameAscending:
               items = items.OrderBy( p => p.Name ).ToList();
               break;
            case ItemSortOrder.NameDescending:
               items = items.OrderByDescending( p => p.Name ).ToList();
               break;
            case ItemSortOrder.DateAscending:
               items = items.OrderBy( p => p.Date ).ToList();
               break;
            default:
               items = items.OrderByDescending( p => p.Date ).ToList();
               break;
         }

         var totalItems = items.Count;

         var pagesize = 3; //This could obviously be another thing passed from client

         var skip = pagesize * (query.Page - 1);

         items = items.Skip( skip ).Take( pagesize ).ToList();

         return new PagedResult<Item>()
         {
            Items = items,
            CurrentPage = query.Page,
            TotalPages = (int)Math.Ceiling( (double)totalItems / pagesize)
         };
      }

      private ICollection<Item> BuildData()
      {
         //This is in lieu of any kind of real data store
         return new List<Item>
         {
            new Item
            {
               Name = "Lorem",
               Description = "ipsum",
               Date = DateTime.Now.AddDays( -1 )
            },
            new Item
            {
               Name = "dolor",
               Description = "sit",
               Date = DateTime.Now.AddDays( -2 )
            },
            new Item
            {
               Name = "amet",
               Description = "consectetur",
               Date = DateTime.Now.AddDays( -3 )
            },
            new Item
            {
               Name = "adipiscing",
               Description = "elit",
               Date = DateTime.Now.AddDays( -4 )
            },
            new Item
            {
               Name = "Fusce",
               Description = "efficitur",
               Date = DateTime.Now.AddDays( -5 )
            },
            new Item
            {
               Name = "enim",
               Description = "lorem",
               Date = DateTime.Now.AddDays( -6 )
            },
            new Item
            {
               Name = "mattis",
               Description = "pellentesque",
               Date = DateTime.Now.AddDays( -7 )
            },
            new Item
            {
               Name = "mi",
               Description = "maximus",
               Date = DateTime.Now.AddDays( -8 )
            },
            new Item
            {
               Name = "et",
               Description = "Nullam",
               Date = DateTime.Now.AddDays( -9 )
            },
            new Item
            {
               Name = "sed",
               Description = "pharetra",
               Date = DateTime.Now.AddDays( -10 )
            },
            new Item
            {
               Name = "massa",
               Description = "ac",
               Date = DateTime.Now.AddDays( -11 )
            },
            new Item
            {
               Name = "maximus",
               Description = "nunc",
               Date = DateTime.Now.AddDays( -12 )
            },
            new Item
            {
               Name = "Donec",
               Description = "placerat",
               Date = DateTime.Now.AddDays( -13 )
            },
            new Item
            {
               Name = "consectetur",
               Description = "rutrum",
               Date = DateTime.Now.AddDays( -14 )
            },
            new Item
            {
               Name = "Pellentesque",
               Description = "ac",
               Date = DateTime.Now.AddDays( -15 )
            },
            new Item
            {
               Name = "leo",
               Description = "sodales",
               Date = DateTime.Now.AddDays( -16 )
            },
            new Item
            {
               Name = "ultrices",
               Description = "odio",
               Date = DateTime.Now.AddDays( -17 )
            },
            new Item
            {
               Name = "et",
               Description = "tristique",
               Date = DateTime.Now.AddDays( -18 )
            },
            new Item
            {
               Name = "libero",
               Description = "Sed",
               Date = DateTime.Now.AddDays( -19 )
            },
            new Item
            {
               Name = "tristique",
               Description = "lacus",
               Date = DateTime.Now.AddDays( -20 )
            },
         };
      }
   }
}