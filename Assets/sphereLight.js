#pragma strict
/*var dropTarget : GameObject = new GameObject("The Light");
dropTarget.AddComponent(Light);
dropTarget.light.type = LightType.Point;
*/

var dropTarget : GameObject;
var sixSphere = new Array();
var i = 0;
function Start () {
}

function Update () {
	if(Input.GetMouseButtonDown(1)){
		i++;
		var mousePos = Input.mousePosition;
		mousePos.z = 2;
		var ray = Camera.main.ScreenToWorldPoint(mousePos);
       	sixSphere[i] = Instantiate(dropTarget, ray, Quaternion.identity);
       	Debug.Log(sixSphere[i]);
	}
	if(sixSphere.length>=7){
		i--;
		Debug.Log(sixSphere.length);
		Destroy(sixSphere[0]);
		sixSphere.splice(0, 1);
	}
}
