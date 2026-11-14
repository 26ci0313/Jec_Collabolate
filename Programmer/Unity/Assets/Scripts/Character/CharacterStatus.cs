using UnityEngine;

[CreateAssetMenu(menuName = "NewCharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    public float scale = 1f;
    public int hp = 0;
    public int atackpower = 0;
    public int difensepower = 0;
}
