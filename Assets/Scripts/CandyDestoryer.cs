using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoryer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            // 指定数だけCandyストックを増やす
            candyManager.AddAmount(reward);

            // オブジェクトを削除
            Destroy(other.gameObject);
        }
    }
}
