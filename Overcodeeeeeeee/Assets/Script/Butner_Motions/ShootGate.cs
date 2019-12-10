using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGate : MonoBehaviour
{
    [SerializeField] private GameObject Butner;
    [SerializeField] private GameObject Gate1;
    [SerializeField] private GameObject Gate2;
    [SerializeField] private GameObject Gate3;
    [SerializeField] private GameObject Gate4;
    [SerializeField] private GameObject Gate5;
    private GameObject Gate;
    private GameObject proj;
    private GameObject player;
    private float track;
    private bool left;
    public static bool IsShoot = false;
    public static bool IsDestroy = false;
    private Vector3 pos;

    public void Shoot()
    {
        if (IsShoot || RushBike.IsRush || NovaGates.IsNova)
        {
            return;
        }
        pos = Butner.gameObject.transform.position;
        Butner.GetComponents<AudioSource>()[2].Play();
        switch (Random.Range(1, 6))
        {
            case 1:
                Gate = Gate1;
                break;
            case 2:
                Gate = Gate2;
                break;
            case 3:
                Gate = Gate3;
                break;
            case 4:
                Gate = Gate4;
                break;
            case 5:
                Gate = Gate5;
                break;
            default:
                Gate = Gate1;
                break;
        }
        proj = Instantiate(Gate, pos, Quaternion.identity);
        proj.transform.localScale = new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f,2.0f));
        //proj.transform.Rotate(new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)));
        //proj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        proj.SetActive(true);
        // Play audio sound
        //Butner.GetComponent<AudioSource>().Play();
        player = Butner.GetComponent<PlayerController>().OtherPlayer();
        if (player.transform.position.x <= Butner.gameObject.transform.position.x)
        {
            left = true;
            proj.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            left = false;
            proj.GetComponent<SpriteRenderer>().flipX = false;
        }
        IsShoot = true;
    }

    private void Update()
    {
        if (IsDestroy)
        {
            track = 0.0f;
            Destroy(proj);
            IsDestroy = false;
            IsShoot = false;
        }

        if (IsShoot)
        {
            track += Time.deltaTime * 5;
            if (track >= 5.0f)
            {
                //Butner.GetComponent<Animator>().SetBool("1", false);
            }
            if (track <= 3.0f)
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
                proj.GetComponent<SpriteRenderer>().enabled = false;
                IsShoot = false;
                //Destroy(proj);
            }
        }
    }
}
