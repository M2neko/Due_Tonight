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
    private bool yesorno = false;
    private bool spawn = false;
    private float track = 0.0f;
    private float timer = 0.0f;

    public void Pi(GameObject player)
    {
        if (yesorno)
        {
            return;
        }
        otherplayer = player;
        location = new Vector3(player.gameObject.transform.position.x, 4, player.gameObject.transform.position.z);
        yesorno = true;

    }

    private void Update()
    {
        if (yesorno) {
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
                track = 0.0f;
                timer = 0.0f;
                proj.gameObject.transform.localScale = new Vector3(1, 1, 1);
                proj.SetActive(false);
                yesorno = false;
                spawn = false;
            }
        }
    }
}
