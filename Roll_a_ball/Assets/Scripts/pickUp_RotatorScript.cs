using UnityEngine;
using System.Collections;

public class pickUp_RotatorScript : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
	{
		// rotating a Game Objects transform
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	
	}
}
