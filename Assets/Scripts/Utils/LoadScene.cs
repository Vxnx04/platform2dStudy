using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if(player.activeInHierarchy == false)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }

}
