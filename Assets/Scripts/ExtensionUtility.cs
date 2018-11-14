using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionUtility
{
	public static Vector2 toVecto2(this Vector3 vec3)
	{
		return new Vector2(vec3.x, vec3.y);
	}
}
