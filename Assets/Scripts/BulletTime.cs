using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{
	public float bulletTime = 100.0f;
	public bool bulletTimeOn = false;
	public float bulletTimeScale = 0.5f;

	GameObject player;
	PlayerController playerC;
	Rigidbody2D playerR;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.V))
		{
			if (!bulletTimeOn)
			{
				StartBulletTime(); 
			}
			else
			{
				StopBulletTime();
			}
		}
	}

	void StartBulletTime()
	{
		bulletTimeOn = true;

		playerC.speed = playerC.speed * 3f;
		playerR.gravityScale = playerR.gravityScale * 4;
		Time.timeScale = bulletTimeScale;
	}

	void StopBulletTime()
	{
		bulletTimeOn = false;

		playerC.speed = playerC.speed / 3f;
		playerR.gravityScale = playerR.gravityScale / 4;
		Time.timeScale = 1.0f;
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(10.0f, 10.0f, 70.0f, 20.0f), bulletTime.ToString() + ", " + bulletTimeOn.ToString());
	}
}
