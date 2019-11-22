using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next1 : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Next2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void RandomBG()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
               break;
            case 2:
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
               break;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
