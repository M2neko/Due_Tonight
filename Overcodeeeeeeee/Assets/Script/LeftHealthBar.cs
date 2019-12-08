using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHealthBar : MonoBehaviour
{
    private float HPRatio = 1.0f;
    private float TempRatio = 1.0f;
    private Transform Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar = this.gameObject.transform;
    }

    public void setHPRation(float CurrentHp)
    {
        this.HPRatio = CurrentHp / 100.0f;
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
