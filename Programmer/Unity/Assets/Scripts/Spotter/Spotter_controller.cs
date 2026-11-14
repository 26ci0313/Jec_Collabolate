using UnityEngine;
using UnityEngine.InputSystem;
public enum SpotterState { Equipment, unarmed };//覗いている・覗いていないの状態管理

public class Spotter_controller : MonoBehaviour
{
    public SpotterState spoterstate = SpotterState.unarmed;
    [SerializeField] Spotter_ZoomIn_ZoomOut ZoomCamera;
    [SerializeField] Spotter_Vision vision;
    [Header("スコープ状態になるまでの前隙")]
    [SerializeField] private float beforescopeDeray = 0f;
    [Header("スコープ状態になるまでの後隙")]
    [SerializeField] private float afterscopeDeray = 0f;
    private float tmp = 0f;
    private PlayerClassAcces playerClass;
    void Awake()
    {
        spoterstate = SpotterState.unarmed;
        playerClass = GetComponent<PlayerClassAcces>();
    }

    void OnSpotter(InputValue value)
    {
        // 死亡またはスタンの時は入力を一切受け付けない
        if (playerClass.player.state == PlayerClass.State.death || playerClass.player.state == PlayerClass.State.stun)
        {
            return;
        }

        if (value.isPressed)//Spotterボタンが押された時
        {
            tmp = 0;
            spoterstate = SpotterState.Equipment;
        }
        else//Spotterボタンが離された時
        {
            tmp = 0;
            spoterstate = SpotterState.unarmed;
        }
    }

    private void Update()
    {
        // 死亡またはスタンの時は強制的に解除して処理を終了する
        if (playerClass.player.state == PlayerClass.State.death || playerClass.player.state == PlayerClass.State.stun)
        {
            spoterstate = SpotterState.unarmed; // 状態もunarmedに強制リセット
            ZoomCamera.ZoomOut();
            tmp = 0; // タイマーもリセット
            return;
        }

        if (spoterstate == SpotterState.Equipment)
        {
            if (tmp > beforescopeDeray)
            {
                ZoomCamera.ZoomIn();
            }
            tmp += Time.deltaTime;
        }
        else if (spoterstate == SpotterState.unarmed) // ifからelse ifにして排他にすると安全です
        {
            if (tmp > afterscopeDeray)
            {
                ZoomCamera.ZoomOut();
            }
            tmp += Time.deltaTime;
        }
    }
}