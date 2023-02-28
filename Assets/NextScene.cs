using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("LoadScene", 2);
    }

    public void LoadScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
