using System;
using System.Collections.Generic;
using System.Linq;

namespace Byui.Game.Casting
{
    /// <summary>
    /// A map of groups and Actors.
    /// </summary>
    public class Cast
    {
        private Dictionary<string, List<Actor>> _actors = new Dictionary<string, List<Actor>>();
        
        public Cast()
        {
        }

        public void Put(string group, Actor actor)
        {
            if (!_actors.ContainsKey(group))
            {
                _actors[group] = new List<Actor>();
            }

            if (!_actors[group].Contains(actor))
            {
                _actors[group].Add(actor);
            }
        }

        public List<Actor> Get(string group)
        {
            return new List<Actor>(_actors[group]);
        }

        public Actor GetFirst(string group)
        {
            return Get(group)[0];
        }

        public void Remove(string group, Actor actor)
        {
            _actors[group].Remove(actor);
        }
    }
}