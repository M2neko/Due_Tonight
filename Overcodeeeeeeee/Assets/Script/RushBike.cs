using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBike : MonoBehaviour
{
    [SerializeField] private GameObject Butner;
    [SerializeField] private float Duration = 3.0f;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private float mtime = 0.0f;
    public static bool IsRush = false;

    public void Rush()
    {
        if (IsRush)
        {
            return;
        }
        IsRush = true;
        Butner.GetComponent<Animator>().SetBool("Rush", true);
        Butner.GetComponents<AudioSource>()[1].Play();
        OtherPlayer = Butner.GetComponent<PlayerController>().OtherPlayer();
        StartCoroutine(OnBike());
        //Butner.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000);
    }

    private IEnumerator OnBike()
    {
        yield return new WaitForSeconds(1.5f);
        if (OtherPlayer.transform.position.x >= Butner.gameObject.transform.position.x)
        {
            Butner.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
        }
        else
        {
            Butner.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);
        }
    }


    private void Update()
    {
        if (IsRush)
        {
            mtime += Time.deltaTime;
            if (mtime >= Duration)
            {
                IsRush = false;
                Butner.GetComponent<Animator>().SetBool("Rush", false);
                mtime = 0.0f;
            }
        }
    }
}
