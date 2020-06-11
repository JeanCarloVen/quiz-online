using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pilihQuiz : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public static string infoQuiz;
    string quiz1Info , quiz2Info , quiz3Info , quiz4Info;
    public Button bQuiz1 , bQuiz2 , bQuiz3 , bQuiz4;
    int _info=0;
    
    public static string quiz = "";
    void Start()
    {
        animator.SetBool("rules",false);
        //StartCoroutine(viewInfo());
        //StartCoroutine(cekQuiz(Data._nim));
    }

    // Update is called once per frame
    void Update()
    {
        
            if(Input.GetKeyDown(KeyCode.Escape)){
            if (_info == 0)
            {
                SceneManager.LoadScene("MenuUtama");
            }
            else if (_info == 1)
            {
                _info = 0;
                animator.SetBool("rules", false);

            }
        }

        if(_info == 1)
        {
            animator.SetBool("rules", true);
        }

        
        // if(quiz1Info == "false"){
        //     bQuiz1.interactable = false;
        // }else{
        //     bQuiz1.interactable = true;
        // }
    }

    public void _pilihQuiz(string quiz){
        
        infoQuiz = quiz;
        _info = 1;
    }

    public void ready(){
        if(infoQuiz == "1"){
            SceneManager.LoadScene("Quiz1");
            quiz = "quiz1";
        }else if(infoQuiz == "2"){
            SceneManager.LoadScene("Quiz2");
            quiz = "quiz2";
        }else if(infoQuiz == "3"){
            SceneManager.LoadScene("Quiz3");
            quiz = "quiz3";
        }else if(infoQuiz == "4"){
            SceneManager.LoadScene("Quiz4");
            quiz = "quiz4";
        }
    }

    //IEnumerator viewInfo()
    //{
    //    WWWForm form = new WWWForm();
    //    // form.AddField("nim",nim);
    //    using (UnityWebRequest www = UnityWebRequest.Get(API.GetInstance().cekStatus))
    //    {
    //        yield return www.SendWebRequest();            
    //        if (www.isNetworkError || www.isHttpError)
    //        {
                
    //        }
    //        else
    //        {
              
    //            string jsonArray = www.downloadHandler.text;
             
    //        JSONArray jsonArrayString = JSON.Parse(jsonArray) as JSONArray;
    //        JSONObject info1 = new JSONObject();
    //        JSONObject info2 = new JSONObject();
    //        JSONObject info3 = new JSONObject();
    //        JSONObject info4 = new JSONObject();

            
    //        info1 = jsonArrayString[0].AsObject;
    //        info2 = jsonArrayString[1].AsObject;
    //        info3 = jsonArrayString[2].AsObject;
    //        info4 = jsonArrayString[3].AsObject;
    //        Debug.Log("status 1 ="+info1["status"]);

    //        // if(info1["status"] == "false"){
    //        //     bQuiz1.interactable = false;
    //        // }else{
    //        //     bQuiz1.interactable = true;
    //        // }
    //        if(info2["status"] == "false"){
    //            bQuiz2.interactable = false;
    //        }else{
    //            bQuiz2.interactable = true;
    //        }
    //        if(info3["status"] == "false"){
    //            bQuiz3.interactable = false;
    //        }else{
    //            bQuiz3.interactable = true;
    //        }
    //        if(info4["status"] == "false"){
    //            bQuiz4.interactable = false;
    //        }else{
    //            bQuiz4.interactable = true;
    //        }
            
        
            
    //        }
    //    }
    //}

    //IEnumerator cekQuiz(string nim)
    //{
    //     WWWForm form = new WWWForm();
    //    form.AddField("nim",nim);
    //    using (UnityWebRequest www = UnityWebRequest.Post(API.GetInstance().cekStatus, nim))
    //    {
    //        yield return www.SendWebRequest();            
    //        if (www.isNetworkError || www.isHttpError)
    //        {
                
    //        }
    //        else
    //        {
                
    //            string jsonArray = www.downloadHandler.text;
             
    //            JSONArray jsonArrayString = JSON.Parse(jsonArray) as JSONArray;
    //         JSONObject quiz1 = new JSONObject();
    //        JSONObject quiz2 = new JSONObject();
    //        JSONObject quiz3 = new JSONObject();
    //        JSONObject quiz4 = new JSONObject();

    //        quiz1 = jsonArrayString[0].AsObject;
    //        quiz2 = jsonArrayString[1].AsObject;
    //        quiz3 = jsonArrayString[2].AsObject;
    //        quiz4 = jsonArrayString[3].AsObject;

    //        if(quiz1["hasilQuiz"] != ""){
    //            Debug.Log("hasil = "+quiz1["hasilQuiz"]);
    //            bQuiz1.interactable = false;
    //        }
    //        if(quiz2["hasilQuiz"] != ""){
    //            bQuiz2.interactable = false;
    //        }
    //        if(quiz3["hasilQuiz"] != ""){
    //            bQuiz3.interactable = false;
    //        }
    //        if(quiz4["hasilQuiz"] != ""){
    //            bQuiz4.interactable = false;
    //        }
    //        // nama.text = profilInfo["nama"];
    //        // kelas.text = profilInfo["kelas"];
    //        // if(profilInfo["jk"] == "perempuan"){
    //        //     foto.gameObject.GetComponent<Image>().sprite = perempuan;
    //        // }else if(profilInfo["jk"] == "laki"){
    //        //     foto.gameObject.GetComponent<Image>().sprite = laki;
    //        // }
        
            
    //        }
    //    }
    //}
}
