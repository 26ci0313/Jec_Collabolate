using UnityEngine;

public class PlayerClass
{
    public int hp = 0;
    public int atackpower = 0;
    public int difensepower = 0;

    public enum Direction { left, center, right };
    public Direction direction;
    public enum State { normal, wark, stun, death };
    public State state;
    public float Atack(float magnification)
    {
        return atackpower * magnification;
    }
}
public class PlayerClassAcces : MonoBehaviour
{
    [SerializeField] CharacterStatus playerstatus;
    public PlayerClass player = new PlayerClass();
    void Awake()
    {
        transform.localScale = new Vector3(playerstatus.scale, playerstatus.scale, playerstatus.scale);
        player.hp = playerstatus.hp;
        player.atackpower = playerstatus.atackpower;
        player.difensepower = playerstatus.difensepower;
        Debug.Log("プレイヤーのHP" + player.hp + "プレイヤーの攻撃力" + player.atackpower + "プレイヤーの防御力" + player.difensepower);
    }
}
