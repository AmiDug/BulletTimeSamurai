using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{
	public float bulletTime = 100.0f;
	public bool bulletTimeOn = false;
	public float bulletTimeScale = 0.15f;

	GameObject player;
	PlayerController playerC;
	Rigidbody2D playerR;
	GameObject mainCam;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
		playerR = player.GetComponent<Rigidbody2D>();
		mainCam = GameObject.Find("MainCamera");

		StartCoroutine(DrainBulletTime());
	}

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
	}

	void StartBulletTime()
	{
		if (bulletTime > 0)
		{
			bulletTimeOn = true;

			Time.timeScale = bulletTimeScale;
			playerC.speed *= 3f; 
		}
		else
		{
			Debug.Log("no BT left");
		}
	}

	void StopBulletTime()
	{
		bulletTimeOn = false;

		Time.timeScale = 1.0f;
		playerC.speed /= 3f;
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(10.0f, 10.0f, 70.0f, 20.0f), bulletTime.ToString() + ", " + bulletTimeOn.ToString());
	}

	IEnumerator DrainBulletTime()
	{
		while (true)
		{
			if (bulletTimeOn)
			{
				if (bulletTime > 0 && bulletTime <= 100)
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
