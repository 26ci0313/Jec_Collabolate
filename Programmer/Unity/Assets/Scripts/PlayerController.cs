using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform center;//円の中心
    public float radius = 5f;//円の外縁までの距離
    public float speed = 2f;//円周を移動する速度

    private float angle;//円周上の現在位置
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        //プレイヤーと円の中心との位置の差を求める
        Vector3 offset = transform.position - center.position;
        //プレイヤーの初期位置から、円周上の角度を求める
        angle = Mathf.Atan2(offset.z, offset.x);
    }

    // Update is called once per frame
    void Update()
    {
        //左右キーの入力取得
        float input = Input.GetAxisRaw("Horizontal");
        //入力方向に応じて角度を変化させる
        angle += speed * input * Time.deltaTime;
        //角度からX座標を計算
        float x = Mathf.Cos(angle) * radius;
        //角度からZ座標を計算
        float z = Mathf.Sin(angle) * radius;
        //プレイヤーの位置を円周上の座標に更新する
        transform.position = new Vector3(
            center.position.x + x,//円の中心のX座標に計算したX座標を加える
            transform.position.y,//Y座標はそのまま維持
            center.position.z + z//円の中心のZ座標に計算したZ座標を加える
        );
    }
}
