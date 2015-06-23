using UnityEngine;
using System.Collections;
using Leap;

public class HandController : MonoBehaviour
{
		public GameObject[] fingers;
		public GameObject[] colliders;
		public int mouse_x;
		public int mouse_y;
		private float timer = 0;
		private int counter = 0;
		private float pintiV = 0;
		private float pintiVa = 0;
		public int pinchAns = 0;
		private LeapManager _leapManager;
		// Use this for initialization
		void Start ()
		{
				_leapManager = (GameObject.Find ("LeapManager")as GameObject).GetComponent (typeof(LeapManager)) as LeapManager;
		}
	
		// Update is called once per frame
		void Update ()
		{
				Hand primeHand = _leapManager.frontmostHand ();

				if (primeHand.IsValid) {
						Vector3[] fingerPositions = _leapManager.getWorldFingerPositions (primeHand);
						gameObject.transform.position = primeHand.PalmPosition.ToUnityTranslated ();
						if (gameObject.GetComponent<Renderer>().enabled != true) {
								gameObject.GetComponent<Renderer>().enabled = true;
						}

						for (int i=0; i<fingers.GetLength(0); i++) {
								if (i < fingerPositions.GetLength (0)) {
										fingers [i].transform.position = fingerPositions [i];
										if (fingers [i].GetComponent<Renderer>().enabled == false) {
												fingers [i].GetComponent<Renderer>().enabled = true;
										}

										if (colliders != null && i < colliders.GetLength (0)) {
												(colliders [i].GetComponent (typeof(SphereCollider)) as SphereCollider).enabled = true;
										}
								} else {
										fingers [i].GetComponent<Renderer>().enabled = false;
										if (colliders != null && i < colliders.GetLength (0)) {
												(colliders [i].GetComponent (typeof(SphereCollider)) as SphereCollider).enabled = false;
										}
								}
						}
				} else {
						gameObject.GetComponent<Renderer>().enabled = false;

						foreach (GameObject finger in fingers) {
								if (finger.GetComponent<Renderer>().enabled == true) {
										finger.GetComponent<Renderer>().enabled = false;
								}
						}
				}
				mouse_x = (int)fingers [1].transform.position.x;
				mouse_y = (int)fingers [1].transform.position.y;
				Debug.Log (mouse_x);
				if (timer > 1) {
			if(counter >= 12){
				pinchAns = 1;
			}else if(counter <= -12){
				pinchAns = -1;
			}else{pinchAns = 0;}
				timer = 0;
				counter = 0;
				}
				timer += Time.deltaTime * 1;
				if (fingers [0].GetComponent<Renderer>().enabled && fingers [1].GetComponent<Renderer>().enabled) {
						pintiV = Vector3.Distance (fingers [0].transform.position, fingers [1].transform.position);
						if(pintiV > pintiVa){ counter++;
						}else {counter--; }
					pintiVa = pintiV;
				}

		}

		public Vector3 SendPosition ()
		{
				Debug.Log (fingers [0].transform.position);
				return fingers [0].transform.position;
		}
	public int SendPinch()
	{
		return pinchAns;
	}


}
