using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SoalManager : MonoBehaviour
{
    // Start is called before the first frame update
    int nomerSoal =0;
    [System.Serializable]
    public class SoalList
    {

        [TextArea(6,10)]
        [Header("Soal")]
        public string soal;

        [Header("Kunci Jawaban")]
        public bool A;
        public bool B, C, D;
        [Header("Array Jawaban")]
        public string jawabanBenar;

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
    string buatId = Data._nim+""+pilihQuiz.quiz;
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
    void OnGUI()
    {
     
           // Do stuff.
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
        StartCoroutine(tambahData(buatId , Data._nim , pilihQuiz.quiz , hasil));
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
        
            if(jawab[0]._pilih == exam[0].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[1]._pilih == exam[1].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[2]._pilih == exam[2].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[3]._pilih == exam[3].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[4]._pilih == exam[4].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[5]._pilih == exam[5].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[6]._pilih == exam[6].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[7]._pilih == exam[7].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[8]._pilih == exam[8].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[9]._pilih == exam[9].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[10]._pilih == exam[10].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[11]._pilih == exam[11].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[12]._pilih == exam[12].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[13]._pilih == exam[13].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[14]._pilih == exam[14].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[15]._pilih == exam[15].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[16]._pilih == exam[16].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[17]._pilih == exam[17].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[18]._pilih == exam[18].jawabanBenar){benar+=1;}else{salah+=1;}
            if(jawab[19]._pilih == exam[19].jawabanBenar){benar+=1;}else{salah+=1;}
    }

    public void pilihJawaban(string pilih){
        jawab[nomerSoal]._pilih = pilih;

        
        // if(exam[0].jawabanBenar == jawab[0]._pilih){
        //     hasil +=10;
        // }else{
        //     hasil-=5;
        // }
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


    IEnumerator tambahData(string id, string nim , string info , int hasilQuiz)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("nim", nim);
        form.AddField("info", info);
        form.AddField("hasilQuiz",hasilQuiz);
    

        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.42.199/sinsen/tambahData.php", form))
        {
            // string data = JsonUtility.FromJson(www);
            //int value = 1;
            
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                
            }
            else
            {
                
            }
        }
    }


}
