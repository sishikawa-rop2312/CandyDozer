using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoryer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            // 指定数だけCandyストックを増やす
            candyManager.AddAmount(reward);

            // オブジェクトを削除
            Destroy(other.gameObject);

            if (effectPrefab != null)
            {
                // Candyのポジションにエフェクトを生成
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                );
            }
        }
    }
}
