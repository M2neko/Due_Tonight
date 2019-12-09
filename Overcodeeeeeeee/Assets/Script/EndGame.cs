using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private GameObject Button;

    public static bool IsEnd = false;


    private void Update()
    {
        if (IsEnd)
        {
            StartCoroutine(StartButton());
            IsEnd = false;
        }

        if (Game.isFinish)
        {
            StartCoroutine(StartButton());
            Game.isFinish = false;
        }
    }

    private IEnumerator StartButton()
    {
        if (TakeDamage.GetComponent<Damage>().ChooseWinner())
        {
            // TODO: Winner Player1
        }
        else
        {
            // TODO: Winner Player2
        }

        yield return new WaitForSeconds(1);
        Button.SetActive(true);
    }
}
