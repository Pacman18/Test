using UnityEngine;
using System.Collections.Generic;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Xml.Linq;

public class UIBase : MonoBehaviour
{

}


// ����, ����,������ ����ϰڴ�. 
// �̸����� ����! 

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container =  new Dictionary<string, UIBase>();
    
    // �����̳ʿ� �����ؼ� �����ϸ� �ȴ�. 

    private void Awake()
    {
        _canvasTrasn = transform;
    }

    public void CreateStartUI()
    {
        // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        StartUI comp = sceanGO.GetComponent<StartUI>();

        _container.Add(typeof(StartUI).ToString(), comp);
    }    

    //��� UI����� �ڵ带 �ۼ��ؼ� StartUI��ư�� ��������
    // ȣ���غ��� 

    public void CreateModeUI()
    {
        RemoveContainerUI("StartUI");

        // ���ӸŴ����� ModUI������ְ� �־��µ� 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();

        _container.Add("ModeUI", uiComp);

        uiComp.AddTimeClickEvent(GameManager.Instance.OnClickTimeAttackMode);
        uiComp.AddTimeClickEvent(RemoveModeUI);
    }

    private void RemoveModeUI()
    {
        RemoveContainerUI("ModeUI");
    }

    private void RemoveContainerUI(string uiName)
    {
        UIBase strtui;
        bool result = _container.TryGetValue(uiName, out strtui);

        if (result)
        {
            Debug.Log(strtui.gameObject.name);
            Destroy(strtui.gameObject);
            _container.Remove(uiName);
        }
    }


    public void CreateScoreUI()
    {
        // ���� UI �ε��ϴ� �κ� 
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefab/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();

        _container.Add("ScoreUI", scoreUIComp);
    }

    public void AddScore()
    {
        UIBase strtui;
        bool result = _container.TryGetValue("ScoreUI", out strtui);

        if (result)
        {
            ScoreUI comp;

            comp = strtui as ScoreUI;

            if (comp != null)
            {
                comp.ChangeScore(2000);
            }
        }

        //scoreUIComp.ChangeScore(20000);
    }
   

}
