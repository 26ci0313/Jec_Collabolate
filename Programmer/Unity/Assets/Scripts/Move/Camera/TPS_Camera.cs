using UnityEngine;

public class TPS_Camera : MonoBehaviour
{
    public Transform player;//追従するプレイヤー
    public Transform center;//円の中心

    public float distance = 8f;//カメラとプレイヤーの距離
    public float height = 5f;//カメラの高さ

    [SerializeField] Spotter_controller spotter;
    void LateUpdate()
    {
        if (spotter.spoterstate == SpotterState.unarmed)
        {
            //カメラを中心に向ける
            Vector3 centerdirection = center.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(centerdirection);
            float speed = 5.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
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

        //------カメラの回転------

        // マウスの移動量を取得
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // X方向に一定量移動していれば横回転
        if (Mathf.Abs(mx) > 0.01f)
        {
            // 回転軸はワールド座標のY軸
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

        // Y方向に一定量移動していれば縦回転
        if (Mathf.Abs(my) > 0.01f)
        {
            // 回転軸はカメラ自身のX軸
            transform.RotateAround(player.transform.position, transform.right, -my);
        }
    }
}
