using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaGates : MonoBehaviour
{
    [SerializeField] private GameObject Butner;
    [SerializeField] private float Duration = 2.0f;
    public static bool IsNova = false;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private GameObject[] projectileList;
    private float mtime = 0.0f;

    public void Nova()
    {
        if (IsNova || RushBike.IsRush || ShootGate.IsShoot)
        {
            return;
        }
        IsNova = true;

        projectileList = GameObject.FindGameObjectsWithTag("ButtAttack");

        if (projectileList.Length != 0)
        {
            Butner.GetComponents<AudioSource>()[0].Play();
        }

        pos = Butner.gameObject.transform.position;

        foreach (var projectile in projectileList)
        {
            projectile.transform.position = new Vector3(Random.value * 1.0f, 0.0f, 0.0f);
            projectile.transform.position += pos;
            projectile.GetComponent<SpriteRenderer>().enabled = true;
            OtherPlayer = Butner.GetComponent<PlayerController>().OtherPlayer();
            if (OtherPlayer.transform.position.x >= Butner.gameObject.transform.position.x)
            {
                projectile.GetComponent<SpriteRenderer>().flipX = false;
                projectile.GetComponent<Rigidbody2D>().velocity = Vector3.up * Random.Range(3.0f, 7.0f) + Vector3.right * Random.Range(3.0f, 7.0f);
            }
            else
            {
                projectile.GetComponent<SpriteRenderer>().flipX = true;
                projectile.GetComponent<Rigidbody2D>().velocity = Vector3.up * Random.Range(3.0f, 7.0f) + Vector3.left * Random.Range(3.0f, 7.0f);
            }
        }
    }

    private void Update()
    {
        if (IsNova)
        {
            mtime += Time.deltaTime;
            if (mtime > Duration)
            {
                IsNova = false;
                mtime = 0.0f;
                foreach (var projectile in projectileList)
                {
                    Destroy(projectile, 0.1f);
                }
            }
        }
    }
}
