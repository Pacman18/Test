using System;
using System.Collections;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingletone<GameManager>
{   
    
    [SerializeField]
    private Transform _canvasTrasn; // 씬이 바뀌면 사라짐 
    
    void Start()
    {
        var temp = Instance;

        UIManager.Instance.CreateStartUI();

        //StartCoroutine(TimeCheck());
    }

    private void OnClickStartButton()
    {
        //_startButton.gameObject.SetActive(false);       

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
        GameObject realGO = Instantiate(resGO);
        realGO.transform.position = new Vector3(0,-2.66f,0);

        // 배경도 로드해야겠다.
        GameObject bottomRes = Resources.Load<GameObject>("Prefab/Bottom");
        GameObject bottomGo = Instantiate(bottomRes);

        // 일반 공을 생성해봐야겠다. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/Gong");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position = new Vector3(0, 6, 0);


        Transform tr = realGO.transform;

        // 게임 UI 로드하는 부분 
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefab/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();
    }

    public void CreateEffect(Vector3 pos)
    {
        // 일반 공을 생성해봐야겠다. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/ExplosionEffect");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position= pos;
    }

    int index = 0;

    private IEnumerator TimeCheck()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);


            index++;

            Debug.Log("index : " + index);
        }
    }





    private void OnClickStageMode()
    {

    }

}
