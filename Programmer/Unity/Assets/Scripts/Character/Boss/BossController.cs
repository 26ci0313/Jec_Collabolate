using UnityEngine;
using UnityEngine.InputSystem;

public class BossController : MonoBehaviour
{
    [SerializeField] PlayerClassAcces playerClass;
    [SerializeField] BossClassAcces bossClass;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            if (bossClass.boss.weakstate == BossClass.WeakState.hide)//弱点が隠れているとき耐性で攻撃を軽減する
            {
                bossClass.boss.hp -= ((int)playerClass.player.Atack(5) / bossClass.boss.difensepower);
                Debug.Log("ボスの残りHP" + bossClass.boss.hp);
            }
            else//弱点が露出していると耐性なしで攻撃を通す
            {
                bossClass.boss.hp -= ((int)playerClass.player.Atack(5));
                Debug.Log("ボスの残りHP" + bossClass.boss.hp);
            }

        }
    }
}
