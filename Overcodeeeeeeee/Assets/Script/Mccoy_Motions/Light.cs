﻿using System.Collections;
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
        location = new Vector3(player.gameObject.transform.position.x, 4, player.gameObject.transform.position.z);
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
                spawn = true;
            }
            else if (track >= delay && track <= delay + range)
            {
                timer += Time.deltaTime;
                proj.gameObject.transform.position = new Vector3(proj.gameObject.transform.position.x, proj.gameObject.transform.position.y - 3 / range);
                proj.gameObject.transform.localScale = new Vector3(proj.gameObject.transform.localScale.x + 1 / range, proj.gameObject.transform.localScale.y + 4.6f / range);
            }
            else if (track >= delay + range)
            {
                this.GetComponent<Animator>().SetBool("2", false);
                track = 0.0f;
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