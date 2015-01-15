using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{
	public float bulletTime = 1000.0f;
	public bool bulletTimeOn = false;
	public float bulletTimeScale = 0.15f;
	public float bulletSpeed = 100f;
	bool debugMode = true;

	GameObject player;
	PlayerController playerC;
	Rigidbody2D playerR;
	GameObject mainCam;
	PlayerController walkSpeed;
	Sentry timeToWait;

	void Start()
	{

		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
		mainCam = GameObject.Find("MainCamera");
		walkSpeed = player.GetComponent<PlayerController>();
		StartCoroutine(DrainBulletTime());
		timeToWait = GameObject.Find("Sentry").GetComponent<Sentry>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) && !bulletTimeOn)
		{
			//if (!bulletTimeOn)
			//{
			//    StartBulletTime();
			//}
			//else
			//{
			//    StopBulletTime();
			//}

			StartBulletTime();
		}
		else if (!Input.GetKey(KeyCode.LeftShift) && bulletTimeOn)
		{
			StopBulletTime();
		}
	}

	void StartBulletTime()
	{
		if (bulletTime > 0)
		{
			bulletTimeOn = true;
			bulletSpeed /= 8f;
			walkSpeed.speed /= 2f;
			timeToWait.timeToWait *= 2f;
		}
		else
		{
			Debug.Log("no BT left");
		}
	}

	void StopBulletTime()
	{
		bulletTimeOn = false;

		bulletSpeed *= 8f;
		walkSpeed.speed *= 2f;
		timeToWait.timeToWait /= 2f;
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(10.0f, 10.0f, 70.0f, 20.0f), bulletTime.ToString() + ", " + bulletTimeOn.ToString());
	}

	IEnumerator DrainBulletTime()
	{
		if (debugMode == false)
		{
			while (true)
			{
				if (bulletTimeOn)
				{
					if (bulletTime > 0 && bulletTime <= 1000)
					{
						bulletTime--;
					}
					else if (bulletTime <= 0)
					{
						StopBulletTime();
						Debug.Log("no BT left");
					}

					yield return new WaitForSeconds(0.005f);
				}

				yield return 0;
			}
		}
	}
}
