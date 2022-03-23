using System.Collections.Generic;


namespace Byui.Game.Scripting
{
    /// <summary>
    /// A collection of Actions.
    /// </summary>
    /// <remarks>
    /// The responsibility of Script is to maintain a collection of IActions.
    /// </remarks>
    public class Script
    {
        private Dictionary<int, List<IAction>> _actions = new Dictionary<int, List<IAction>>();

        public Script()
        {
        }

        public void Put(int phase, IAction action)
        {
            if (!_actions.ContainsKey(phase))
            {
                _actions[phase] = new List<IAction>();
            }

            if (!_actions[phase].Contains(action))
            {
                _actions[phase].Add(action);
            }
        }

        public List<IAction> Get(int phase)
        {
            return new List<IAction>(_actions[phase]);
        }

        public void Remove(int phase, IAction action)
        {
            _actions[phase].Remove(action);
        }
    }
}