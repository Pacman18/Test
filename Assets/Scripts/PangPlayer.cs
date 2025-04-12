using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE, // 가만히 서 있는 상태
        MOVE, // 움직이는 상태
        HITTED, // 
    }

    // 현재 가지고 있는 스프라이트중 
    // 몇번째 스프라이트를 출력중인가를 알아야하니까 
    private int _currentSpriteIndex; 

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

        //var gm = GameManager.Instance;
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {   
            transform.position += Vector3.left * Time.deltaTime * _speed;
            _currentState = STATE.MOVE;
            _render.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
            _currentState = STATE.MOVE;
            _render.flipX = false;
        }
        else
        {
            _currentState = STATE.IDLE;
        }
    }


    private void IDLE_Action()
    {        
        MoveInput();

        _accTime += Time.deltaTime;

        if(_accTime >= 0.2f)
        {
            // 여기는 Update에서 계속들어올꺼야 
            _currentSpriteIndex++;

            if (_currentSpriteIndex >= IdleSprites.Length)
                _currentSpriteIndex = 0;

            _render.sprite = IdleSprites[_currentSpriteIndex];

            _accTime = 0;
        }
        
       
    }

    private void Move_Action()
    {
        //Debug.Log("move Action");
        MoveInput();

        _accTime += Time.deltaTime;

        if (_accTime >= 0.2f)
        {
            // 여기는 Update에서 계속들어올꺼야 
            _currentSpriteIndex++;

            if (_currentSpriteIndex >= WalkSprites.Length)
                _currentSpriteIndex = 0;

            _render.sprite = WalkSprites[_currentSpriteIndex];

            _accTime = 0;
        }
        
    }

    private void HITTED_Action()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject resGO = Resources.Load<GameObject>("Prefab/Bullet");
            GameObject realGO = Instantiate(resGO);

            realGO.transform.position = transform.position + new Vector3(0, 0.5f, 0);

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
