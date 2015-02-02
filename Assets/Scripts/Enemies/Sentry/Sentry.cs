using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour
{
	GameObject player;
	public GameObject bullet;
	public GameObject bulletPosition;
	Rigidbody2D bulletRB;
	BulletTime bulletTime;
	BTS global;

	public float timeLeft = 0f;
	public float timeToWait = 0.3f;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		bulletTime = player.GetComponent<BulletTime>();
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			Shoot();
		}

		if (timeLeft >= timeToWait)
		{
			Shoot();
			timeLeft = 0f;
		}
		timeLeft += Time.deltaTime;
	}

	void Shoot()
	{
		global.ShootBullet(bulletPosition.transform);
	}
}
