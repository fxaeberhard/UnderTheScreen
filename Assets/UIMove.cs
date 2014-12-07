using UnityEngine;
using System.Collections;

public class UIMove : MonoBehaviour
{

		private bool _mouseState;
		private GameObject target;
		public Vector3 screenSpace;
		public Vector3 offset;

		public Vector2[] positions = new Vector2[3];

	public Vector3 originalPosition;

		// Use this for initialization
		void Start () { 
			GameObject[] elements = GameObject.FindGameObjectsWithTag ("uielement");
			print (elements.Length);
			for (int i = 0; i<elements.Length; i++) {
				print(elements[i].transform.position);	
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
			// Debug.Log(_mouseState);
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hitInfo;
				target = GetClickedObject (out hitInfo);
				if (target != null && target.tag == "uielement") {
					
				
					if (!_mouseState) {	// Mouse was clicked
						originalPosition = Input.mousePosition;
					}
					_mouseState = true;
					screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
					offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

				}
			}
			
			if (Input.GetMouseButtonUp (0)) {
					_mouseState = false;
			}
			if (_mouseState) {

				
				var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);//keep track of the mouse position
				var delta = originalPosition - Input.mousePosition;
				
				if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
					print("hori "+Mathf.Abs(delta.x)+":"+Mathf.Abs(delta.y));
					curScreenSpace = new Vector3 (Input.mousePosition.x, originalPosition.y, screenSpace.z);
				} else {
					print("verti "+Mathf.Abs(delta.x)+":"+Mathf.Abs(delta.y));
					curScreenSpace = new Vector3 (originalPosition.x, Input.mousePosition.y, screenSpace.z);
				}

				var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;//convert the screen mouse position to world point and adjust with offset
				target.transform.position = curPosition;
				//print ("moving to "+ curPosition);
			}
			
		}

		GameObject GetClickedObject (out RaycastHit hit)
		{
			GameObject target = null;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
					target = hit.collider.gameObject;
			}
	
			return target;
		}
}
