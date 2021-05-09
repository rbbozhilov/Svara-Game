using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.Models;
using Svara_Game.Models.ValueObject;


namespace Svara_Game.DI
{
   public class Container
    {

        public static ServiceProvider ConfigureServices()
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IWriter, Writer>();
            serviceCollection.AddTransient<IReader, Reader>();
            serviceCollection.AddTransient<Choice, Choice>();


            return serviceCollection.BuildServiceProvider();
        }


    }
}
