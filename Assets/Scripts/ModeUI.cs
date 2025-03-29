using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    Button _timeAttackButton;

    [SerializeField]
    Button _stageModeButton;

    public void AddTimeClickEvent(UnityAction clickCallback)
    {
        _timeAttackButton.onClick.AddListener(clickCallback);
    }

    public void AddStageClickEvent(UnityAction clickCallback)
    {
        _stageModeButton.onClick.AddListener(clickCallback);
    }




}
