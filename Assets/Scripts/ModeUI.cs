using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeUI : UIBase
{
    [SerializeField]
    Button _timeAttackButton;

    [SerializeField]
    Button _stageModeButton;

    // 타임어택 모드 버튼이 눌렸을때 불리는 이벤트 
    public void AddTimeClickEvent(UnityAction clickCallback)
    {
        _timeAttackButton.onClick.AddListener(clickCallback);
        
    }

    public void AddStageClickEvent(UnityAction clickCallback)
    {
        _stageModeButton.onClick.AddListener(clickCallback);
    }
}
