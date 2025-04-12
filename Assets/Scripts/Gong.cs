using UnityEngine;

public class Gong : MonoBehaviour
{
    public enum GongState
    {
        None = 0,
        Drop,
        Left,
        Right,
    }

    private GongState _state;
    private float _speed = 0;
    private float _horizonSpeed = 3;
    private float _gravity = -9.8f;
    private bool _isLeftMove = false;

    private float _accTime = 0;
    private int _count = 0;
    
    void Start()
    {
        _state = GongState.Drop;
    }

    private void Update()
    {
        switch(_state)
        {
            case GongState.Drop:
                _accTime += Time.deltaTime;
                if(_accTime > 1)
                {
                    transform.position += new Vector3(0, -1, 0);
                    _count++;
                    _accTime = 0;

                    if(_count > 3)
                    {
                        int result = Random.Range(0, 2);
                        if(result > 0)
                            _state = GongState.Left;
                        else
                            _state = GongState.Right;
                    }
                }
                break;
            case GongState.Left:
                LeftMove();
                break;
            case GongState.Right:
                RightMove();
                break;
        }        

        // 여기는 왼쪽 오른쪽으로 영역이 넘어가면 바꿔주는부분
        if (transform.position.x < -8 || transform.position.x > 8)
        {
            if (transform.position.x > 8)
                transform.position = new Vector3(8, transform.position.y, 0);

            if (transform.position.x < -8)
                transform.position = new Vector3(-8, transform.position.y, 0);

            _isLeftMove = !_isLeftMove;

            if(_isLeftMove)
                _state = GongState.Left;    
            else
                _state = GongState.Right;
        }

        if (_state == GongState.Drop)
            return;

        // 여기는 중력부분
        if (transform.position.y < -3.3f)
        {
            _speed = 10;
            transform.position = new Vector3(transform.position.x, -3.29f,0);
            return;
        }

        _speed += _gravity * Time.deltaTime;
        transform.position += new Vector3(0, _speed * Time.deltaTime, 0);

        
    }

    private void LeftMove()
    {
        transform.position += Vector3.left * Time.deltaTime * _horizonSpeed;
    }

    private void RightMove()
    {
        transform.position += Vector3.right * Time.deltaTime * _horizonSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 position = other.contacts[0].point;
    }

    // 충돌 했을때
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D : " + other.gameObject.name);

        GameManager manager = GameManager.Instance;

        Vector3 center = (transform.position + other.transform.position) * 0.5f;

        manager.CreateEffect(center);

        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }

}
