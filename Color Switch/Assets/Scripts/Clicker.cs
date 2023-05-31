using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicker: MonoBehaviour
{
    [SerializeField] private string ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if(ob=="Play")
        {
            SceneManager.LoadScene("Level Select");
        }
        else if(ob=="Static")
        {
            SceneManager.LoadScene("Level 1");
        }
        else if(ob=="Dynamic")
        {
            SceneManager.LoadScene("D Lvl 1");
        }
        else if(ob=="ReplayStatic")
        {
            SceneManager.LoadScene("Level 1");
        }
        else if(ob=="ReplayDynamic")
        {
            SceneManager.LoadScene("D Lvl 1");
        }
        else if (ob=="Back")
        {
            SceneManager.LoadScene("Main Menu");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
