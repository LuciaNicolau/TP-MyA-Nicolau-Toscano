using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    Transform _transform;
    float _swipeSpeed;
    float _jumpForce;
    Rigidbody2D _rb;
    public Movement(Transform t, float swipeSpeed, float jumpForce, Rigidbody2D rb)
    {
        _transform = t;
        _swipeSpeed = swipeSpeed;
        _jumpForce = jumpForce;
        _rb = rb;
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(float h)
    {
        _transform.position += _transform.right * h * _swipeSpeed * Time.deltaTime;
    }
}
