using UnityEngine;

public class Tester : MonoBehaviour
{
    NumberBox number;
    
    void Start()
    {
        number = new NumberBox();
    }

    // Update is called once per frame
    void Update()
    {        

    }
}

public class NumberBox
{
    public int Number;
}


