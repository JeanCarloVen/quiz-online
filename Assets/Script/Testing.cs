using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class Testing : MonoBehaviour
{
    string url = "http://192.168.42.223/sinsen/quiz/ListQuiz.php";


    // Start is called before the first frame update
    [System.Serializable]
    public class SoalList
    {

        [TextArea(6, 10)]
        [Header("Soal")]
        public string soal;

        //[Header("Kunci Jawaban")]
        //public bool A;
        //public bool B, C, D;
        [Header("Array Jawaban")]
        public string jawaban;

        [Header("status")]
        public string quiz;

    }

    public List<SoalList> ListSoal;

    private void Update()
    {
        StartCoroutine(viewProfil());



    }

    IEnumerator viewProfil()
    {
        WWWForm form = new WWWForm();
        //form.AddField("nim", nim);
        using (UnityWebRequest www = UnityWebRequest.Get(url))
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
                


                for(int i = 0; i<3; i++)
                {
                    profilInfo = jsonArrayString[i].AsObject;
                    ListSoal[i].soal = profilInfo["soal"];
                    ListSoal[i].jawaban = profilInfo["jawaban"];
                    ListSoal[i].quiz = profilInfo["quiz"];
                }

                
                //Debug.Log(jsonArrayString);
                //if (profilInfo["jawaban"] == "a")
                //{
                //    //foto.gameObject.GetComponent<Image>().sprite = perempuan;
                //    Debug.Log("a");
                //}
                //else if (profilInfo["jawaban"] == "b")
                //{
                //    //foto.gameObject.GetComponent<Image>().sprite = laki;
                //    Debug.Log("b");
                //}


            }
        }
    }


    private class listSoal
    {
        public List<testList> listTest;
    }


    [System.Serializable]
    public class testList
    {
        public string id;
        public string soal;
        public string jawaban;
        public string quiz;
    }
}
