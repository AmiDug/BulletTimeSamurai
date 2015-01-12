using UnityEngine;
using System.Collections;

public class LaserHandler : MonoBehaviour
{

	Gunman gunman;

	void Start()
	{
		gunman = this.GetComponentInParent<Gunman>();
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("Found ya");
		gunman.Shoot();
	}
}
