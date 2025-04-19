using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{   
    
    [SerializeField]
    private Transform _canvasTrasn; // ���� �ٲ�� ����� 
    
    void Start()
    {
        var temp = Instance;

        UIManager.Instance.CreateStartUI();        
    }

    /*private void OnClickStartButton()
    {
        //_startButton.gameObject.SetActive(false);       

        Debug.Log("OnClickStartButton");
        // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);
    }*/

    // ��ó�� StartUI��ư �������� �Լ� 
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
        // ���⼭ ���Ӿ��� �� �ε� �� ���Ŀ� ���� �ڵ带 �аڽ��ϴ�. 
        yield return SceneManager.LoadSceneAsync(sceneName);

        // �÷��̾� �������ָ� �� 
        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        GameObject realGO = Instantiate(resGO);
        realGO.transform.position = new Vector3(0,-2.66f,0);

        // ��浵 �ε��ؾ߰ڴ�.
        GameObject bottomRes = Resources.Load<GameObject>("Prefab/Bottom");
        GameObject bottomGo = Instantiate(bottomRes);

        // �Ϲ� ���� �����غ��߰ڴ�. 
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
            // ���� ���
            string path = Application.persistentDataPath + "/playerData.json";

            Debug.Log("path " + path);
            Human human = new Human();
            human.number = 10;
            human.name = "123";
            string json = JsonUtility.ToJson(human);

            // ���Ϸ� ����
            File.WriteAllText(path, json);

            Debug.Log(json);
        }
    }

    public void CreateEffect(Vector3 pos)
    {
        // �Ϲ� ���� �����غ��߰ڴ�. 
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