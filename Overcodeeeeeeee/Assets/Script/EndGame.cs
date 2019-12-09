using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject Button;

    public static bool IsEnd;


    private void Update()
    {
        if (IsEnd)
            Button.SetActive(true);
    }
}
