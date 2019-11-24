using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next2 : MonoBehaviour
{

    public Button BG1;
    public Button BG2;
    public Button RandomBtn;
    public Button BackBtn;

    private void Start()
    {
        BG1.onClick.AddListener(() => { ToNext(1); });
        BG2.onClick.AddListener(() => { ToNext(2); });
        RandomBtn.onClick.AddListener(() => { ToNext(Random.Range(1, 3)); });
        BackBtn.onClick.AddListener(Back);
    }

    public void ToNext(int bg)
    {
        GameManager.Ins.Background = bg;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
