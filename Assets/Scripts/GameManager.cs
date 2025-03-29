using System.Collections;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Transform _canvasTrasn;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
        
        _startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);       

        Debug.Log("OnClickStartButton");
        // ModeUI 프리팹을 리소스를 로드해서, Instantiate한다. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);
    }

    private void OnClickTimeAttackMode()
    {
       Debug.Log("OnClickTimeAttackMode");

        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // 여기서 게임씬이 다 로드 된 이후에 다음 코드를 읽겠습니다. 
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 플레이어 생성해주면 됨 
        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        Instantiate(resGO);
    }





    private void OnClickStageMode()
    {

    }

}
