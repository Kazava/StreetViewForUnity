
using UnityEngine;
using System.Collections;

public class WebviewSample : MonoBehaviour {
	public string url;
	WebViewObject webViewObject;
	
	// Use this for initialization
	void Start () {
		webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
		webViewObject.Init((msg) => {
			Debug.Log(msg);
		});
		webViewObject.LoadURL("http://google.com/");
		webViewObject.SetMargins(0, 0, 0, 100);
		webViewObject.SetVisibility(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}