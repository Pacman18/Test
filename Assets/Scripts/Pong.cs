using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class Pong : MonoBehaviour
{
    private float _groundY = -3;

    private float _gravity = 9.8f;
    private float _speed = 0;

    private bool _isDown = true;


    // Update is called once per frame
    void Update()
    {
        if(_isDown)
        {
            Drop();
        }
        else
        {
            Rise();
        }
    }

    private void Rise()
    {
        if (_speed < 0)
        {
            _isDown = true;
            return;
        }

        _speed -= _gravity * Time.deltaTime;

        transform.position += Vector3.up * Time.deltaTime * _speed;

    }


    private void Drop()
    {
        if(transform.position.y <= _groundY)
        {
            _isDown = false;
            _speed = _speed * -1;
            return;
        }

        _speed += _gravity * Time.deltaTime;

        transform.position += Vector3.down * Time.deltaTime * _speed;

    }
}
