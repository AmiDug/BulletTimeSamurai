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

	/////////////////////////////////////////////
	/// SIMON EDITED
	/////////////////////////////////////////////

	void Start()
	{
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
		mainCam = GameObject.Find("MainCamera");
		walkSpeed = player.GetComponent<PlayerController>();
		StartCoroutine(DrainBulletTime());

		if (global.gunmanCount > 0 && global.gunmanCount < 2)
		{
			gunman = GameObject.FindGameObjectWithTag("Gunman").GetComponent<Gunman>();

			if (gunman == null)
			{
				Debug.Log("Couldn't get gunman!");
			}
			gunman.gunRotationSpeed /= 2f;
		}

		if (global.sentryCount > 0 && global.gunmanCount < 2)
		{
			sentry = GameObject.Find("Sentry").GetComponent<Sentry>();
		}

		//Debug.Log(gunman.gameObject.name);
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

				if (global.sentryCount > 0)
				{
					if (global.sentryCount == 1)
					{
						sentry.timeToWait *= bulletTimeScale;  
					}
				}

				if (global.gunmanCount > 0)
				{
					if (global.gunmanCount == 1)
					{
						gunman.gunRotationSpeed /= 4f;
					}
				}
			}
			catch (System.NullReferenceException e)
			{
				Debug.LogError(e); 
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

			if (global.sentryCount > 0)
			{
				if (global.sentryCount == 1)
				{
					sentry.timeToWait /= bulletTimeScale;
				}
			}

			if (global.gunmanCount > 0)
			{
				if (global.gunmanCount == 1)
				{
					gunman.gunRotationSpeed *= 4f;
				}
			}
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
