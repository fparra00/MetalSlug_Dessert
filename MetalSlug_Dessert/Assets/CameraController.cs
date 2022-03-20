using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


	private static Vector3 position;

	void Start()
	{
	}

	void LateUpdate()
	{
	}

	public static void goToStage2()
    {
		position = new Vector3(5.38f, 0.76f, -10.47f);
	}
}
