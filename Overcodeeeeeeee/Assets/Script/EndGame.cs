using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject Player1Winner;
    [SerializeField] private GameObject Player2Winner;

    public static bool IsEnd = false;
    public static bool IsExpired = false;
    public static bool IsFinish = false;


    private void Update()
    {
        if ((IsEnd || IsExpired) && !IsFinish)
        {
            StartCoroutine(StartButton());
            IsFinish = true;
        }
    }

    private IEnumerator StartButton()
    {
        yield return new WaitForSeconds(0.5f);
        switch (TakeDamage.GetComponent<Damage>().ChooseWinner())
        {
            case 1:
                // A Win, B Dead
                this.GetComponents<AudioSource>()[0].Play();
                yield return new WaitForSeconds(1);
                Player1Winner.SetActive(true);
                break;

            case 2:
                // A Win, B Alive
                yield return new WaitForSeconds(0.5f);
                //this.GetComponents<AudioSource>()[2].Play();
                yield return new WaitForSeconds(0.5f);
                Player1Winner.SetActive(true);
                break;

            case 3:
                // B Win, A Dead
                this.GetComponents<AudioSource>()[0].Play();
                yield return new WaitForSeconds(1);
                Player2Winner.SetActive(true);
                break;

            case 4:
                // B Win, A Alive
                yield return new WaitForSeconds(0.5f);
                //this.GetComponents<AudioSource>()[2].Play();
                yield return new WaitForSeconds(0.5f);
                Player2Winner.SetActive(true);
                break;

            case 5:
                // Draw
                this.GetComponents<AudioSource>()[1].Play();
                yield return new WaitForSeconds(1);
                break;
        }
        yield return new WaitForSeconds(1.5f);
        Button.SetActive(true);
    }
}
