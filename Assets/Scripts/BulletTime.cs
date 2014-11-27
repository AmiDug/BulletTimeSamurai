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
	GameObject mainCam;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
		mainCam = GameObject.Find("MainCamera");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.V))
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

		if (bulletTimeOn)
		{
			OnBulletTime(bulletTimeOn);
		}
	}

	void StartBulletTime()
	{
		bulletTimeOn = true;

		Time.timeScale = bulletTimeScale;
		playerC.speed = playerC.speed * 2f;
		//playerR.gravityScale = playerR.gravityScale * 2;
	}

	void StopBulletTime()
	{
		bulletTimeOn = false;

		Time.timeScale = 1.0f;
		playerC.speed = playerC.speed / 2f;
		//playerR.gravityScale = playerR.gravityScale / 2;
	}

	void OnBulletTime(bool zoomIn)
	{


		if (zoomIn)
		{
			if (mainCam.camera.orthographicSize > 3)
			{
				mainCam.camera.orthographicSize = Mathf.Lerp(5f, 3f, 0.1f);
			}
		}
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(10.0f, 10.0f, 70.0f, 20.0f), bulletTime.ToString() + ", " + bulletTimeOn.ToString());
	}
}
