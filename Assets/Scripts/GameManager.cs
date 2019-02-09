using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;


public class GameManager : MonoBehaviour {

    public bool isPaused = false;

    public GameObject painelCompleto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        painelCompleto.SetActive(false);
    }

    public void Pause()
    {
        painelCompleto.SetActive(true);
    }
}
