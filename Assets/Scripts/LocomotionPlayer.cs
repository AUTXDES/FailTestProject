using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionPlayer : MonoBehaviour
{

    public Transform playerModel; 
    private Transform _mainCamera;
    public Rigidbody _rb;
    public Animator _anim; 
    public float _speed = 3f;

    void Start()
    {
        _mainCamera = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float _inputHorizontal = Input.GetAxis("Horizontal");
        float _inputVertical = Input.GetAxis("Vertical");

        _anim.SetFloat("isRuningVertical", _inputVertical);
        _anim.SetFloat("isRuningHorizontal", _inputHorizontal);

        Vector3 camF = _mainCamera.forward;
        Vector3 camR = _mainCamera.right;
        camF.y = 0f;
        camR.y = 0f;

        Vector3 movingVector = _inputHorizontal * camR.normalized + _inputVertical * camF.normalized;
        if (!_mainCamera.GetComponent<CameraController>().stickCamera)
        {
            if (movingVector.magnitude >= 0.2f)
            {
                playerModel.rotation = Quaternion.LookRotation(camF, Vector3.up);
            }
        }

        _rb.velocity = movingVector * _speed;
    }
}