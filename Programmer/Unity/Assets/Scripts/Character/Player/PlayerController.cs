using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform center; // 円の中心
    public float radius = 5f; // 円の外縁までの距離
    public float speed = 2f; // 円周を移動する速度
    private float angle; // 円周上の現在位置

    public PlayerClassAcces playerClass;
    void Start()
    {
        // プレイヤーと円の中心との位置の差を求める
        Vector3 offset = transform.position - center.position;
        // プレイヤーの初期位置から、円周上の角度を求める
        angle = Mathf.Atan2(offset.z, offset.x);
        playerClass = GetComponent<PlayerClassAcces>();
    }

    void Update()
    {
        if (playerClass.player.state == PlayerClass.State.death || playerClass.player.state == PlayerClass.State.stun)
        {
            return;
        }
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            playerClass.player.state = PlayerClass.State.death;
            return;
        }
        //移動処理&方向処理---------------------------------------------------------------

        // 左右キーの入力取得
        float input = Input.GetAxisRaw("Horizontal");
        // 入力方向に応じて角度を変化させる
        angle += speed * input * Time.deltaTime;

        // 角度からX座標を計算
        float x = Mathf.Cos(angle) * radius;
        // 角度からZ座標を計算
        float z = Mathf.Sin(angle) * radius;

        // プレイヤーの位置を円周上の座標に更新する
        transform.position = new Vector3(
            center.position.x + x, // 円の中心のX座標に計算したX座標を加える
            transform.position.y,  // Y座標はそのまま維持
            center.position.z + z  // 円の中心のZ座標に計算したZ座標を加える
        );

        // --- 1. 常に円の中心を向くベースの回転を計算 ---
        Vector3 directionToCenter = center.position - transform.position;
        directionToCenter.y = 0f; // 高低差を無視して水平面で計算

        if (directionToCenter != Vector3.zero)
        {
            // 中心を向く標準の回転（基準）
            Quaternion baseRotation = Quaternion.LookRotation(directionToCenter);

            // --- 2. 入力に応じて向き（オフセット）を変更 ---
            float yawOffset = 0f;

            if (input == 0)
            {
                playerClass.player.direction = PlayerClass.Direction.center;
                playerClass.player.state = PlayerClass.State.normal;
                yawOffset = 0f; // 中心を真っ直ぐ向く
            }
            else if (input > 0)
            {
                playerClass.player.direction = PlayerClass.Direction.right;
                playerClass.player.state = PlayerClass.State.wark;
                yawOffset = 90f; // 中心方向を基準に右へ90度傾ける
            }
            else // input < 0
            {
                playerClass.player.direction = PlayerClass.Direction.left;
                playerClass.player.state = PlayerClass.State.wark;
                yawOffset = -90f; // 中心方向を基準に左へ90度傾ける
            }

            // 基準の回転（中心方向）に、入力によるオフセット回転を掛け合わせて合成する
            transform.rotation = baseRotation * Quaternion.Euler(0f, yawOffset, 0f);
        }
        //-------------------------------------------------------------------------------------------------
    }
}