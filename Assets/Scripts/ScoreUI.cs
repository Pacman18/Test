using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _scoreText;
    
    void Start()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // 실제사용할때는 얘를 사용함 
    public void ChangeScore(int score)
    {
        _scoreText.text= score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 얘가 테스트 코드가 됨 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScore(4885);
        }
        
    }
}
