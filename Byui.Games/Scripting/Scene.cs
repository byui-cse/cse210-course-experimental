using System.Collections.Generic;
using Byui.Games.Casting;


namespace Byui.Games.Scripting
{
    /// <summary>
    /// The current state of the game.
    /// </summary>
    /// <remarks>
    /// The responsibility of Scene is to provide access to the current state of the game.
    /// </remarks>
    public class Scene
    {
        private Cast _cast = new Cast();
        private Script _script = new Script();
        
        public Scene() { }

        public void AddAction(int phase, Action action)
        {
            _script.Add(phase, action);
        }

        public void AddActor(string group, Actor actor)
        {
            _cast.Add(group, actor);
        }

        public void ApplyChanges()
        {
            _cast.ApplyChanges();
            _script.ApplyChanges();
        }

        public void Clear()
        {
            _cast.Clear();
            _script.Clear();
        }

        public List<Action> GetAllActions(int phase)
        {
            return _script.GetAllActionsIn(phase);
        }

        public List<Actor> GetAllActors(string group)
        {
            return _cast.GetAllActors(group);
        }

        public List<T> GetAllActors<T>(string group)
        {
            return _cast.GetAllActors<T>(group);
        }

        public Actor GetFirstActor(string group)
        {
            return _cast.GetFirstActor(group);
        }

        public T GetFirstActor<T>(string group)
        {
            return _cast.GetFirstActor<T>(group);
        }

        public void RemoveAction(int phase, Action action)
        {
            _script.Remove(phase, action);
        }

        public void RemoveActor(string group, Actor actor)
        {
            _cast.Remove(group, actor);
        }
    }
}