using UnityEngine;
using System.Collections;

public class PlayerDrag : MonoBehaviour
{

    public float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    public float lerpTime;
    void Start()
    {
        _rotation = Vector3.zero;
    }

    void Update()
    {
        if (_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);

            _rotation.x = Mathf.Lerp(_rotation.x, -(_mouseOffset.y) * _sensitivity, lerpTime);
            _rotation.y = Mathf.Lerp(_rotation.y, (_mouseOffset.x) * _sensitivity, lerpTime);


            transform.Rotate(_rotation);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

            _mouseReference = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;

            _mouseReference = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }
    }
}