using UnityEngine;
using System.Collections;

// Coded by Adam "bq" Haglund

public class CameraBehavior : MonoBehaviour
{
	Transform transform;
	public GameObject player;
	public float camMoveTime = 0.15f;
	public float yOffset = 1f;
	public float lowestY;
	public float highestY;
	public float lowestX;
	public float highestX;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		transform = this.GetComponent<Transform>();

		var playerPosX = player.transform.position.x;
		var playerPosY = player.transform.position.y;

		transform.localPosition = new Vector3(playerPosX, (playerPosY + yOffset) - playerPosY, -10f);
	}

	// Update is called once per frame
	void Update()
	{
		MoveCam(player.transform.localPosition.x, player.transform.localPosition.y);
	}

	public void MoveCam(float posX, float posY)
	{
		float camPosX = transform.localPosition.x;
		float camPosY = transform.localPosition.y;

		Vector3 newPos = new Vector3(Mathf.Lerp(camPosX, posX, camMoveTime), Mathf.Lerp(camPosY, (posY + yOffset) - posY, 0.25f), -10f);

		if (newPos.x > lowestX && newPos.x < highestX)
		{
			transform.localPosition = new Vector3(newPos.x, camPosY, -10f);
		}
		else if (newPos.x < lowestX)
		{
			transform.localPosition = new Vector3(Mathf.Lerp(camPosX, lowestX, 0.05f), camPosY, -10f);
		}

		if (newPos.y > lowestY && newPos.y < highestY)
		{
			transform.localPosition = new Vector3(camPosX, newPos.y, -10f);
		}

		

		//this.transform.localPosition = newPos;

	}
}