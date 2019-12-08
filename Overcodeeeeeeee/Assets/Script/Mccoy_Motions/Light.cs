using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Light : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] GameObject proj;
    [SerializeField] private float range; //0.4f
    private GameObject otherplayer;
    private Vector3 location;
    public static bool IsLight = false;
    private bool spawn = false;
    private float track = 0.0f;
    private float timer = 0.0f;

    public void Pi(GameObject player)
    {
        if (IsLight)
        {
            return;
        }
        this.GetComponent<Animator>().SetBool("2", true);
        this.GetComponents<AudioSource>()[1].Play();
        otherplayer = player;
        location = new Vector3(player.gameObject.transform.position.x, 0.5f, player.gameObject.transform.position.z);
        IsLight = true;

    }

    private void Update()
    {
        if (IsLight)
        {
            track += Time.deltaTime;
            if (track >= delay && track <= delay + range && !spawn)
            {
                proj.SetActive(true);
                proj.gameObject.transform.position = location;
                proj.gameObject.transform.localScale = new Vector3(2.0f, 5.5f, 1.0f);
                spawn = true;
            }
            else if (track >= delay && track <= delay + range)
            {
                if (proj.GetComponent<SpriteRenderer>().flipX == true)
                {
                    timer += Time.deltaTime;
                    proj.GetComponent<SpriteRenderer>().flipX = false;
                    proj.GetComponent<SpriteRenderer>().flipY = false;
                }
                else
                {
                    proj.GetComponent<SpriteRenderer>().flipX = true;
                    proj.GetComponent<SpriteRenderer>().flipY = true;
                }
            }
            else if (track >= delay + range)
            {
                this.GetComponent<Animator>().SetBool("2", false);
                track = 0.0f;
                proj.GetComponent<SpriteRenderer>().flipX = false;
                proj.GetComponent<SpriteRenderer>().flipY = false;
                timer = 0.0f;
                proj.SetActive(false);
                proj.gameObject.transform.localScale = new Vector3(1, 1, 1);
                IsLight = false;
                spawn = false;
                //this.GetComponents<AudioSource>()[1].Stop();
            }
        }
    }
}
