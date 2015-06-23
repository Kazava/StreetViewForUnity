using UnityEngine;
using System.Collections;

public class WebDisplay : MonoBehaviour {
	
	private string url1 ="file:///Users/ricktsukida/Documents/streetviewAsset/Assets/Scripts/map.html";
	private string url2 ="file:///Users/ricktsukida/Documents/streetviewAsset/Assets/Scripts/Namie.html";
	private string url3 ="file:///Users/ricktsukida/Documents/streetviewAsset/Assets/Scripts/MinamiSouma.html";
	private double num = GlobalObject.getInstance().Params[0];

	//private string url = "http://www.yahoo.com";
	WebViewObject webViewObject;
	void Start() {
		webViewObject = (new GameObject ("WebViewObject")).AddComponent<WebViewObject>();
		webViewObject.Init((msg) => {
			//Application.LoadLevel(msg);//Open on this WebView
			Application.OpenURL(msg);// Open external Brawser with return Message(URL)
		});
		if(num == 1.0f){
		webViewObject.LoadURL(url1); //Load URL
		}else if(num == 2.0f){
			webViewObject.LoadURL(url2);
		}else if(num == 3.0f){
			webViewObject.LoadURL(url3);
		}
		webViewObject.SetVisibility(true); // Show on
		//webViewObject.SetMargins(0,0,Screen.width/2,Screen.height - Screen.height/3);//HTML AD size setting
		
	}
}