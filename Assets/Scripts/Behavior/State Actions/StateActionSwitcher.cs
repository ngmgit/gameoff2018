using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/State Actions/Switcher")]
    public class StateActionSwitcher : StateActions
    {
		public SO.BoolVariable targetBool;
		public StateActions onTrueActions;
		public StateActions onFalseActions;

        public override void Execute(StateManager states)
        {
			if (targetBool.value)
			{
				if (onTrueActions != null)
					onTrueActions.Execute(states);
			} else {
				if (onFalseActions != null)
					onFalseActions.Execute(states);

			}
        }
    }
}
