using UnityEngine;
using System.Collections;

public class ColliderSwingScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//collider = this.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider2D other)
	    {
		if(other.gameObject.tag == "swing")
		   {
			collider.isTrigger = true;
		   }
		}
}