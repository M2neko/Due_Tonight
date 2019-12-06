using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Shake : MonoBehaviour
{
    //[SerializeField] private float Upduration;
    //[SerializeField] private float Downduration;
    //[SerializeField] private float Leftduration;
    //[SerializeField] private float Rightduration;
    [SerializeField] private float positionShakeSpeed = 1.0f;
    [SerializeField] private Vector3 positionShakeRange = new Vector3(1.0f, 1.0f, 1.0f);

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().material = new Material(Shader.Find("Sprites/Diffused"));
        position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Change Shake position
        if (positionShakeSpeed > 0)
        {
            transform.localPosition = position + Vector3.Scale(SmoothRandom.GetVector3(positionShakeSpeed), positionShakeRange);
        }
    }
}
