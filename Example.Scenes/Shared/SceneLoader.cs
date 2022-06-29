using Byui.Games.Services;


namespace Byui.Games.Scripting
{
    /// <summary>
    /// A base class for all derived scene loaders like TitleSceneLoader, GameSceneLoader, etc.
    /// </summary>
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

        /// <summary>
        /// Loads a scene with the appropriate actors and actions. This method must be implemented 
        /// by all inheriting or derived classes.
        /// </summary>
        /// <param name="scene">The scene to load.</param>
        public abstract void Load(Scene scene);

    }
}

