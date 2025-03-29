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
        // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
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
        // ���⼭ ���Ӿ��� �� �ε� �� ���Ŀ� ���� �ڵ带 �аڽ��ϴ�. 
        yield return SceneManager.LoadSceneAsync(sceneName);

        // �÷��̾� �������ָ� �� 
        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        Instantiate(resGO);
    }





    private void OnClickStageMode()
    {

    }

}
