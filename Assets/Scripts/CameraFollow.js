#pragma strict
var player: GameObject;
function Start () {
	
}

function Update () {
	transform.position = player.transform.position;
	transform.position.z = -10;
	//transform.rotation = player.transform.rotation;
}