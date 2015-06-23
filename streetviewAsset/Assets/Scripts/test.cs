using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		double hoge = GlobalObject.getInstance().Params[1];
		Debug.Log(hoge);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
