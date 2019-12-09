using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private GameObject Button;

    public static bool IsEnd = false;
    public static bool IsExpired = false;


    private void Update()
    {
        if (IsEnd || IsExpired)
        {
            StartCoroutine(StartButton());
        }
    }

    private IEnumerator StartButton()
    {
        switch (TakeDamage.GetComponent<Damage>().ChooseWinner())
        {
            case 1:
                // TODO: Winner Player1
                break;

            case 2:
                // TODO: Winner Player2
                break;

            case 3:
                // TODO: Draw
                break;

            case 4:
                break;

            default:
                break;

        }

        yield return new WaitForSeconds(1);
        Button.SetActive(true);
    }
}
