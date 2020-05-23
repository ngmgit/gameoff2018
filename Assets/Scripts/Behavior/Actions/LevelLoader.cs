using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Loaders/Level Loader")]
    public class LevelLoader : Action
    {
		private void Start()
		{
            if (Application.isPlaying) 
                SceneManager.LoadScene("Level2", LoadSceneMode.Additive);
		}

        public override void Execute()
        {
        }
    }
}
