using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject Player1Winner;
    [SerializeField] private GameObject Player2Winner;
    [SerializeField] private GameObject Player3Winner;
    [SerializeField] private GameObject Player4Winner;

    [SerializeField] private GameObject Character1_1;
    [SerializeField] private GameObject Character1_2;
    [SerializeField] private GameObject Character2_1;
    [SerializeField] private GameObject Character2_2;

    [SerializeField] private GameObject KO;
    [SerializeField] private GameObject Draw;

    [SerializeField] private GameObject Left_die;
    [SerializeField] private GameObject Right_die;

    [SerializeField] private GameObject submit;
    [SerializeField] private GameObject extension;

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
                KO.SetActive(true);
                Right_die.SetActive(true);
                submit.SetActive(true);
                this.GetComponents<AudioSource>()[0].Play();
                yield return new WaitForSeconds(2);
                if (Character1_1.activeInHierarchy)
                    Player1Winner.SetActive(true);
                if (Character1_2.activeInHierarchy)
                    Player2Winner.SetActive(true);
                KO.SetActive(false);
                Right_die.SetActive(false);
                submit.SetActive(false);
                break;

            case 2:
                // A Win, B Alive
                yield return new WaitForSeconds(0.5f);
                this.GetComponents<AudioSource>()[2].Play();
                yield return new WaitForSeconds(1.5f);
                if (Character1_1.activeInHierarchy)
                    Player1Winner.SetActive(true);
                if (Character1_2.activeInHierarchy)
                    Player2Winner.SetActive(true);
                break;

            case 3:
                // B Win, A Dead
                KO.SetActive(true);
                Left_die.SetActive(true);
                extension.SetActive(true);
                this.GetComponents<AudioSource>()[0].Play();
                yield return new WaitForSeconds(2);
                if (Character2_1.activeInHierarchy)
                    Player3Winner.SetActive(true);
                if (Character2_2.activeInHierarchy)
                    Player4Winner.SetActive(true);
                KO.SetActive(false);
                Left_die.SetActive(false);
                extension.SetActive(false);
                break;

            case 4:
                // B Win, A Alive
                yield return new WaitForSeconds(0.5f);
                this.GetComponents<AudioSource>()[2].Play();
                yield return new WaitForSeconds(1.5f);
                if (Character2_1.activeInHierarchy)
                    Player3Winner.SetActive(true);
                if (Character2_2.activeInHierarchy)
                    Player4Winner.SetActive(true);
                break;

            case 5:
                // Draw
                Draw.SetActive(true);
                this.GetComponents<AudioSource>()[1].Play();
                yield return new WaitForSeconds(2);
                Draw.SetActive(false);
                break;
        }
        yield return new WaitForSeconds(1.5f);
        Button.SetActive(true);
    }
}
