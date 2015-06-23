using UnityEngine;
using System.Collections;
using Leap;

public class HandControllerStreetView : MonoBehaviour {
	public GameObject[] fingers;
	public GameObject[] colliders;

	public int mouse_x;
	public int mouse_y;

	private LeapManager _leapManager;
	// Use this for initialization
	void Start () {
		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
	}
	
	// Update is called once per frame
	void Update () {
		Hand primeHand = _leapManager.frontmostHand();

		if(primeHand.IsValid)
		{
			Vector3[] fingerPositions = _leapManager.getWorldFingerPositions(primeHand);
			gameObject.transform.position = primeHand.PalmPosition.ToUnityTranslated();
			if(gameObject.GetComponent<Renderer>().enabled != true) { gameObject.GetComponent<Renderer>().enabled = true; }

			for(int i=0;i<fingers.GetLength(0);i++)
			{
				if(i < fingerPositions.GetLength(0))
				{
					fingers[i].transform.position = fingerPositions[i];
					if(fingers[i].GetComponent<Renderer>().enabled == false) { fingers[i].GetComponent<Renderer>().enabled = true; }

					if(colliders != null && i < colliders.GetLength(0))
					{
						(colliders[i].GetComponent(typeof(SphereCollider)) as SphereCollider).enabled = true;
					}
				}
				else
				{
					fingers[i].GetComponent<Renderer>().enabled = false;
					if(colliders != null && i < colliders.GetLength(0))
					{
						(colliders[i].GetComponent(typeof(SphereCollider)) as SphereCollider).enabled = false;
					}
				}
			}
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = false;

			foreach(GameObject finger in fingers)
			{
				if(finger.GetComponent<Renderer>().enabled == true) { finger.GetComponent<Renderer>().enabled = false; }
			}
		}
		mouse_x = (int)fingers[0].transform.position.x;
			mouse_y = (int)fingers[0].transform.position.y;
	//	Debug.Log(mouse_x);






	}

	public Vector3 SendPosition(){
		return fingers[1].transform.position;
	}


}
