using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{
	public float bulletTime = 1000.0f;
	public bool bulletTimeOn = false;
	public float bulletTimeScale = 2f;
	public float bulletSpeed = 100f;
	bool debugMode = true;

	BTS global;
	GameObject player;
	PlayerController playerC;
	Rigidbody2D playerR;
	GameObject mainCam;
	PlayerController walkSpeed;
	Sentry sentry;
	Gunman gunman;

	void Start()
	{
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
		mainCam = GameObject.Find("MainCamera");
		walkSpeed = player.GetComponent<PlayerController>();
		StartCoroutine(DrainBulletTime());

		if (global.gunmanCount > 0)
		{
			gunman = GameObject.FindGameObjectWithTag("Gunman").GetComponent<Gunman>(); 
		}

		if (global.sentryCount > 0)
		{
			sentry = GameObject.Find("Sentry").GetComponent<Sentry>();
		}

	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) && !bulletTimeOn)
		{
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
			try
			{
				bulletTimeOn = true;
				bulletSpeed /= bulletTimeScale * 4f;
				walkSpeed.speed /= bulletTimeScale;
				sentry.timeToWait *= bulletTimeScale;

				gunman.gunRotationSpeed = 2f;
			}
			catch (System.NullReferenceException)
			{
				
			} 
		}
		else
		{
			Debug.Log("no BT left");
		}
	}

	void StopBulletTime()
	{
		try
		{
			bulletTimeOn = false;
			bulletSpeed *= bulletTimeScale * 4f;
			walkSpeed.speed *= bulletTimeScale;
			sentry.timeToWait /= bulletTimeScale;
		}
		catch (System.NullReferenceException)
		{
			
		} 
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
