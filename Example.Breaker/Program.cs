using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Menu;
using Example.Breaker.Shared;

namespace Example.Breaker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IServiceFactory serviceFactory = new RaylibServiceFactory();
            Scene scene = new Scene();

            SceneLoader menuSceneLoader = new MenuSceneLoader(serviceFactory);
            menuSceneLoader.Load(scene);

            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
