using UnityEngine;
using UnityEngine.InputSystem;

public class BossController : MonoBehaviour
{
    [SerializeField] PlayerClassAcces playerClass;
    [SerializeField] BossClassAcces bossClass;

    // Update is called once per frame
    void Update()
    {
        if (bossClass.boss.hp < 0)
        {
            bossClass.boss.hp = 0;
            bossClass.boss.state = BossClass.State.death;
        }
    }
}
