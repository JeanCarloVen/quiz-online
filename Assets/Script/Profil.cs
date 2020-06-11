using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System;
using UnityEngine.Networking;
using System.IO;
using SimpleJSON;


//namespace API {
    public class Profil : MonoBehaviour
    {
        // Start is called before the first frame update
        public Text nama, kelas, jenisKelamin, hasil1, hasil2;
        public Sprite laki, perempuan;
        public GameObject panelHasil;
        public RawImage foto;
        public string test = "http://10.146.153.29/sinsen/quiz/saya.jpg";


        int a = 0;
        API api = new API();
        //Action<string> _infoProfil;

        [System.Serializable]
        public class ListProfil
        {
            public string _nama;
            public string _kelas;
            public string _JenisKelamin;
            public string _hasil1;
            public string _hasil2;
            public string urlFoto;
        }

        public List<ListProfil> profil;
        void Start()
        {
            panelHasil.SetActive(false);
        }
        void Update()
        {
        StartCoroutine(viewProfil(Data._nim));
        StartCoroutine(viewFoto());

            nama.text = profil[0]._nama;
            kelas.text = profil[0]._kelas;
            hasil1.text = profil[0]._hasil1;
            hasil2.text = profil[0]._hasil2;

            if (profil[0]._JenisKelamin == "1")
            {
                jenisKelamin.text = "Laki-laki";
            }
            else if (profil[0]._JenisKelamin == "0")
            {
                jenisKelamin.text = "Perempuan";
            }


            if (Input.GetKey(KeyCode.Escape))
            {
                if (a == 0)
                {
                    SceneManager.LoadScene("MenuUtama");
                }
                else if (a == 1)
                {
                    panelHasil.SetActive(false);
                    a = 0;
                }
            }




        }
        public void Buttonklik()
        {
            panelHasil.SetActive(true);

            a = 1;
        }
        public void backKlik()
        {
            panelHasil.SetActive(false);
            a = 0;
        }

        IEnumerator viewProfil(string Nis)
        {
            WWWForm form = new WWWForm();

            form.AddField("NIS", Nis);

            using (UnityWebRequest www = UnityWebRequest.Get(api.lihatProfil + "?NIS=" + Nis))
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

                    Debug.Log(jsonArray);
                    profil[0]._nama = profilInfo["nama_siswa"];
                    profil[0]._JenisKelamin = profilInfo["jk"];
                    profil[0]._kelas = profilInfo["kelas"];
                    profil[0]._hasil1 = profilInfo["n_quiz1"];
                    profil[0]._hasil2 = profilInfo["n_quiz2"];
                    profil[0].urlFoto = "http://10.146.153.29/sinsen/quiz/" + profilInfo["foto"];

                }
            }
        }

        
        IEnumerator viewFoto()
        {
        WWW testing = new WWW(profil[0].urlFoto);
        yield return testing;
        foto.texture = testing.texture;
    }
    
}
