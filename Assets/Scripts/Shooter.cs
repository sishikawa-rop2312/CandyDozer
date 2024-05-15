using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;  // 空Emptyの「Candies」を設定する（Transform型なのに注意）
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth; // オブジェクトBaseの幅が5なので、画面側で5を設定

    void Update()
    {
        // Fire1はクリックが左側のCtrlが設定されている
        if (Input.GetButtonDown("Fire1")) Shot();
    }

    // キャンディのプレハブからランダムに1つ選ぶ
    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        // 画面サイズとInputの割合からキャンディ生成のポジションを計算
        // Screen幅0から480だとすると、一番左下をクリックするとmousePositon.xは0になる
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        // キャンディを生成できる条件外ならShotしない
        if (candyManager.GetCandyAmount() <= 0) return;

        // プレハブからCandyオブジェクトを生成
        // Quaternion.identityとは回転なしの状態（Rotationが0, 0, 0の状態）
        GameObject candy = Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity
        );

        // 生成したCandyオブジェクトの綾をcandyParetTransformに設定する
        candy.transform.parent = candyParentTransform;

        // CandyオブジェクトのRigidbodyを取得し力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce);
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        // キャンディを消費
        candyManager.ConsumeCandy();
    }
}
