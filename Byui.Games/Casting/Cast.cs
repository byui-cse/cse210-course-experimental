using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Byui.Games.Casting
{
    /// <summary>
    /// A collection of Actors.
    /// </summary>
    public class Cast
    {
        private Dictionary<string, List<Actor>> _current 
            = new Dictionary<string, List<Actor>>();
            
        private Dictionary<string, List<Actor>> _removed 
            = new Dictionary<string, List<Actor>>();

        public Cast() { }

        public void Add(string group, Actor actor)
        {
            Validator.CheckNotBlank(group);
            Validator.CheckNotNull(actor);
            
            if (!_current.ContainsKey(group))
            {
                _current[group] = new List<Actor>();
            }

            if (!_current[group].Contains(actor))
            {
                _current[group].Add(actor);
            }
        }

        public void ApplyChanges()
        {
            foreach (string group in _removed.Keys)
            {
                foreach(Actor actor in _removed[group])
                {
                    if (_current[group].Contains(actor))
                    {
                        _current[group].Remove(actor);
                    }
                }
            }
            _removed.Clear();
        }

        public void Clear()
        {
            _current.Clear();
            _removed.Clear();
        }

        public List<Actor> GetAllActors(string group)
        {
            Validator.CheckNotBlank(group);
            List<Actor> results = new List<Actor>();
            if (_current.ContainsKey(group))
            {
                results = _current[group];
            }
            return results;
        }

        public List<T> GetAllActors<T>(string group)
        {
            Validator.CheckNotBlank(group);
            List<T> results = new List<T>();
            if (_current.ContainsKey(group))
            {
                foreach(object actor in _current[group])
                {
                    results.Add((T)actor);
                }
            }
            return results;
        }

        public Actor GetFirstActor(string group)
        {
            Validator.CheckNotBlank(group);
            Actor result = null;
            List<Actor> actors = GetAllActors(group);
            if (actors.Count > 0)
            {
                result = actors[0];
            }
            return result;
        }

        public T GetFirstActor<T>(string group)
        {
            Validator.CheckNotBlank(group);
            T result = default(T);
            List<T> actors = GetAllActors<T>(group);
            if (actors.Count > 0)
            {
                result = actors[0];
            }
            return result;
        }

        public int GetTotalActors()
        {
            int total = 0;
            foreach(List<Actor> actors in _current.Values)
            {
                total += actors.Count;
            }
            return total;
        }

        public void Remove(string group, Actor actor)
        {
            Validator.CheckNotBlank(group);
            Validator.CheckNotNull(actor);
            
            if (!_removed[group].Contains(actor))
            {
                _removed[group].Add(actor);
            }
        }
    }
}