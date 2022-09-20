using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_Init : MonoBehaviour
{
    
    public int quadrante = 1; //1,2,3,4
    //public Material skyboxMat;
    public Color[] skyColors;
    public Color[] wallColors;
    public Material backWallsMat;
    public Material skyMat;
    public Material[] Pics1;
    public Material[] Pics2;
    public Material[] Pics3;
    public Material[] Pics4;
    public GameObject[] allFrames;

    void Start()
    {
        SetUpEnvironment(quadrante);
        SetUpPictures(quadrante);
    }

    public void SetUpEnvironment(int q)
    {
        //RenderSettings.skybox.SetColor("_Tint", skyColors[q-1]);
        skyMat.SetColor("_SkyTint", skyColors[q - 1]);
        backWallsMat.color = wallColors[q-1];
    }

    public void SetUpPictures(int q)
    {
        for (int j = 0; j < 5; j++)
        {
            switch (q) {
                case 1:
                    allFrames[j].GetComponent<Renderer>().material = Pics1[j];
                break;
                case 2:
                    allFrames[j].GetComponent<Renderer>().material = Pics2[j];
                    break;
                case 3:
                    allFrames[j].GetComponent<Renderer>().material = Pics3[j];
                    break;
                case 4:
                    allFrames[j].GetComponent<Renderer>().material = Pics4[j];
                    break;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
