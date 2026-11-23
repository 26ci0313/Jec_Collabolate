using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Weak_Gauge_Contoroller weakPoint = other.GetComponent<Weak_Gauge_Contoroller>();
        BossController boss = other.GetComponentInParent<BossController>();

        if (boss != null)
        {
            boss.TakeDamage(damage, weakPoint);
            Destroy(gameObject);
        }
    }
}