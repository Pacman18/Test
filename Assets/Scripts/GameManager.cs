using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{   
    
    [SerializeField]
    private Transform _canvasTrasn; // 씬이 바뀌면 사라짐 
    
    void Start()
    {
        var temp = Instance;

        UIManager.Instance.CreateStartUI();        
    }

    /*private void OnClickStartButton()
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
    }*/

    // 맨처음 StartUI버튼 눌렸을때 함수 
    public void OnClickStartButton()
    {
        UIManager.Instance.CreateModeUI();
    }

    public void OnClickTimeAttackMode()
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

        UIManager.Instance.CreateScoreUI();        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 파일 경로
            string path = Application.persistentDataPath + "/playerData.json";

            Debug.Log("path " + path);
            Human human = new Human();
            human.number = 10;
            human.name = "123";
            string json = JsonUtility.ToJson(human);

            // 파일로 저장
            File.WriteAllText(path, json);

            Debug.Log(json);
        }
    }

    public void CreateEffect(Vector3 pos)
    {
        // 일반 공을 생성해봐야겠다. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/ExplosionEffect");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position= pos;
    }

    public void AddScore()
    {
        UIManager.Instance.AddScore();
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


[System.Serializable]
public class Human
{
    public string name;
    public int number;
}