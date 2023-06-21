using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _car;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

	public void LookAtTarget()
	{
		Vector3 _lookDirection = _car.position - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, _rotationSpeed * Time.deltaTime);
	}

	public void MoveToTarget()
	{
		Vector3 _targetPos = _car.position +
							 _car.forward * _offset.z +
							 _car.right * _offset.x +
							 _car.up * _offset.y;
		transform.position = Vector3.Lerp(transform.position, _targetPos, _speed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		LookAtTarget();
		MoveToTarget();
	}
}
