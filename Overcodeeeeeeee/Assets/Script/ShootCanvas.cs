using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCanvas: MonoBehaviour
{
    [SerializeField] private GameObject Mccoy;
    [SerializeField] private GameObject Canvas;
    private GameObject proj;
    private GameObject player;
    private float track;
    private bool left;
    private bool yesorno;
    private Vector3 pos;

    public void Shoot()
    {
        if (yesorno)
        {
            return;
        }
        pos = Mccoy.gameObject.transform.position;
        proj = Instantiate(Canvas, pos, Quaternion.identity);
        proj.SetActive(true);
        // Play audio sound
        Mccoy.GetComponent<AudioSource>().Play();
        player = Mccoy.GetComponent<PlayerController>().OtherPlayer();
        if (player.transform.position.x <= Mccoy.gameObject.transform.position.x)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        yesorno = true;
    }

    private void Update()
    {
        if (yesorno)
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
                yesorno = false;
                Destroy(proj);
            }
        }
    }
}
