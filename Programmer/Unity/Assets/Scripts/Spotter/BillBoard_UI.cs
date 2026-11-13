using UnityEngine;
using UnityEngine.UI;

public class BillBoard_UI : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // ƒƒCƒ“ƒJƒƒ‰‚ğæ“¾
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // ƒJƒƒ‰‚Æ“¯‚¶Œü‚«‚É‰ñ“]‚³‚¹‚é
        if (mainCamera != null)
        {
            transform.rotation = mainCamera.transform.rotation;
        }
    }
}