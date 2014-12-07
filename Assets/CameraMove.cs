using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	//private Animator animator;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")){
			Animator animator =  this.GetComponent<Animator>();
			animator.Play("SwitchScreen");
			print ("space key was pressed");
		}
	}
}
