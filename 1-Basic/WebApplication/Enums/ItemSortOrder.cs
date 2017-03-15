namespace WebApplication.Enums
{
   using System.ComponentModel;

   public enum ItemSortOrder
   {
      Unknown = 0,

      [ Description( "Name (A-Z)" ) ]
      NameAscending = 1,

      [ Description( "Name (Z-A)" ) ]
      NameDescending = 2,

      [ Description( "Date (Old-New)" ) ]
      DateAscending = 3,

      [ Description( "Date (New-Old)" ) ]
      DateDescending = 4
   }
}