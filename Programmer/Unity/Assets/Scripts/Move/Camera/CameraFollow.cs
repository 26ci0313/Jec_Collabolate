using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;//追従するプレイヤー
    public Transform center;//円の中心

    public float distance = 8f;//カメラとプレイヤーの距離
    public float height = 5f;//カメラの高さ
    void LateUpdate()
    {
        //円の中心からプレイヤーに向かう方向を求める
        Vector3 direction = player.position - center.position;
        //高さの差を無視して、地面上の方向だけ使う
        direction.y = 0f;

        //方向を単位ベクトルにする
        direction.Normalize();

        //プレイヤーの外側にカメラを配置する
        transform.position = player.position
                           + direction * distance
                           + Vector3.up * height;
    }
}
