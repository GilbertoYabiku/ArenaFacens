using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public void CarregaChallenge1()
    {
        SceneManager.LoadScene("Challenge 1");
    }

    public void CarregaChallenge2()
    {
        SceneManager.LoadScene("Challenge 2");
    }

    public void CarregaChallenge()
    {
        SceneManager.LoadScene("Challenge");
    }
}
