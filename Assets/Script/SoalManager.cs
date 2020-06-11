using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class SoalManager : MonoBehaviour
{

    int nomerSoal =0;
    API api = new API();

    [System.Serializable]
    public class SoalList
    {

        [TextArea(6,10)]
        [Header("Soal")]
        public string soal;
        [Header("Array Jawaban")]
        public string jawaban;

        //[Header("Array Jawaban")]
        public Image pilihSoal;

    }
    [System.Serializable]
    public class pilihan{
        [Header("pilihan jawaban")]
        public string _pilih;
    }
    public Animator animator;
    int hasil = 0 , nilaiAcak = 0;
    public Button prevButton , nextButton, buttonA ,buttonB , buttonC , buttonD;
    public List<SoalList> exam;
    public Text _benar, waktu, _salah,_hasil;
    int salah , benar, screenShot;
    public Text textSoal , noSoal;
    public GameObject popup , pilihMap, backPanel;
    string[] jawaban;
    public List<pilihan> jawab;
    //string buatId = Data._nim+""+pilihQuiz.quiz;
    private float startTime = 7200f , currentTime = 0f;
    

    void Start()
    {
        
        currentTime = startTime;
        popup.SetActive(false);
        backPanel.SetActive(false);
        pilihMap.SetActive(false);
        
        animator.SetBool("hasil",false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(liatSoal());
        screenShot=ScreenShot.ss *20;
        hasil=benar*5-screenShot;
        if(Input.GetKey(KeyCode.Print)){
            hasil-=5;
        }
        
        
        string hours = ((int)currentTime/3600).ToString();
        if(currentTime >= 3600){
            currentTime -= 2 * Time.deltaTime;
           string minutes= ((int) currentTime/120).ToString();
           waktu.text = hours+" : "+minutes;
        }else{
            currentTime -= 1 * Time.deltaTime;
            string minutes= ((int) currentTime/60).ToString();
            waktu.text = hours+" : "+minutes;
        }


        if (exam.Count > 0)
        {
            textSoal.text = exam[nomerSoal].soal;
        } else{
        
        }

        for(int i = 0; i < 20; i++)
        {
            //exam[nomerSoal].pilihSoal = GameObject.Find(""+i + 1).GetComponent<Image>();
            if (jawab[nomerSoal]._pilih == "")
            {   
                exam[nomerSoal].pilihSoal.color = Color.red; 
            }else
            {
                exam[nomerSoal].pilihSoal.color = Color.green;
            }
        }
        
        if(hasil < 0){
            _hasil.text = "Result :0";
            _salah.text = "Wrong Answer :"+salah;
            _benar.text = "Correct Answer :"+benar;
        }else{
            _hasil.text = "Result :"+hasil;
            _salah.text = "Wrong Answer :"+salah;
            _benar.text = "Correct Answer :"+benar;
        }
        
        if(nomerSoal == 0){
            prevButton.interactable = false;
        }else if(nomerSoal == 19){
            nextButton.interactable = false;
        }else{
            nextButton.interactable = true;
            prevButton.interactable = true;
        }


        
    }

    private void LateUpdate()
     {
         if(jawab[nomerSoal]._pilih == "a"){
            buttonA.interactable = false;
            buttonB.interactable = true;
            buttonC.interactable = true;
            buttonD.interactable = true;
        }else if(jawab[nomerSoal]._pilih == "b"){
            buttonA.interactable = true;
            buttonB.interactable = false;
            buttonC.interactable = true;
            buttonD.interactable = true;
        }else if(jawab[nomerSoal]._pilih == "c"){
            buttonA.interactable = true;
            buttonB.interactable = true;
            buttonC.interactable = false;
            buttonD.interactable = true;
            
        }else if(jawab[nomerSoal]._pilih == "d"){
            buttonA.interactable = true;
            buttonB.interactable = true;
            buttonC.interactable = true;
            buttonD.interactable = false;
        }else{
            buttonA.interactable = true;
            buttonB.interactable = true;
            buttonC.interactable = true;
            buttonD.interactable = true;
        }
     }


    public void pilihNomer(int nomer){
        nomer-=1;
        pilihMap.SetActive(false);
        backPanel.SetActive(false);
        textSoal.text = exam[nomer].soal;
                //exam1.RemoveAt(nomerSoal);
            nomerSoal = nomer;
            int kurangSoal = nomer + 1;
            nomer = Random.Range(nomer, kurangSoal);
            noSoal.text = ""+kurangSoal;
    }

    public void klikMenu(){
        pilihMap.SetActive(true);
        backPanel.SetActive(true);
    }
    public void back(){
        SceneManager.LoadScene("MenuUtama");
        StartCoroutine(tambahData(Data._nim , hasil.ToString()));
    }

    public void finish(){
        popup.SetActive(true);  
    }
    public void pilihNo(){
        
        popup.SetActive(false);
        backPanel.SetActive(false);
        pilihMap.SetActive(false);
    }
    public void cekJawaban(){
        popup.SetActive(false);
        animator.SetBool("hasil",true);


    for(int j = 0; j < 20; j++)
        {
            if(jawab[j]._pilih == exam[j].jawaban)
            {
                benar += 1;
            }
            else
            {
                salah += 1;
            }
        }
    }

    public void pilihJawaban(string pilih){
        jawab[nomerSoal]._pilih = pilih;

    }

    public void next(){
        nomerSoal+=1;
         int kurangSoal = nomerSoal + 1;
         
        nilaiAcak = Random.Range(nomerSoal, kurangSoal);
         
            noSoal.text = ""+kurangSoal;
            textSoal.text = exam[nilaiAcak].soal;
            
    }
    public void prev(){
        // nomerSoal-=1;
        nomerSoal -=1;
        int kurangSoal = nomerSoal + 1;
        // nomerSoal-=1;
        nilaiAcak = Random.Range(nomerSoal, kurangSoal);
         
            noSoal.text = ""+kurangSoal;
            // nomerSoal-=1;
            textSoal.text = exam[nilaiAcak].soal;
    }


    IEnumerator tambahData(string NIS, string n_quiz1)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("NIS", NIS);
        form.AddField("n_quiz1", n_quiz1);
        
    

        using (UnityWebRequest www = UnityWebRequest.Post(api.updateNilai1, form))
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
                profilInfo["n_quiz1"] = n_quiz1;
                string test = profilInfo["n_quiz1"];
                Debug.Log(test);

            }
        }
    }



    IEnumerator liatSoal()
    {
        WWWForm form = new WWWForm();
        //form.AddField("nim", nim);
        using (UnityWebRequest www = UnityWebRequest.Get(api.listSoal))
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



                for (int i = 0; i < 20; i++)
                {
                    profilInfo = jsonArrayString[i].AsObject;
                    exam[i].soal = profilInfo["soal"];
                    exam[i].jawaban = profilInfo["jawaban"];
                    //exam[i].quiz = profilInfo["quiz"];
                }

            }
        }
    }


}
