using UnityEngine;

public class Spotter_Vision : MonoBehaviour
{
    [Header("レイの最大射程距離")]
    public float rayDistance = 100f;
    public PlayerClassAcces playerClass;
    public void Update()
    {
        // 装備中かつボスの弱点が隠れている状態のときのみ処理
        if (playerClass.player.spoterstate == PlayerClass.SpotterState.Equipment)
        {
            // カメラの中央からレイを生成
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Weak_Gauge_Contoroller wp = hit.collider.GetComponentInParent<Weak_Gauge_Contoroller>();
                if (wp != null)
                {
                    if (hit.collider.CompareTag("WeakPoint"))
                    {
                        Weak_Gauge_Contoroller targetGauge = hit.collider.GetComponent<Weak_Gauge_Contoroller>();

                        // 該当オブジェクトにコンポーネントがあれば、そのゲージだけ増やす
                        if (targetGauge != null)
                        {
                            if (targetGauge.weakstate == Weak_Gauge_Contoroller.WeakState.ditected) { return; }
                            if (targetGauge.weakstate == Weak_Gauge_Contoroller.WeakState.Destroyed) { return; }
                            targetGauge.AddAnalysis();
                        }
                    }
                }
            }
        }
    }
}