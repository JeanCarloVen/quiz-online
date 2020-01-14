using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    public InputField passwordField;
    public InputField usernameField;
    public Text infoLogin;
    public GameObject popup;
    string url = "http://192.168.42.199/sinsen/login.php";
    void Start()
    {
        anim.SetBool("login",false);
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _loginAwal(){
        anim.SetBool("login",true);
    }

    public void LoginAkun(){
        Debug.Log("Username = "+usernameField.text);
        Debug.Log("Password = "+passwordField.text);

        StartCoroutine(login(usernameField.text , passwordField.text));
    }



    IEnumerator login(string nim , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("nim", nim);
        form.AddField("password", password);
        // profilData.setNim(nim);
        // profilData.setPassword(password);
    //    dataProfil.nimProfil = nim;

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
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
                
                if(json == "berhasil"){
                    Debug.Log("berhasil");
                    infoLogin.text = "Berhasil Login";
                    SceneManager.LoadScene("MenuUtama");
                    Data.getInstance().setNim(usernameField.text);
                    Data._nim = usernameField.text;

                }else if(usernameField.text == ""){
                    popup.SetActive(true);
                    infoLogin.text = "Masukkan NIM!";
                    Debug.Log("Masukkan NIM!");
                }else if(passwordField.text == ""){
                    popup.SetActive(true);
                    infoLogin.text = "Masukkan Password!";
                    Debug.Log("Masukkan Password");
                }else if(json == "gagal"){
                     popup.SetActive(true);
                     infoLogin.text = "NIM atau Password anda salah";
                    Debug.Log("NIM atau Password anda salah");
                }

            }
        }
    }

    public void okPop(){
        popup.SetActive(false);
    }
}
