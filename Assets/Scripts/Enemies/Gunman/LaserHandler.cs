using UnityEngine;
using System.Collections;

public class LaserHandler : MonoBehaviour
{

	Gunman gunman;

	public float cooldown = 2f;
	public float i = 0f;

	void Start()
	{
		gunman = this.GetComponentInParent<Gunman>();

		if (gunman == null)
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
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (i > 2)
		{
			Debug.Log("Found ya");
			gunman.Shoot();

			i = 0;
		}
	}
}
