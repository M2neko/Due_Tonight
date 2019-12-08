using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;

    public int Character1Select;
    public int Character2Select;

    public int Background;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Ins = this;
    }
}
