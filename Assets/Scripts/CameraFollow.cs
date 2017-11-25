using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField] private Transform _target;
	[SerializeField] private Transform _leftPoint;
	[SerializeField] private Transform _rightPoint;

	private Transform _currentTarget;


	// Update is called once per frame
	void Update ()
	{
		if (_target.position.x <= _leftPoint.transform.position.x)
			_currentTarget = _leftPoint;
		else if (_target.position.x >= _rightPoint.transform.position.x)
			_currentTarget = _rightPoint;
		else
			_currentTarget = _target;

		transform.position = new Vector3(_currentTarget.position.x,transform.position.y,transform.position.z);

	}
}
