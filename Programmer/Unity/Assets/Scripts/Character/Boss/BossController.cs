using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("ボスクラス")]
    public BossClassAcces bossClass;
    [Header("プレイヤー")]
    public PlayerClassAcces playerClass;

    [Header("弱点リスト")]
    [SerializeField] private List<Weak_Gauge_Contoroller> weakPoints = new List<Weak_Gauge_Contoroller>();
    public void TakeDamage(float baseDamage, Weak_Gauge_Contoroller hitWeakPoint = null)
    {
        //通常の処理
        float finalDamage = playerClass.player.Atack(baseDamage / bossClass.boss.difensepower);

        // 特定の弱点にヒットした場合の処理
        if (hitWeakPoint != null && weakPoints.Contains(hitWeakPoint))
        {
            // 「その弱点がすでに発見されている場合のみ」ダメージアップを適用する
            if (hitWeakPoint.weakstate == Weak_Gauge_Contoroller.WeakState.ditected)
            {
                finalDamage = playerClass.player.Atack(baseDamage);
                hitWeakPoint.DamageWeak((int)playerClass.player.Atack(baseDamage));
            }
        }
        bossClass.boss.hp -= (int)finalDamage;
    }
}