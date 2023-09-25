using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Player player;

	public float offsetY;
	public float offsetZ;

	
	private Vector3 cameraPosition;
    private void Start()
    {
    }
    void LateUpdate()
	{
		cameraPosition.x = player.transform.position.x;
		cameraPosition.y = player.transform.position.y + offsetY;
		cameraPosition.z = player.transform.position.z + offsetZ;

		transform.position = cameraPosition;

		// 자연스러운 카메라 이동(속도) 나중에 추
	}
}
