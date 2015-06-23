#pragma strict

public var frontimage : Material;
public var rightimage : Material;
public var leftimage : Material;
public var backimage : Material;
public var upimage : Material;
public var downimage : Material;

public var size : int = 512;
public var zoom : int = 0;
public var DownloadImg : WWW;


function Start () {

	var lat : double = GlobalObject.getInstance().Params[0];
	var lon : double = GlobalObject.getInstance().Params[1];

	var frontTex = RetrieveGPSData(0, 2, lat, lon);
	var leftTex = RetrieveGPSData(90, 3, lat, lon);
	var rightTex = RetrieveGPSData(270,-1.1, lat, lon);
	var backTex = RetrieveGPSData(180, 0, lat, lon);
	var upTex = RetrieveGPSData(0, 90, lat, lon);
	var downTex = RetrieveGPSData(0, -90, lat, lon);
	yield WaitForSeconds (4);
	RenderSettings.skybox.SetTexture("_FrontTex",frontTex.texture);
	RenderSettings.skybox.SetTexture("_LeftTex",leftTex.texture);
	RenderSettings.skybox.SetTexture("_BackTex",backTex.texture);
	RenderSettings.skybox.SetTexture("_RightTex",rightTex.texture);
	RenderSettings.skybox.SetTexture("_UpTex",upTex.texture);
	RenderSettings.skybox.SetTexture("_DownTex",downTex.texture);
	Debug.Log(RenderSettings.skybox.GetTexture);

	//RenderSettings.skybox._FrontTex.wrapMode =  TextureWrapMode.Clamp;


}

function Update () {
	if(Input.GetKey(KeyCode.Space)) Application.LoadLevel("Title");

}

function RetrieveGPSData( head, pit, lat, lon) {
		var url = "http://maps.googleapis.com/maps/api/streetview?";
		var qs = "";
		qs += "size=" + size + "x" + size;
		qs += "&location=" + lat + "," + lon;
		// qs += "&heading=" + (heading + sideHeading) % 360.0 + "&pitch=" + (pitch + sidePitch) % 360.0  
		qs += "&heading=" + head + "&pitch=" + pit;  
		qs += "&fov=90.0&sensor=false";

		url += qs;

		DownloadImg = new WWW(url);

		return DownloadImg ; 

		  //StartCoroutine(Downloaded(url,name));
		//Debug.Log("Download URL : " + url);
		
		//DownloadImg = new WWW(url);
		//yield return DownloadImg; // Wait for download to complete
		
		 //frontImage.mainTexture = DownloadImg.texture;
		//renderer.material.mainTexture  = DownloadImg.texture;

		}