using UnityEngine;

public class GravityPong : MonoBehaviour
{
    void Start()
    {   
        //Physics2D.bounceThreshold = 10f; // 매우 작은 속도에서도 튕기도록 설정
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D : " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D : " + other.gameObject.name);
    }



}
