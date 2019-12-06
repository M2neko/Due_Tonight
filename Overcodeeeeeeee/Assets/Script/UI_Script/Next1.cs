using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Next1 : MonoBehaviour
{
    public Button Character1_1Btn;
    public Button Character1_2Btn;
    public Button Character2_1Btn;
    public Button Character2_2Btn;

    public Button GoBtn;
    public Button BackBtn;


    private int Character1Select
    {
        get { return GameManager.Ins.Character1Select; }
        set { GameManager.Ins.Character1Select = value; }
    }
    private int Character2Select
    {
        get { return GameManager.Ins.Character2Select; }
        set { GameManager.Ins.Character2Select = value; }
    }

    private void Start()
    {
        GoBtn.gameObject.SetActive(false);
        Character1_1Btn.onClick.AddListener(Character1_1Click);
        Character1_2Btn.onClick.AddListener(Character1_2Click);
        Character2_1Btn.onClick.AddListener(Character2_1Click);
        Character2_2Btn.onClick.AddListener(Character2_2Click);
        GoBtn.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        BackBtn.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    private void CheckIsNext()
    {
        if (Character1Select != 0 && Character2Select != 0)
        {
            GoBtn.gameObject.SetActive(true);
        }
    }

    private void Character1_1Click()
    {
        Character1Select = 1;
        Character1_1Btn.transform.GetComponent<Image>().color = Color.yellow;
        CheckIsNext();
    }

    private void Character1_2Click()
    {
        Character1Select = 2;
        Character1_2Btn.transform.GetComponent<Image>().color = Color.yellow;
        Character1_2Btn.GetComponent<AudioSource>().Play();
        CheckIsNext();
    }

    private void Character2_1Click()
    {
        Character2Select = 1;
        Character2_1Btn.transform.GetComponent<Image>().color = Color.yellow;
        Character2_1Btn.GetComponent<AudioSource>().Play();
        CheckIsNext();
    }

    private void Character2_2Click()
    {
        Character2Select = 2;
        Character2_2Btn.transform.GetComponent<Image>().color = Color.yellow;
        CheckIsNext();
    }
}
