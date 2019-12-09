using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHealthBar : MonoBehaviour
{
    [SerializeField] private float MaximumHp = 100.0f;
    private float HPRatio = 1.0f;
    private float TempRatio = 1.0f;
    private float CurrentHp;
    private Transform Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar = this.gameObject.transform;
        CurrentHp = MaximumHp;
    }

    public void TakeDamage(float Damage)
    {
        this.CurrentHp = Damage > this.CurrentHp ? 0.0f : this.CurrentHp - Damage;
        SetHpRatio();
    }

    private void SetHpRatio()
    {
        this.HPRatio = this.CurrentHp / 100.0f;
    }

    public bool IsDead()
    {
        return CurrentHp <= 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TempRatio > HPRatio)
        {
            TempRatio -= 0.01f;
        }
        Healthbar.localScale = new Vector3(TempRatio, 1.0f);
    }
}
