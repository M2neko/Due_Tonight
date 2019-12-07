using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaGates : MonoBehaviour
{
    [SerializeField] private GameObject Butner;
    [SerializeField] private float Duration = 2.0f;
    public static bool novaing = false;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private GameObject[] projectileList;
    private float mtime = 0.0f;

    public void Nova()
    {
        if (novaing)
        {
            return;
        }
        novaing = true;
        projectileList = GameObject.FindGameObjectsWithTag("ButtAttack");

        pos = Butner.gameObject.transform.position;

        foreach (var projectile in projectileList)
        {
            projectile.GetComponent<Rigidbody>().useGravity = true;
            projectile.transform.position = new Vector3(Random.value * 1.0f, 0.0f, 0.0f);
            projectile.transform.position += pos;
            projectile.GetComponent<SpriteRenderer>().enabled = true;
            OtherPlayer = Butner.GetComponent<PlayerController>().OtherPlayer();
            if (OtherPlayer.transform.position.x >= Butner.gameObject.transform.position.x)
            {
                projectile.GetComponent<SpriteRenderer>().flipX = false;
                projectile.GetComponent<Rigidbody>().velocity = Vector3.up * Random.Range(3.0f, 7.0f) + Vector3.right * Random.Range(3.0f, 7.0f);
            }
            else
            {
                projectile.GetComponent<SpriteRenderer>().flipX = true;
                projectile.GetComponent<Rigidbody>().velocity = Vector3.up * Random.Range(3.0f, 7.0f) + Vector3.left * Random.Range(3.0f, 7.0f);
            }
        }

    }

    private void Update()
    {
        if (novaing)
        {
            mtime += Time.deltaTime;
            if (mtime > Duration)
            {
                novaing = false;
                mtime = 0.0f;
                foreach (var projectile in projectileList)
                {
                    Destroy(projectile, 0.1f);
                }
            }
        }
    }
}
