using UnityEngine;
using System.Collections;

public class delete : MonoBehaviour {
	GameObject selected;
	Rigidbody myRigidBody;
	bool canMove = false;
	private float zMove = .1f;
	private Transform myTransform  ;
	private Transform camTransform ;
	Vector3 mousePos;
	float scroll;
	
	// Use this for initialization
	void Start () {
		myRigidBody = rigidbody;
		camTransform = Camera.main.transform;
		myTransform = transform;
		mousePos = Input.mousePosition;
		mousePos.z = 2;
		scroll = mousePos.z;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (mousePos.x + " " + mousePos.y);
		if(canMove){
			mousePos.x = Input.mousePosition.x;
			mousePos.y = Input.mousePosition.y;
			if(Input.GetAxis("Mouse ScrollWheel")<0&&mousePos.z>.8){
				mousePos.z = mousePos.z - (mousePos.z)*zMove;
				//Debug.Log (mousePos.z + " " + zMove);
			}
			if(Input.GetAxis("Mouse ScrollWheel")>0&&mousePos.z<50){
				mousePos.z = mousePos.z + (mousePos.z)*zMove;
			}
			Vector3 move = Camera.main.ScreenToWorldPoint(mousePos) - myTransform.position;
			//Debug.Log("move" + move.x + " " + move.y + " " +move.z);
			myRigidBody.MovePosition(myRigidBody.position + move);
			
		}
		else{
			if(selected!=null){
				if(Input.GetAxis("Mouse ScrollWheel")<0&&scroll>.8){
					scroll = scroll - (scroll)*zMove;
					Vector3 scrollVect = new Vector3(mousePos.x, mousePos.y, scroll);
					Vector3 scrollMove = Camera.main.ScreenToWorldPoint(scrollVect)-myTransform.rigidbody.position;
					//Debug.Log("scrollmove" + scrollMove.x + " " + scrollMove.y + " " + scrollMove.z);
					selected.rigidbody.MovePosition (selected.rigidbody.position + scrollMove);
				}
				if(Input.GetAxis("Mouse ScrollWheel")>0&&scroll<50){
					scroll = scroll + (scroll)*zMove;
					Vector3 scrollVect = new Vector3(mousePos.x, mousePos.y, scroll);
					Vector3 scrollMove = Camera.main.ScreenToWorldPoint(scrollVect)-myTransform.rigidbody.position;
					Debug.Log("scrollmove" + scrollMove.x + " " + scrollMove.y + " " + scrollMove.z);
					selected.rigidbody.MovePosition (selected.rigidbody.position + scrollMove);
				}
			}
		}
		Delete ();
	}
	
	void OnMouseDown(){
		canMove = true;
		mousePos.x = Input.mousePosition.x;
		mousePos.y = Input.mousePosition.y;
		selected = gameObject;
	}
	
	void OnMouseUp(){
		canMove = false;
	}
	
	void Delete(){
		if(Input.GetKeyDown("delete")){
			Destroy (selected);
		}
	}
	
	void Drag(){
		
	}
}
