using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Gmae_Manager : MonoBehaviour
{
    private float[] timings;
    private int[] lineNums;
    public GameObject[] notes;
    private int noteCounter;
    private float startTime = 0;

    private bool isPlaying = false;

    public string filePass;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        timings = new float[1024];
        lineNums = new int[1024];
        LoadCSV();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            CheckNextNotes();
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        startTime = Time.time;
        isPlaying = true;
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);//csvの内容をreaderに読み込む

        int i = 0;
        while(reader.Peek() > -1)//csvファイルの中身をタイミングとラインNoで格納する
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');//カンマで区切って格納
            for(int j = 0; j < values.Length; j++)
            {
                timings[i] = float.Parse(values[0]);
                lineNums[i] = int.Parse(values[1]);
            }
            i++;
        }
    }

    void CheckNextNotes()
    {
        while(timings[noteCounter] - 1f < GetMusicTime() && timings[noteCounter] != 0)
        {
            SpawnNotes(lineNums[noteCounter]);
            noteCounter++;
        }
    }

    void SpawnNotes(int num)
    {
        Instantiate(notes[num],new Vector3(0f, 2.5f, 5f),Quaternion.identity);
    }

    float GetMusicTime()
    {
        return Time.time - startTime; 
    } 
}
