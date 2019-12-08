using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWave : MonoBehaviour
{
    [SerializeField] private GameObject Student;
    [SerializeField] private GameObject Wave;
    private GameObject proj;
    private GameObject player;
    private float track;
    private bool left;
    public static bool IsWave = false;
    private bool IsExist = false;
    private Vector3 pos;

    public void Control()
    {
        if (IsWave)
        {
            return;
        }
        Student.GetComponent<Animator>().SetBool("Wave", true);
        pos = Student.gameObject.transform.position;

        player = Student.GetComponent<Player2Controller>().OtherPlayer();
        if (player.transform.position.x <= Student.gameObject.transform.position.x)
        {
            left = true;
            pos -= Vector3.right * 2.3f;
        }
        else
        {
            left = false;
            pos += Vector3.right * 2.3f;
        }
        IsWave = true;
        StartCoroutine(OnWave());
    }

    private IEnumerator OnWave()
    {
        yield return new WaitForSeconds(0.3f);
        proj = Instantiate(Wave, pos, Quaternion.identity);
        proj.SetActive(true);
        IsExist = true;
        yield return new WaitForSeconds(0.3f);
        Student.GetComponents<AudioSource>()[1].Play();
    }

    private void Update()
    {
        if (IsWave && IsExist)
        {
            track += Time.deltaTime * 5;
            var projScale = proj.gameObject.transform.localScale;

            if (track <= 9.8f)
            {
                if (left)
                {
                    proj.gameObject.transform.localScale = projScale + Vector3.right * 3 * Time.deltaTime;
                    proj.gameObject.transform.position = new Vector3(pos.x - track / 2.5f, pos.y, pos.z);
                }
                else
                {
                    proj.gameObject.transform.localScale = projScale + Vector3.right * 3 * Time.deltaTime;
                    proj.gameObject.transform.position = new Vector3(pos.x + track / 2.5f, pos.y, pos.z);
                }
            }
            else
            {
                track = 0.0f;
                proj.SetActive(false);
                IsWave = false;
                IsExist = false;
                Student.GetComponent<Animator>().SetBool("Wave", false);
                Destroy(proj);
            }
        }
    }
}
