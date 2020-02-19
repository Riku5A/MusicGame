using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    GameObject Notes;
    string timing;
    public GameObject Great, Perfect, False;
    private Vector3 startPos, endPos;
    string swipe;
    bool isonTrigger = false;
    NotesMove notesmove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(isonTrigger == true)
            {
                foreach(RaycastHit hit in Physics.RaycastAll(ray))
                {
                    if(hit.collider.gameObject == this.gameObject)
                    {
                        if(notesmove.swipeMode == "touch")
                        {
                            Debug.Log(timing);
                            if(timing == "great")
                            {
                                var obj = Instantiate<GameObject>(Great, this.transform.position, Quaternion.identity);
                                Destroy(Notes);
                                timing = "none";
                            }
                            if(timing == "perfect")
                            {
                                var obj = Instantiate<GameObject>(Perfect, this.transform.position, Quaternion.identity);
                                Destroy(Notes);
                                timing = "none";
                            }
                        }
                    }
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            if(startPos.x > endPos.x)
            {
                swipe = "left";
            }else if(startPos.x < endPos.x)
            {
                swipe = "right";
            }
            if(isonTrigger == true)
            {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                foreach(RaycastHit hit in Physics.RaycastAll(ray))
                {
                    if(hit.collider.gameObject == this.gameObject)
                    {
                        if(notesmove.swipeMode == swipe)
                        {
                            Destroy(Notes);
                            Debug.Log(timing);
                            if(timing == "great")
                            {
                                var obj = Instantiate<GameObject>(Great, this.transform.position, Quaternion.identity);
                                timing = "none";
                            }
                            if(timing == "perfect")
                            {
                                var obj = Instantiate<GameObject>(Perfect, this.transform.position, Quaternion.identity);
                                timing = "none";
                            }
                        }
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        isonTrigger = true;
        Notes = col.gameObject.transform.parent.gameObject;
        notesmove = Notes.GetComponent<NotesMove>();
        if(col.tag == "PerfectTiming")
        {
            timing = "perfect";
        }else if(col.tag == "GreatTiming")
        {
            timing = "great";
        }
    }

    void OnTriggerExit(Collider col)
    {
        timing = "none";
    }
}
