namespace WebApplication.Services
{
   using Models;

   public interface IDataService
   {
      PagedResult<Item> Query( ItemQuery query );
   }
}