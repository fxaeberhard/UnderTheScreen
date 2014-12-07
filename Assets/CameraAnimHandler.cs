using UnityEngine;
using System.Collections;

public class CameraAnimHandler : MonoBehaviour {

	public Transform[] camPositions;

	int _state = 0;

	static float _tweenDuration = 1;

	void Start(){
		Debug.Log(camPositions.Length);
		transform.position = camPositions[0].position;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.DownArrow))
			TransitionToNextState();

		if(Input.GetKeyDown(KeyCode.UpArrow))
			TransitionToPreviousState();
	}

	void TransitionToNextState(){
		if (_state == 2)
			return;

		Go.killAllTweensWithTarget(transform);

		_state += 1;

		transform.positionTo(_tweenDuration,  camPositions[_state].position);
	}

	void TransitionToPreviousState(){
		if (_state == 0)
			return;
		
		Go.killAllTweensWithTarget(transform);
		
		_state -= 1;
		
		transform.positionTo(_tweenDuration,  camPositions[_state].position);
	}
}
