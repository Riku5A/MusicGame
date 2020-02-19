using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMove : MonoBehaviour
{
    public int speed;
    public Vector3 targetPos;
    Vector3 startPos;
    float time = 0f;
    public string swipeMode;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        transform.localScale = new Vector3(0f,0f,0f);
        if(swipeMode == "right")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if(swipeMode == "left")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var v = time / 2;
        transform.position = Vector3.Lerp(startPos,targetPos,v);
        transform.localScale = Vector3.Slerp(new Vector3(0f,0f,0f), new Vector3(0.8f,0.8f,0.1f), time);
        time += Time.deltaTime;
    }
}
