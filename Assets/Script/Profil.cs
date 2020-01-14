using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.IO;
using SimpleJSON;

public class Profil : MonoBehaviour
{
    // Start is called before the first frame update
     public Text nama , kelas, hasil1 , hasil2 ,hasil3 , hasil4;
     public Sprite laki , perempuan;
     public GameObject foto , panelHasil;
     int a = 0;

    Action<string> _infoProfil;


    string url = "http://192.168.42.199/sinsen/viewProfil.php?nim="+Data._nim;
    string url2 = "http://192.168.42.199/sinsen/lihatHasil.php?nim="+Data._nim;
    void Start()
    {
        panelHasil.SetActive(false);
        StartCoroutine(quizHasil(Data._nim));
        StartCoroutine(viewProfil(Data._nim));
        
    }
    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            if(a == 0){
             		SceneManager.LoadScene("MenuUtama");
           }else if(a == 1){
               panelHasil.SetActive(false);
               a = 0;
           }
        }
        
    
    }
    public void Buttonklik(){
        panelHasil.SetActive(true);
        
        a = 1;
    }
    public void backKlik(){
        panelHasil.SetActive(false);
        a = 0;
    }
    // Update is called once per frame
    IEnumerator viewProfil(string nim)
    {
         WWWForm form = new WWWForm();
        form.AddField("nim",nim);
        using (UnityWebRequest www = UnityWebRequest.Post(url,nim))
        {
            yield return www.SendWebRequest();            
            if (www.isNetworkError || www.isHttpError)
            {
                
            }
            else
            {
                
                string jsonArray = www.downloadHandler.text;
             
                JSONArray jsonArrayString = JSON.Parse(jsonArray) as JSONArray;
            JSONObject profilInfo = new JSONObject();
            profilInfo = jsonArrayString[0].AsObject;
      
            nama.text = profilInfo["nama"];
            kelas.text = profilInfo["kelas"];
            if(profilInfo["jk"] == "perempuan"){
                foto.gameObject.GetComponent<Image>().sprite = perempuan;
            }else if(profilInfo["jk"] == "laki"){
                foto.gameObject.GetComponent<Image>().sprite = laki;
            }
        
            
            }
        }
    }
    IEnumerator quizHasil(string nim)
    {
         WWWForm form = new WWWForm();
        form.AddField("nim",nim);
        using (UnityWebRequest www = UnityWebRequest.Post(url2,nim))
        {
            yield return www.SendWebRequest();            
            if (www.isNetworkError || www.isHttpError)
            {
                
            }
            else
            {
                
                string jsonArray = www.downloadHandler.text;
             
                JSONArray jsonArrayString = JSON.Parse(jsonArray) as JSONArray;
            JSONObject nilai = new JSONObject();
            JSONObject nilai2 = new JSONObject();
            JSONObject nilai3 = new JSONObject();
            JSONObject nilai4 = new JSONObject();

            nilai = jsonArrayString[0].AsObject;
            nilai2 = jsonArrayString[1].AsObject;
            nilai3 = jsonArrayString[2].AsObject;
            nilai4 = jsonArrayString[3].AsObject;
                if(nilai["info"] == "quiz1"){
                    hasil1.text = "Quiz 1 = "+nilai["hasilQuiz"];
                }
                if(nilai2["info"] == "quiz2"){
                    hasil2.text = "QUIZ 2 = "+nilai2["hasilQuiz"];
                }
                if(nilai3["info"] == "quiz3"){
                    hasil3.text = "QUIZ 3 = "+nilai3["hasilQuiz"];
                }
                if(nilai4["info"] == "quiz4"){
                    hasil4.text = "QUIZ 4 = "+nilai4["hasilQuiz"];
                }
                
                }
            }
        
    }

    

    
    
}
