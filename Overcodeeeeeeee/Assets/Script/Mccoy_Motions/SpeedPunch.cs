using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPunch : MonoBehaviour
{
    [SerializeField] private GameObject Mccoy;
    [SerializeField] private float Speed;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private float check;
    private bool left;
    public static bool IsRush = false;

    public void Rush()
    {
        if (IsRush)
        {
            return;
        }
        IsRush = true;
        OtherPlayer = Mccoy.GetComponent<PlayerController>().OtherPlayer();
        pos = Mccoy.gameObject.transform.position;
        check = 0.0f;
        left |= OtherPlayer.gameObject.transform.position.x >= Mccoy.gameObject.transform.position.x;
    }

    private void Update()
    {
        if (IsRush)
        {
            check += Time.deltaTime;
            if (!left)
            {
                if(check >= 0.001 && check <= 0.01)
                {
                    Mccoy.GetComponent<Animator>().SetBool("Punch", true);
                }
                if (check <= 0.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x + Speed, pos.y, pos.z);
                }
                else if (check >= 0.5f && check <= 1.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x + Speed * 2.0f, pos.y, pos.z);
                }
                else if (check >= 1.5f && check < 1.7f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x + Speed * 1.5f, pos.y, pos.z);
                }
                else
                {
                    IsRush = false;
                    check = 0.0f;
                }
            }
            else if (left)
            {
                if (check >= 0.001 && check <= 0.01)
                {
                    Mccoy.GetComponent<Animator>().SetBool("Punch", true);
                }
                if (check <= 0.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x - Speed, pos.y, pos.z);
                }
                else if (check >= 0.5f && check <= 1.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x - Speed * 2.0f, pos.y, pos.z);
                }
                else if (check >= 1.5f && check < 1.7f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x - Speed * 1.5f, pos.y, pos.z);
                }
                else
                {
                    IsRush = false;
                    check = 0.0f;
                    Mccoy.GetComponent<Animator>().SetBool("Punch", false);
                }
            }
        }
    }
}
