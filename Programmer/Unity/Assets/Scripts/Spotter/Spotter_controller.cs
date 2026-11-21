using UnityEngine;
using UnityEngine.InputSystem;

public class Spotter_controller : MonoBehaviour
{
    [SerializeField] Spotter_ZoomIn_ZoomOut ZoomCamera;
    [SerializeField] Spotter_Vision vision;
    [SerializeField] PlayerClassAcces playerClass;
    [SerializeField] PlayerController playerController;
    [Header("スコープ状態になるまでの前隙")]
    [SerializeField] private float beforescopeDeray = 0f;
    [Header("スコープ状態になるまでの後隙")]
    [SerializeField] private float afterscopeDeray = 0f;
    private float tmp = 0f;
    void Awake()
    {
        playerClass.player.spoterstate = PlayerClass.SpotterState.unarmed;
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
            playerController.playerClass.player.speed = playerController.defaultwarkspeed / 2;
            playerClass.player.spoterstate = PlayerClass.SpotterState.Equipment;
        }
        else//Spotterボタンが離された時
        {
            tmp = 0;
            playerController.playerClass.player.speed = playerController.defaultwarkspeed;
            playerClass.player.spoterstate = PlayerClass.SpotterState.unarmed;
        }
    }

    private void Update()
    {
        // 死亡またはスタンの時は強制的に解除して処理を終了する
        if (playerClass.player.state == PlayerClass.State.death || playerClass.player.state == PlayerClass.State.stun)
        {
            playerClass.player.spoterstate = PlayerClass.SpotterState.unarmed; // 状態もunarmedに強制リセット
            ZoomCamera.ZoomOut();
            tmp = 0; // タイマーもリセット
            return;
        }

        if (playerClass.player.spoterstate == PlayerClass.SpotterState.Equipment)
        {
            if (tmp > beforescopeDeray)
            {
                ZoomCamera.ZoomIn();
            }
            tmp += Time.deltaTime;
        }
        else if (playerClass.player.spoterstate == PlayerClass.SpotterState.unarmed) // ifからelse ifにして排他にすると安全です
        {
            if (tmp > afterscopeDeray)
            {
                ZoomCamera.ZoomOut();
            }
            tmp += Time.deltaTime;
        }
    }
}