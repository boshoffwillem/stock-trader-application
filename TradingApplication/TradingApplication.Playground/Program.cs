using System;
using System.Linq;
using TradingApplication.Domain.Models;
using TradingApplication.EntityFramework;
using TradingApplication.EntityFramework.Services;

namespace TradingApplication.Playground
{
   class Program
   {
      static void Main(string[] args)
      {
         var userService = new GenericDataService<User>(new TradingApplicationDbContextFactory());
         //userService.Create(new User { Username = "Test" }).Wait();
         Console.WriteLine($"Number of users: {userService.GetAll().Result.Count()}");
         Console.WriteLine($"User get: {userService.Get(1).Result}");
         Console.WriteLine($"User update: {userService.Update(1, new User { Username = "UpdateUser" }).Result}");
         Console.WriteLine($"User delete: {userService.Delete(1).Result}");
      }
   }
}
