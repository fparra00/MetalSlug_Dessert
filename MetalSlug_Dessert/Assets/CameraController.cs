using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


	private static Vector3 position = new Vector3(1.29f, 0.73f, -10.47f);

	void Start()
	{
	}

	void LateUpdate()
	{
		transform.position = position;
	}

	public static void goToStage2()
    {
		position = new Vector3(5.38f, 0.76f, -10.47f);
	}
}
