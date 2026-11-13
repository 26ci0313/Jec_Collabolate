using UnityEngine;
using UnityEngine.InputSystem;
public enum SpotterState { Equipment, unarmed };//覗いている・覗いていないの状態管理

public class Spotter_controller : MonoBehaviour
{
    public SpotterState spoterstate = SpotterState.unarmed;
    [SerializeField] Spotter_ZoomIn_ZoomOut ZoomCamera;
    [SerializeField] Spotter_Vision vision;
    [Header("スコープ状態になるまでの前隙")]
    [SerializeField] private float beforescopeDeray = 0f;
    [Header("スコープ状態になるまでの後隙")]
    [SerializeField] private float afterscopeDeray = 0f;
    private float tmp = 0f;
    void Awake()
    {
        spoterstate = SpotterState.unarmed;
        ZoomCamera.GetComponent<Spotter_ZoomIn_ZoomOut>();
        vision.GetComponent<Spotter_Vision>();
    }

    void OnSpotter(InputValue value)
    {
        if (value.isPressed)//Spotterボタンが押された時
        {
            tmp = 0;
            spoterstate = SpotterState.Equipment;
        }
        else//Spotterボタンが離された時
        {
            tmp = 0;
            spoterstate = SpotterState.unarmed;
        }
    }
    public void OnSpotterScan(InputValue value)
    {
        if (value.isPressed)//Scanボタンが押された時
        {
            vision.ScanWeekPoint();
        }
    }
    private void Update()
    {
        if (spoterstate == SpotterState.Equipment)
        {
            if (tmp > beforescopeDeray)
            {
                ZoomCamera.ZoomIn();
            }
            tmp += Time.deltaTime;
        }
        if (spoterstate == SpotterState.unarmed)
        {
            if (tmp > afterscopeDeray)
            {
                ZoomCamera.ZoomOut();
            }
            tmp += Time.deltaTime;
        }
    }
}
