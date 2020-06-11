using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    public InputField passwordField;
    public InputField usernameField;
    public Text infoLogin;

    API api = new API();
    
    void Start()
    {
        anim.SetBool("login",false);
        //popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //network = GameObject.Find("ConnectionNetwork").GetComponent<NetworkManager>();
        //string ip = network.networkAddress;
        //string ip = nc.address;
        //Debug.Log(ip);


    }
    


    public void _loginAwal(){
        anim.SetBool("login",true);
    }

    public void LoginAkun(){
        Debug.Log("Username = "+usernameField.text);
        Debug.Log("Password = "+passwordField.text);

        StartCoroutine(login(usernameField.text , passwordField.text));
    }



    IEnumerator login(string NIS , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("NIS", NIS);
        form.AddField("pass", password);
        // profilData.setNim(nim);
        // profilData.setPassword(password);
    //    dataProfil.nimProfil = nim;

        using (UnityWebRequest www = UnityWebRequest.Post(api.Login , form))
        {
            // string data = JsonUtility.FromJson(www);
            //int value = 1;
            
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                Debug.Log(json);
                if(json == "berhasil"){
                    Debug.Log("berhasil");
                    infoLogin.color = Color.green;
                    infoLogin.text = "Berhasil Login";
                    SceneManager.LoadScene("MenuUtama");
                    Data.getInstance().setNim(usernameField.text);
                    Data._nim = usernameField.text;

                }else if(usernameField.text == ""){
                    //popup.SetActive(true);
                    infoLogin.text = "Masukkan NIM!";
                    Debug.Log("Masukkan NIM!");
                }else if(passwordField.text == ""){
                    //popup.SetActive(true);
                    infoLogin.text = "Masukkan Password!";
                    Debug.Log("Masukkan Password");
                }else if(json == "gagal"){
                    //popup.SetActive(true);
                    infoLogin.fontSize = 100;
                     infoLogin.text = "NIM atau Password anda salah";

                }

            }
        }
    }

    //public void okPop(){
    //    popup.SetActive(false);
    //}
}
