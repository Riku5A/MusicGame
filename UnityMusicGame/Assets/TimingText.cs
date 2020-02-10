using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimingText : MonoBehaviour
{
    //フェードアウトするスピード
    private float fadeOutSpeed = 1f;
    //移動値
    private float moveSpeed = 0.4f;
    Text myText;
    public string Timing;
    public Color textColor;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myText.text = Timing;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        myText.color = Color.Lerp(myText.color, textColor, fadeOutSpeed * Time.deltaTime);
        if(myText.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
