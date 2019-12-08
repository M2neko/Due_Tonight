using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformSword : MonoBehaviour
{
    [SerializeField] private GameObject Zee;
    [SerializeField] private float Duration = 3.0f;
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
        pos = Zee.transform.position;
        //Zee.GetComponent<Animator>().SetBool("Sword", true);
        //Zee.GetComponents<AudioSource>()[1].Play();
        OtherPlayer = Zee.GetComponent<Player2Controller>().OtherPlayer();

        Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);

        //StartCoroutine(OnBike());
        //Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000);
    }

    private IEnumerator OnBike()
    {
        yield return new WaitForSeconds(1.5f);
        if (OtherPlayer.transform.position.x >= Zee.gameObject.transform.position.x)
        {
            Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
        }
        else
        {
            Zee.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);
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
                //Zee.GetComponent<Animator>().SetBool("Sword", false);
                mtime = 0.0f;
            }
        }
    }
}
