using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("追従するキャラクター")]
    [SerializeField] private Transform playerTr;
    [Header("ターゲット設定")]
    [SerializeField] private Transform bossCenter; // ボスの中心（未発見時に狙う場所）
    [SerializeField] private List<Weak_Gauge_Contoroller> allWeakPoints = new List<Weak_Gauge_Contoroller>(); // ボスの持つすべての弱点

    [Header("攻撃設定")]
    [SerializeField] private GameObject bulletPrefab; // 発射する弾のプレハブ
    [SerializeField] private Transform firePoint;     // 弾の発射口
    [SerializeField] private float bulletSpeed = 20f;   // 弾の速度
    void Update()
    {
        transform.position = playerTr.position + new Vector3(3, 5, 3); ;

        Transform target = DetermineTarget();

        // 2. ターゲットの方向を向く
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // 水平方向に向ける場合
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    /// <summary>
    /// 狙うべきターゲットを決定するロジック（一番近い発見済み弱点を優先）
    /// </summary>
    public Transform DetermineTarget()
    {
        Transform nearestTarget = null;
        float minDistanceSqr = Mathf.Infinity; // 比較用の最短距離（初期値は無限大）

        foreach (var wp in allWeakPoints)
        {
            if (wp != null && wp.weakstate == Weak_Gauge_Contoroller.WeakState.ditected)
            {
                // タレットから弱点までの「距離の二乗」を計算
                // （平方根の計算コストを省くため、SqrMagnitudeを使うのがゲーム開発の定番です）
                float distanceSqr = (wp.transform.position - transform.position).sqrMagnitude;

                // これまでに見つかった中で一番近ければ更新する
                if (distanceSqr < minDistanceSqr)
                {
                    minDistanceSqr = distanceSqr;
                    nearestTarget = wp.transform;
                }
            }
        }

        // 発見されている弱点が1つでも見つかったら、一番近いものを返す
        if (nearestTarget != null)
        {
            return nearestTarget;
        }

        // 1つも発見されていない場合は、ボスの中心を返す
        return bossCenter;
    }

    /// <summary>
    /// 決定したターゲットに向けて弾を発射する
    /// </summary>
    public void ShootAt(Transform target)
    {
        if (target == null || bulletPrefab == null || firePoint == null) return;

        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 shootDirection = (target.position - firePoint.position).normalized;
            rb.linearVelocity = shootDirection * bulletSpeed; // ※Unity 6未満の場合は rb.velocity を使ってください
        }
    }
}