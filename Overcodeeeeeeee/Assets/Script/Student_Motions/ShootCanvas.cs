using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCanvas : MonoBehaviour
{
    [SerializeField] private GameObject Student;
    [SerializeField] private GameObject Canvas;
    private GameObject[] proj;
    private GameObject player;
    private float track;
    private bool left;
    public static bool IsShoot;
    private Vector3[] pos;
    private bool[] IsFinish;

    public void Shoot()
    {
        if (IsShoot)
        {
            return;
        }
        proj = new GameObject[3];
        IsFinish = new bool[3];
        pos = new Vector3[3];

        Student.GetComponent<Animator>().SetBool("Shoot", true);

        IsFinish[0] = false;
        IsFinish[1] = false;
        IsFinish[2] = false;
        StartCoroutine(Shoot1());
        StartCoroutine(Shoot2());
        StartCoroutine(Shoot3());
        // Play audio sound
        Student.GetComponents<AudioSource>()[0].Play();
        player = Student.GetComponent<Player2Controller>().OtherPlayer();
        if (player.transform.position.x <= Student.gameObject.transform.position.x)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        IsShoot = true;
    }

    private IEnumerator Shoot1()
    {
        yield return new WaitForSeconds(0.3f);
        pos[0] = Student.gameObject.transform.position;
        proj[0] = Instantiate(Canvas, pos[0], Quaternion.identity);
        proj[0].SetActive(true);
        IsFinish[0] = true;
    }

    private IEnumerator Shoot2()
    {
        yield return new WaitForSeconds(0.8f);
        pos[1] = Student.gameObject.transform.position;
        proj[1] = Instantiate(Canvas, pos[1], Quaternion.identity);
        proj[1].SetActive(true);
        IsFinish[1] = true;
    }

    private IEnumerator Shoot3()
    {
        yield return new WaitForSeconds(1.3f);
        pos[2] = Student.gameObject.transform.position;
        proj[2] = Instantiate(Canvas, pos[2], Quaternion.identity);
        proj[2].SetActive(true);
        IsFinish[2] = true;
    }

    private void Update()
    {
        if (IsShoot)
        {
            track += Time.deltaTime * 5;

            if (track >= 5.0f)
            {
                //Mccoy.GetComponent<Animator>().SetBool("1", false);
            }

            if (IsFinish[0])
            {
                if (track <= 10.0f)
                {
                    if (left)
                    {
                        proj[0].gameObject.transform.position = new Vector3(pos[0].x - track, pos[0].y, pos[0].z);
                    }
                    else
                    {
                        proj[0].gameObject.transform.position = new Vector3(pos[0].x + track, pos[0].y, pos[0].z);
                    }
                }
                else
                {
                    //track = 0.0f;
                    proj[0].SetActive(false);
                    IsFinish[0] = false;
                    //IsShoot = false;
                }
            }

            if (IsFinish[1])
            {
                if (track <= 12.5f)
                {
                    if (left)
                    {
                        proj[1].gameObject.transform.position = new Vector3(pos[1].x - track + 3.0f, pos[1].y, pos[1].z);
                    }
                    else
                    {
                        proj[1].gameObject.transform.position = new Vector3(pos[1].x + track - 3.0f, pos[1].y, pos[1].z);
                    }
                }
                else
                {
                    //track = 0.0f;
                    proj[1].SetActive(false);
                    IsFinish[1] = false;
                    //IsShoot = false;
                }
            }

            if (IsFinish[2])
            {
                if (track <= 15.0f)
                {
                    if (left)
                    {
                        proj[2].gameObject.transform.position = new Vector3(pos[2].x - track + 2 * 3.0f, pos[2].y, pos[2].z);
                    }
                    else
                    {
                        proj[2].gameObject.transform.position = new Vector3(pos[2].x + track - 2 * 3.0f, pos[2].y, pos[2].z);
                    }
                }
                else
                {
                    track = 0.0f;
                    proj[2].SetActive(false);
                    Student.GetComponent<Animator>().SetBool("Shoot", false);
                    IsFinish[2] = false;
                    IsShoot = false;
                    Destroy(proj[0]);
                    Destroy(proj[1]);
                    Destroy(proj[2]);
                }
            }

        }
    }
}
