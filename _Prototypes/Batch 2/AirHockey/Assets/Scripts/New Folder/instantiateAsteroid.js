#pragma strict

var objectToInstantiate : GameObject;
private var myCurrentObject : GameObject;
public var camera : GameObject;

function Start()
{
    if (camera == null)
    {
        GameObject.GetComponent.Camera;
    }
}
 
function Update(){
    // if(Input.GetMouseButtonDown(0)){
    //   myCurrentObject = Instantiate(objectToInstantiate, GetComponent.<Camera>().ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);
    // myCurrentObject.transform.position.z = 0;
    //}
    if(Input.GetMouseButton(0) && myCurrentObject)
    {
        myCurrentObject.transform.position =  GetComponent.<Camera>().ScreenToWorldPoint(Input.mousePosition);
        myCurrentObject.transform.position.z = 0;
    }
    if(Input.GetMouseButtonUp(0) && myCurrentObject){
        myCurrentObject = null;
    }
}
function OnMouseDown ()
{
    if(Input.GetMouseButtonDown(0)){
        myCurrentObject = Instantiate(objectToInstantiate, GetComponent.<Camera>().ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);
        myCurrentObject.transform.position.z = 0;
    }
}