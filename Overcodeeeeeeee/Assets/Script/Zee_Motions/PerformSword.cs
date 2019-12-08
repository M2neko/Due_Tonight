using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformSword : MonoBehaviour
{
    [SerializeField] private GameObject Zee;
    [SerializeField] private float Duration = 0.9f;
    private Vector3 pos;
    private GameObject OtherPlayer;
    private float mtime = 0.0f;
    public static bool IsSword = false;

    public void Perform()
    {
        if (IsSword)
        {
            return;
        }
        IsSword = true;
        Zee.GetComponent<Animator>().SetBool("Sword", true);
        //Zee.GetComponents<AudioSource>()[1].Play();
        OtherPlayer = Zee.GetComponent<Player2Controller>().OtherPlayer();

        //Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);

        StartCoroutine(OnSword());
        //Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000);
    }

    private IEnumerator OnSword()
    {
        yield return new WaitForSeconds(0.2f);
        if (OtherPlayer.transform.position.x >= Zee.gameObject.transform.position.x)
        {
            Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
            for (int i = 0; i < 15; i++)
            {
                yield return new WaitForSeconds(0.2f / 15.0f);
                Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 150);
            }
        }
        else
        {
            Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
            for (int i = 0; i < 15; i++)
            {
                yield return new WaitForSeconds(0.2f / 15.0f);
                Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);
            }
        }
    }


    private void Update()
    {
        if (IsSword)
        {
            mtime += Time.deltaTime;
            if (mtime >= Duration)
            {
                IsSword = false;
                Zee.GetComponent<Animator>().SetBool("Sword", false);
                mtime = 0.0f;
            }
        }
    }
}
