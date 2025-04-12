using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private Sprite[] _sprites;

    private float _accTime;
    private int _currentIndex = 0;

    void Update()
    {
        _accTime += Time.deltaTime;

        if (_accTime > 0.1f)
        {
            _currentIndex++;

            if (_currentIndex >= _sprites.Length)
            {
                Destroy(gameObject);
                return;
            }

            _accTime = 0;

            Debug.Log("_currentIndex : " + _currentIndex);

            _renderer.sprite = _sprites[ _currentIndex ];
        }
    }
}
