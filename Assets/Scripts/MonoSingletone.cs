using Unity.VisualScripting;
using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instace;

    public static T Instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = FindAnyObjectByType<T>(); // 현재 존재하는 씬에 T가 있는지 확인 

                if(_instace == null)
                {
                    GameObject go = new GameObject("Singletone " + typeof(T).ToString());
                    _instace = go.AddComponent<T>();
                    
                }

                DontDestroyOnLoad(_instace.gameObject);
            }

            return _instace;

        }
    }

}
