using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed  = 3;

    [SerializeField]
    private SpriteRenderer _reneder; // 그려주는애 

    [SerializeField]
    private Sprite[] _sprites; // 그려줄애한테 넘겨줄 그림들 

    private float _accTime = 0; // 누적시간 
    private int _currentIndex = 0; // 현재 그리고 있는 그림중에 몇번째 것 인지
    
    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;

        if(transform.position.y > 10)
            Destroy(gameObject);

        _accTime += Time.deltaTime;

        if (_accTime > 0.05f)
        {
            _currentIndex++;

            if (_currentIndex >= _sprites.Length)
                _currentIndex = 0;

             _reneder.sprite = _sprites[_currentIndex];

            _accTime = 0;
        }
        
    }
}
