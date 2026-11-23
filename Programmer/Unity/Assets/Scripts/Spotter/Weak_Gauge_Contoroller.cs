using UnityEngine;
using UnityEngine.UI;

public class Weak_Gauge_Contoroller : MonoBehaviour
{
    [SerializeField] BossClassAcces bossClass;
    [SerializeField] private Image gaugeImage;

    [Header("弱点の体力")]
    public int bossweakHP = 100;
    [Header("弱点破壊ダメージ")]
    public int weakbreakdamage = 100;
    public enum WeakState { hide, ditected, Destroyed };
    public WeakState weakstate;

    [SerializeField] private float addSpeed = 10f; // 増加量
    public float weakhidetime = 0;

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
        WeakDestroy();

        WeakManegement();
    }
    public void DamageWeak(int Damage)
    {
        bossweakHP -= Damage;
    }
    private void WeakDestroy()
    {
        if (bossweakHP <= 0)
        {
            if (weakstate != WeakState.Destroyed)
            {
                bossweakHP = 0;
                bossClass.boss.hp -= weakbreakdamage;
                weakstate = WeakState.Destroyed;
            }
        }
    }
    private void WeakManegement()
    {
        if (gaugeImage != null && currentValue >= maxValue)
        {
            weakstate = WeakState.ditected;
            currentValue = 0f; // 成功時のリセット値
            UpdateGaugeUI();
        }
        if (weakstate == WeakState.ditected)
        {
            float hidetime = 3;
            weakhidetime += Time.deltaTime;
            if (weakhidetime > hidetime)
            {
                weakstate = WeakState.hide;
            }
        }
        else
        {
            weakhidetime = 0;
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