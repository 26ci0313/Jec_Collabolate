using UnityEngine;
using UnityEngine.InputSystem;

public class Spotter_Vision : MonoBehaviour
{
    [Header("レイの最大射程距離")]
    public float rayDistance = 100f;
    [SerializeField] Spotter_controller spotter;

    public void Update()
    {
        // 装備中（またはスキャン中）の状態のときのみ処理
        if (spotter.spoterstate == SpotterState.Equipment)
        {
            // カメラの中央からレイを生成
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            // Raycastを発射し、何かに当たったか確認
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // ヒットしたオブジェクトのタグが "WeakPoint" かつ、Weak_Gauge_Contorollerがついているか
                if (hit.collider.CompareTag("WeakPoint"))
                {
                    Weak_Gauge_Contoroller targetGauge = hit.collider.GetComponent<Weak_Gauge_Contoroller>();

                    // 該当オブジェクトにコンポーネントがあれば、そのゲージだけ増やす
                    if (targetGauge != null)
                    {
                        targetGauge.AddAnalysis();
                    }
                }
            }
        }
    }
}