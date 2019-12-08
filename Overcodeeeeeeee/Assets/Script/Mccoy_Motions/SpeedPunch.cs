using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPunch : MonoBehaviour
{
    [SerializeField] private GameObject Mccoy;
    [SerializeField] private float Speed;
    [SerializeField] private float RushSpeed;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private float check;
    private bool left;
    private bool punch = false;
    private bool IsMusic = false;
    public static bool IsPunch = false;

    public void Punch()
    {
        if (IsPunch)
        {
            return;
        }
        punch = false;
        IsPunch = true;
        IsMusic = false;
        OtherPlayer = Mccoy.GetComponent<PlayerController>().OtherPlayer();
        pos = Mccoy.gameObject.transform.position;
        check = 0.0f;
        left |= OtherPlayer.gameObject.transform.position.x <= Mccoy.gameObject.transform.position.x;
        Mccoy.gameObject.GetComponent<Animator>().SetBool("Punch", true);
        this.GetComponents<AudioSource>()[1].Play();
    }

    private void Update()
    {
        if (IsPunch)
        {
            check += Time.deltaTime;
            if (!left)
            {
                if (check <= 0.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x + Speed * 0.5f, pos.y, pos.z);
                }
                else if (check > 0.5f && !punch)
                {
                    punch = true;
                    Mccoy.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * RushSpeed);
                }
                else if (check >= 1.2f && check < 1.7f && !IsMusic)
                {
                    this.GetComponents<AudioSource>()[2].Play();
                    IsMusic = true;
                }
                else if (check >= 1.7f)
                {
                    IsPunch = false;
                    check = 0.0f;
                    Mccoy.GetComponent<Animator>().SetBool("Punch", false);
                }
            }
            else if (left)
            {
                if (check <= 0.5f)
                {
                    Mccoy.gameObject.transform.position = new Vector3(pos.x - Speed * 0.5f, pos.y, pos.z);
                }
                else if (check > 0.5f && !punch)
                {
                    punch = true;
                    Mccoy.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * RushSpeed);
                }
                else if (check >= 1.2f && check < 1.7f && !IsMusic)
                {
                    this.GetComponents<AudioSource>()[2].Play();
                    IsMusic = true;
                }
                else if (check >= 1.7f)
                {
                    punch = false;
                    IsPunch = false;
                    check = 0.0f;
                    Mccoy.GetComponent<Animator>().SetBool("Punch", false);
                }
            }
        }
    }
}
