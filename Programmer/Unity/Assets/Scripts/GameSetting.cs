using UnityEngine;

public class GameSetting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = false;
    }
}
