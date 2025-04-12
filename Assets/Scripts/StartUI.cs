using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private Button _button;
    
    void Start()
    {
        _button = GetComponentInChildren<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnClickStartButton);
        }        
    }

    private void OnClickStartButton()
    {
        UIManager.Instance.CreateModeUI();

        Destroy(gameObject);
        //_button.gameObject.SetActive(false);

        /*Debug.Log("OnClickStartButton");
        // ModeUI 프리팹을 리소스를 로드해서, Instantiate한다. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);*/
    }

}
