using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;//追従するプレイヤー
    public Transform center;//円の中心

    public float distance = 8f;//カメラとプレイヤーの距離
    public float height = 5f;//カメラの高さ

    public float zoomFOV = 35f;//ズーム時の視野角
    public float zoomSpeed = 5f;//ズームの速度

    private Camera cam;//カメラの情報
    private float normalFOV;//通常時の視野角

    void Start()
    {
        //Main CameraのCameraコンポーネントを取得
        cam=GetComponent<Camera>();

        //最初の視野角を保存
        normalFOV = cam.fieldOfView;
    }

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

        //カメラを中心に向ける
        transform.LookAt(center.position);

        //Zキーが押されたら
        if(Input.GetKey(KeyCode.Z))
        {
            //ズームインする
            cam.fieldOfView = Mathf.Lerp(
                cam.fieldOfView,
                zoomFOV,
                Time.deltaTime * zoomSpeed
            );
        }
        else
        {
            //通常の視野角に戻す
            cam.fieldOfView = Mathf.Lerp(
                cam.fieldOfView,
                normalFOV,
                Time.deltaTime * zoomSpeed
            );
        }
    }
}
