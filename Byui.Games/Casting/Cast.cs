using System.Collections.Generic;


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

        public List<Actor> GetAllActorsIn(string group)
        {
            Validator.CheckNotBlank(group);
            return _current[group];
        }

        public Actor GetFirstActorIn(string group)
        {
            Validator.CheckNotBlank(group);
            return GetAllActorsIn(group)[0];
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