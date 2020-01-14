using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data instance;
    public static string _nim="";
    string nama,nim, kelas, nilai1 , nilai2 , nilai3 , nilai4, password;

    public void setNama(string nama){
        this.nama = nama;
    }
    public string getNama(){
        return nama;
    }

    public void setNim(string nim){
        this.nim = nim;
    }
    public string getNim(){
        return nim;
    }

    public void setKelas(string kelas){
        this.kelas = kelas;
    }
    public string getKelas(){
        return kelas;
    }

    public void setPassword(string password){
        this.password = password;
    }
    public string getPassword(){
        return password;
    }

    public void setNilai1(string nilai1){
        this.nilai1 = nilai1;
    }
    public string getNilai1(){
        return nilai1;
    }

    public void setNilai2(string nilai2){
        this.nilai2 = nilai2;
    }
    public string getNilai2(){
        return nilai2;
    }

    public void setNilai3(string nilai3){
        this.nilai3 = nilai3;
    }
    public string getNilai3(){
        return nilai3;
    }

    public void setNilai4(string nilai4){
        this.nilai4 = nilai4;
    }
    public string getNilai4(){
        return nilai4;
    }


    void Start(){
        instance = this;
    }

    public static Data getInstance(){
        return instance;
    }
}
