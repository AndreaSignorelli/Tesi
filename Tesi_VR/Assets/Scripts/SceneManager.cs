using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class SceneManager : MonoBehaviour
{

    public float durataPic;
    public float curTime;
    public float startTime;
    public Texture2D[] allPics;
    public Texture2D[] selectedPics;
    public int selectedPicIndex = 0;
    public bool questionario = false;
    public Material imageMat;
    string subjectCode;
    public GameObject[] allMenus;
    public int w = 0; //0=istruzioni, 1=intermezzo, 2=immagine, 3=questionario

    // Start is called before the first frame update
    void Start()
    {
        InitializeProtocol();
        SelectPics();
        StartCoroutine(StartNextPic());
    }

    // Update is called once per frame
    void Update()
    {

        if (w == 2)
        {
            curTime += Time.deltaTime;
            if (curTime >= durataPic)
            {
                //fine durata
                //ChangeMenu(3); //go to questionario
                StartCoroutine(StartNextPic());
            }
        }

    }

    void InitializeProtocol()
    {
        ChangeMenu(0);
    }

    public void CloseQuestionario()
    {
        questionario = false;
        if (selectedPicIndex < 4)
        {
            StartCoroutine(StartNextPic());
        }
        else
        {
            ChangeMenu(4);
        }
        //SaveQuestionario
    }

    public void SaveQuestionario()
    {

    }

    public void ResetQuestionario()
    {

    }

    public IEnumerator StartNextPic()
    {
        if (selectedPicIndex < 4)
        {
            ChangeMenu(1);
            yield return new WaitForSeconds(2);
            Debug.Log("Starting next pic");
            curTime = 0;
            ChangeMenu(2);
            //startTime = Time.time;
            imageMat.SetTexture("_BaseMap", selectedPics[selectedPicIndex]);
            selectedPicIndex++;
        }
        else
        {
            ChangeMenu(4); //go to end visual
        }
    }

    public void SelectPics() //seleziona 4 pics randomiche per ogni soggetto
    {
        //supponendo di avere 20 pics, 5 per zona, ne voglio selezionare 1 per zona
        int n = allPics.Length;
        int n_quarti = (n / 4) - 1;
        selectedPics = new Texture2D[4];
        for (int k = 0; k < 4; k++)
        {
            int i = Random.Range(0, n_quarti) + k * 4;
            selectedPics[k] = allPics[i];
        }
    }

    public void CloseInstructions()
    {
        StartCoroutine(StartNextPic());
    }

    public void GenerateSubjectCode()
    {
        //needed?
    }

    public void ChangeMenu(int nextMenu)
    {
        w = nextMenu;
        for (int i = 0; i < allMenus.Length; i++)
        {
            allMenus[i].SetActive(false);
        }
        allMenus[nextMenu].SetActive(true);
    }

    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();
        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(path);
        //TextAsset asset = Resources.Load("test");
        //Print the text from the file
        //Debug.Log(asset.text);
    }
    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
