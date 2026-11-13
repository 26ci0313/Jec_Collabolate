using UnityEngine;
using UnityEngine.UI;

public class Weak_Gauge_Contoroller : MonoBehaviour
{
    [SerializeField] private Image gaugeImage;

    [SerializeField] private float addSpeed = 10f; // 増加量

    private float currentValue = 0f;
    private const float maxValue = 100f;          // 最大値

    public void AddAnalysis()
    {
        currentValue += Time.deltaTime * addSpeed;
        currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
        UpdateGaugeUI();
    }

    void Start()
    {
        currentValue = 0f;
        UpdateGaugeUI();
    }

    private void Update()
    {
        if (gaugeImage != null && currentValue >= maxValue)
        {
            Debug.Log("弱点解析成功");
            currentValue = 20f; // 成功時のリセット値など
            UpdateGaugeUI();
        }
    }

    // 外から値を直接設定する場合（0〜100の範囲）
    public void UpdateHp(float value)
    {
        currentValue = Mathf.Clamp(value, 0f, maxValue);
        UpdateGaugeUI();
    }

    // ゲージの見た目（fillAmount）を更新するメソッド
    private void UpdateGaugeUI()
    {
        if (gaugeImage != null)
        {
            // Image.fillAmount は 0.0 ～ 1.0 の割合で指定するため、100分率に変換
            gaugeImage.fillAmount = currentValue / maxValue;
        }
    }
}