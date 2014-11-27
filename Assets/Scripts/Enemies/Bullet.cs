using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		StartCoroutine(removeTimer()); 
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//if (coll.tag =="Player")
		//{
		//	Debug.Log("NOOOOOooo");
		//}
	}

	IEnumerator removeTimer()
	{
		yield return new WaitForSeconds(4.0f);

		DestroyObject(this.gameObject);
		yield return null;
	}
}
