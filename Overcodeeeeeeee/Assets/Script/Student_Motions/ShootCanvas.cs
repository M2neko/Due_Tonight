using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCanvas: MonoBehaviour
{
    [SerializeField] private GameObject Student;
    [SerializeField] private GameObject Canvas;
    private GameObject proj;
    private GameObject player;
    private float track;
    private bool left;
    public static bool IsShoot;
    private Vector3 pos;

    public void Shoot()
    {
        if (IsShoot)
        {
            return;
        }
        pos = Student.gameObject.transform.position;
        proj = Instantiate(Canvas, pos, Quaternion.identity);
        proj.SetActive(true);
        // Play audio sound
        //Student.GetComponents<AudioSource>()[0].Play();
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

    private void Update()
    {
        if (IsShoot)
        {
            track += Time.deltaTime * 5;
            if(track >= 5.0f)
            {
                //Mccoy.GetComponent<Animator>().SetBool("1", false);
            } 
            if (track <= 10.0f)
            {
                if (left)
                {
                    proj.gameObject.transform.position = new Vector3(pos.x - track, pos.y, pos.z);
                }
                else
                {
                    proj.gameObject.transform.position = new Vector3(pos.x + track, pos.y, pos.z);
                }
            }
            else
            {
                track = 0.0f;
                proj.SetActive(false);
                IsShoot = false;
                Destroy(proj);
            }
        }
    }
}
