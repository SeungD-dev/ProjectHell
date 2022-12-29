using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public GameObject questionPanel;

    // Start is called before the first frame update
    void Start()
    {
        questionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.gameObject.name == "Question")
            {
                questionPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OkButton()
    {
        questionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
