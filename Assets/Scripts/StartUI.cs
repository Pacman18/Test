using UnityEngine;
using UnityEngine.UI;

public class StartUI : UIBase
{
    private Button _button;
    
    void Start()
    {
        _button = GetComponentInChildren<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(GameManager.Instance.OnClickStartButton);
        }        
    }    
    
    private void OnClickStartButton()
    {   
        Destroy(gameObject);      
    }

}
