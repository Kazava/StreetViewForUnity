//C#
using UnityEngine;
using System.Collections;

public class Buttion : MonoBehaviour {
	
	void OnGUI () {
		// バックグラウンド ボックスを作成します。
		GUI.Box(new Rect(10,10,250,225), "Loader Menu");
		
		// 1 つ目のボタンを作成します。 押すと、Application.Loadlevel (1) が実行されます。
		if(GUI.Button(new Rect(20,40,200,50), "OOKUMA")) {
			//Application.LoadLevel(1);
			//GlobalObject.LoadLevelWithParams("StreetViewScene",37.496839608068015,139.92831766605377);
			GlobalObject.LoadLevelWithParams("uiWebScene",1);
		}
		
		// 2 つ目のボタンを作成します。
		if(GUI.Button(new Rect(20,100,200,50), "NAMIE")) {
			//Application.LoadLevel(2);
			//GlobalObject.LoadLevelWithParams("StreetViewScene",37.483177,140.999698);
			GlobalObject.LoadLevelWithParams("uiWebScene",2);
		}
		if(GUI.Button(new Rect(20,160,200,50), "MINAMISOUMA")) {
			//Application.LoadLevel(2);
			//GlobalObject.LoadLevelWithParams("StreetViewScene",37.638322,140.962520);
			GlobalObject.LoadLevelWithParams("uiWebScene",3);
		}
	}
}