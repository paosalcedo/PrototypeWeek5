using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

	public static void RandomizeRotation(Vector3 axis, float rotationAmount, Transform transform)
	{
		transform.Rotate(axis * rotationAmount);
	}
}
