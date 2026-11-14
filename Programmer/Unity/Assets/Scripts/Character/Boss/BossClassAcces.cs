using UnityEngine;

public class BossClass
{
    public int hp = 0;
    public int atackpower = 0;
    public int difensepower = 0;

    public enum State { normal, stun, death };
    public State bossstate;
    public enum WeakState { hide, ditected };
    public WeakState weakstate;

    public float Atack(float magnification)
    {
        return atackpower * magnification;
    }
}
public class BossClassAcces : MonoBehaviour
{
    [SerializeField] CharacterStatus bossstatus;
    public BossClass boss = new BossClass();
    void Awake()
    {
        transform.localScale = new Vector3(bossstatus.scale, bossstatus.scale, bossstatus.scale);
        boss.hp = bossstatus.hp;
        boss.atackpower = bossstatus.atackpower;
        boss.difensepower = bossstatus.difensepower;
        Debug.Log("ボスのHP" + boss.hp + "ボスの攻撃力" + boss.atackpower + "ボスの防御力" + boss.difensepower);
    }
}
