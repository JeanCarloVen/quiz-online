using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtama : MonoBehaviour
{
    public void Exams(){
        SceneManager.LoadScene("pilihQuiz");
    }

    public void Profil(){
        SceneManager.LoadScene("Profil");
    }
}
