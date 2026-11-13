using UnityEngine;
using UnityEngine.InputSystem;

public class Spotter_Vision : MonoBehaviour
{
    [Header("レイの最大射程距離")]
    public float rayDistance = 100f;
    [SerializeField] Spotter_controller spotter;
    public void ScanWeekPoint()
    {
        if (spotter.spoterstate == SpotterState.Equipment)
        {
            RaycastHit hit;

            // カメラの中央からレイを生成
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // Raycastの発射
            if (Physics.Raycast(ray, out hit, rayDistance) && hit.collider.CompareTag("WeekPoint"))
            {
                // 何かにヒットした場合
                Debug.Log("弱点発見！");
            }
            else
            {
                // 何にもヒットしなかった場合
                Debug.Log("ミス！");
            }
        }
    }
}