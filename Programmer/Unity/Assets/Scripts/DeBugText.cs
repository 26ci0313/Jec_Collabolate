using UnityEngine;
using TMPro;

public class DeBugText : MonoBehaviour
{
    // インスペクターからTextMeshProのオブジェクトを割り当てるための変数
    public PlayerClassAcces playerClass;
    public BossClassAcces bossClass;
    [SerializeField] private TMP_Text debugStatusData;
    [SerializeField] private TMP_Text debugUpDateData;
    void Start()
    {
        debugStatusData.text = "プレイヤーのHP" + playerClass.player.hp + "プレイヤーの攻撃力" + playerClass.player.atackpower + "プレイヤーの防御力" + playerClass.player.difensepower + "\n" +
             "ボスのHP" + bossClass.boss.hp + "ボスの攻撃力" + bossClass.boss.atackpower + "ボスの防御力" + bossClass.boss.difensepower;

    }

    void Update()
    {
        debugUpDateData.text = "ボスの残りHP" + bossClass.boss.hp;
    }
}
