using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPlayerPosition : MonoBehaviour {

	public SO.GameEvent alertListenersOnEnter;
	public SO.GameEvent alertListenersOnExit;
	public float delayTime;
	public float readTime;

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			readTime += Time.deltaTime;
			if (readTime >= delayTime)
			{
				alertListenersOnEnter.Raise();
				readTime = 0;
			}
		}

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		alertListenersOnExit.Raise();
	}

}
