using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE, // 가만히 서 있는 상태
        MOVE, // 움직이는 상태
        HITTED, // 
    }

    [SerializeField]
    private Sprite[] IdleSprites;

    [SerializeField]
    private Sprite[] WalkSprites;

    private SpriteRenderer _render;

    private STATE _currentState;

    private float _speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("PangPlayerCreated");
        _currentState = STATE.IDLE;
        _render = GetComponentInChildren<SpriteRenderer>();
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
            _currentState = STATE.MOVE;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
            _currentState = STATE.MOVE;
        }
        else
        {
            _currentState = STATE.IDLE;
        }
    }

    private void IDLE_Action()
    {        
        MoveInput();
        SpriteAnimation(IdleSprites);
    }

    private void Move_Action()
    {
        Debug.Log("move Action");
        MoveInput();
        SpriteAnimation(WalkSprites);
    }

    private void HITTED_Action()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
            case STATE.MOVE:
                Move_Action();
                break;
            case STATE.HITTED:
                HITTED_Action();
                break;
        }      

    }

    private float _accTime = 0;
    private float _changeTime = 0.2f;
    private int _aniIndex = 0;

    private void SpriteAnimation(Sprite[] sprites)
    {
        _accTime += Time.deltaTime;

        if (_accTime >= _changeTime)
        {
            if(_render != null)
            {
                if (_aniIndex >= sprites.Length)
                    _aniIndex = 0;

                _render.sprite = sprites[_aniIndex];
                _aniIndex++;
            }

            _accTime = 0;
        }

    }
}
