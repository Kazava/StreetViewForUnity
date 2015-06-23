using UnityEngine;
using System.Collections;

public class GlobalObject : MonoBehaviour
{
	private static GlobalObject sharedInstance = null;
	private string mStringParam = null;
	private object mParam = null;
	private double[] mParams = null;
	
	public string StringParam {
		get {
			return mStringParam;
		}
	}
	
	public object Param {
		get {
			return mParam;
		}
	}
	
	public double[] Params {
		get {
			return mParams;
		}
	}
	
	public static GlobalObject getInstance ()
	{
		return sharedInstance;
	}
	
	public static void LoadLevelWithString (string levelName, string stringParam)
	{
		getInstance().mStringParam = stringParam;
		Application.LoadLevel(levelName);
	}
	
	public static void LoadLevelWithObject (string levelName, object theParam)
	{
		getInstance().mParam = theParam;
		Application.LoadLevel(levelName);
	}
	
	public static void LoadLevelWithParams (string levelName, params double[] theParams)
	{
		getInstance().mParams = theParams;
		Application.LoadLevel(levelName);
	}
	
	public void Awake ()
	{
		if (sharedInstance == null) {
			Debug.Log("Awake GlobalObject");
			
			sharedInstance = this;
			DontDestroyOnLoad(gameObject);
		}
		
		Debug.Log ("StringParam = " + getInstance().StringParam);
	}
}