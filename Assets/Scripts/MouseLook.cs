using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes
    {
        MouseXendY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXendY;
    [SerializeField] private float _sensitivityHorizon = 9.0f;
    [SerializeField] private float _sensitivityVertical = 9.0f;
    [SerializeField] private float _minVertical = -45.0f;
    [SerializeField] private float _maxVertical = 45.0f;

    private Rigidbody _body;

    private float _rotationX = 0f;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();

        if (_body != null)
        {
            _body.freezeRotation = true;
        }
    }
    void Update()
    {
        if (_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHorizon, 0);
        }
        else if (_axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityHorizon;

            _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityHorizon;

            _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);

            float delta = Input.GetAxis("Mouse X") * _sensitivityHorizon;

            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

        }
    }
}
