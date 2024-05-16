using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 vec = Vector3.zero; // new Vector3(0, 0, 0)と同じ

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Method());
        }
        transform.Rotate(vec);
    }

    IEnumerator Method()
    {
        vec.x = 1.0f;   // returnの後に処理をかけるのがポイント

        yield return new WaitForSeconds(3f);    // 3秒処理を止める
        // 3秒後に実行される
        vec.x = 0f;
        vec.y = 1.0f;

        yield return new WaitForSeconds(2f);    // 2秒処理を止める
        // 2秒後に実行される
        vec.y = 0f;
        vec.z = 1.0f;

        yield return new WaitForSeconds(2f);
        vec = Vector3.zero;
    }
}
