using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosInShader : MonoBehaviour
{

	public SO.TransformVariable playerPos;
	public Vector3 dummy;
	private Material[] currentMat;

	// Use this for initialization
	void Awake ()
	{
		currentMat = GetComponent<Renderer>().materials;
	}

	// Update is called once per frame
	void Update ()
	{
		dummy = playerPos.value.position;
		foreach(Material mat in currentMat)
			if(mat.shader.name == "2DWorldReveal")
			{
				mat.SetColor("_PlayerPos", new Color( playerPos.value.position.x, playerPos.value.position.y, 0));
			}
	}
}
