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
            StartCoroutine(StartButton());
    }

    private IEnumerator StartButton()
    {
        yield return new WaitForSeconds(1);
        Button.SetActive(true);
    }
}
