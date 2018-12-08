using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Loaders/Level Loader")]
    public class LevelLoader : Action
    {
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		private void Awake()
		{
			SceneManager.LoadScene("Level", LoadSceneMode.Additive);
		}

        public override void Execute()
        {
        }
    }
}
