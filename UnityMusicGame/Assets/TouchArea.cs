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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll(ray))
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    Destroy(Notes);
                    Debug.Log(timing);
                    if(timing == "great")
                    {
                        var obj = Instantiate<GameObject>(Great, this.transform.position, Quaternion.identity);
                    }
                    if(timing == "false")
                    {
                        var obj = Instantiate<GameObject>(False, this.transform.position, Quaternion.identity);
                    }
                    if(timing == "perfect")
                    {
                        var obj = Instantiate<GameObject>(Perfect, this.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        Notes = col.gameObject.transform.parent.gameObject;
        if(col.tag == "PerfectTiming")
        {
            timing = "perfect";
        }else if(col.tag == "GreatTiming")
        {
            timing = "great";
        }else if(col.tag == "FalseTiming")
        {
            timing = "false";
        }
    }

    void OnTriggerExit(Collider col)
    {
        timing = "none";
    }
}
