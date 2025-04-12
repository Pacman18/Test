using UnityEngine;

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _canvasTrasn; 

    private void Awake()
    {
        _canvasTrasn = transform;
    }

    public void CreateStartUI()
    {
        // ModeUI 프리팹을 리소스를 로드해서, Instantiate한다. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        
    }

    //모드 UI만드는 코드를 작성해서 StartUI버튼이 눌렸을때
    // 호출해보자 

    public void CreateModeUI()
    {
        // 게임매니저가 ModUI만들어주고 있었는데 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");       

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();
    }


}
