using UnityEngine;
using System.Collections;

public class LaserHandler : MonoBehaviour
{

	Gunman gunman;
	BTS global;
	public static Transform bulletStartPostition;

	public float cooldown = 2f;
	public float i = 0f;
	public bool shoot = false;

	void Start()
	{
		gunman = this.GetComponentInParent<Gunman>();
		global = GameObject.Find("GameScripts").GetComponent<BTS>();
		bulletStartPostition = GameObject.Find("BulletStartPosition").GetComponent<Transform>();

		if (bulletStartPostition == null)
		{
			Debug.Log("FUCK");
		}
	}

	void Update()
	{
		if (i < 2)
		{
			i += Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			global.ShootBullet(bulletStartPostition);
		}

		if (shoot)
		{
			if (i > 2)
			{
				Debug.Log("Shooting...");
				global.ShootBullet(bulletStartPostition);

				i = 0;
			} 
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
		{
			shoot = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Player")
		{
			shoot = false;
		}
	}
}
