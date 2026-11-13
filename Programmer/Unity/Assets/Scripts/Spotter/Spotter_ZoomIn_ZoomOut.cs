using UnityEngine;
using UnityEngine.UI;

public class Spotter_ZoomIn_ZoomOut : MonoBehaviour
{
    public float zoomFOV = 35f;//ズーム時の視野角
    public float zoomSpeed = 5f;//ズームの速度

    private Camera cam;//カメラの情報
    private float normalFOV;//通常時の視野角
    [Header("スコープの画像")]
    public GameObject Image;
    private void Awake()
    {
        Image.SetActive(false);
        //Main CameraのCameraコンポーネントを取得
        cam = GetComponent<Camera>();

        //最初の視野角を保存
        normalFOV = cam.fieldOfView;
    }
    public void ZoomIn()
    {
        //ズームインする
        Image.SetActive(true);
        cam.fieldOfView = Mathf.Lerp(
            cam.fieldOfView,
            zoomFOV,
            Time.deltaTime * zoomSpeed
        );
    }
    public void ZoomOut()
    {
        Image.SetActive(false);
        //通常の視野角に戻す
        cam.fieldOfView = Mathf.Lerp(
            cam.fieldOfView,
            normalFOV,
            Time.deltaTime * zoomSpeed
        );
    }

}
