using Byui.Games.Services;
using Byui.Games.Scripting;


namespace Example.Breaker.Shared
{
    public abstract class SceneLoader
    {
        private static IServiceFactory ServiceFactory;

        public SceneLoader(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }

        public IServiceFactory GetServiceFactory()
        {
            return ServiceFactory;
        }

        public abstract void Load(Scene scene);

    }
}

