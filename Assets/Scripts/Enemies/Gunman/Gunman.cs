using UnityEngine;
using System.Collections;

public class Gunman : MonoBehaviour
{
	BTS global;
	GameObject bulletStartPostition;
	BulletTime bulletTime;

	public float i = 0;
	public int timeToShoot = 1;

	void Start()
	{
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
		bulletStartPostition = GameObject.Find("BulletStartPosition");
		bulletTime = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletTime>();
	}

	void Update()
	{
		if (i >= timeToShoot)
		{
			Shoot();

			i = 0;
		}

		i += Time.deltaTime;
	}

	public void Shoot()
	{
		global.ShootBullet(bulletStartPostition.transform);
		Debug.Log("Shooting");
	}
}