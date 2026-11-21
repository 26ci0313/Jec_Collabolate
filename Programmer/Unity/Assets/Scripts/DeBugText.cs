using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DebugText : MonoBehaviour
{
    // インスペクターからTextMeshProのオブジェクトを割り当てるための変数
    public PlayerClassAcces playerClass;
    public BossClassAcces bossClass;
    public Weak_Gauge_Contoroller weak;
    [SerializeField] private TMP_Text debugText;
    [SerializeField] private GameObject textbox;
    int defaultPlayerHP;
    int defaultPlayerAtk;
    int defaultPlayerDef;
    int defaultBossHP;
    int defaultBossAtk;
    int defaulBossDef;

    void Start()
    {
        defaultPlayerHP = playerClass.player.hp;
        defaultPlayerAtk = playerClass.player.atackpower;
        defaultPlayerDef = playerClass.player.difensepower;
        defaultBossHP = bossClass.boss.hp;
        defaultBossAtk = bossClass.boss.atackpower;
        defaulBossDef = bossClass.boss.difensepower;
        textbox.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            bool isActive = textbox.activeSelf;
            textbox.SetActive(!isActive);
        }
        debugText.text =
            "キャラクターステータス\n" + "プレイヤーのHP:" + defaultPlayerHP + "プレイヤーの攻撃力:" + defaultPlayerAtk + "プレイヤーの防御力:" + defaultPlayerDef + "\n" +
             "ボスのHP:" + defaultBossHP + "ボスの攻撃力:" + defaultBossAtk + "ボスの防御力:" + defaulBossDef + "\n" + "\n" +
             "プレイヤーの状態:" + playerClass.player.state + "\n" + "プレイヤーの速度:" + playerClass.player.speed + "\n" + "攻撃しているか:" + playerClass.player.attackState + "\n" +
             "スポッターの状態:" + playerClass.player.spoterstate + "\n" + "\n" +
             "ボスの状態:" + bossClass.boss.state + "\n" + "ボスの残りHP:" + bossClass.boss.hp + "\n" + "弱点が戻るまで:" + (3 - weak.weakhidetime) + "\n" + "ボスの弱点:" + bossClass.boss.weakstate;
    }
}
