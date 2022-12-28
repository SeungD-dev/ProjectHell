using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    private string name;
    public GameObject player;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        name = this.gameObject.name;
        // Debug.Log(this.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.gameObject.name == "err1")
            {
                player.transform.position = new Vector3(12, 0.75f, 0);
                camera.transform.position = new Vector3(20, 17, 0);
            }
            else if (this.gameObject.name == "err2" || this.gameObject.name == "current1")
            {
                player.transform.position = new Vector3(12, 0.75f, 40);
                camera.transform.position = new Vector3(20, 17, 40);
            }
            else if (this.gameObject.name == "err3" || this.gameObject.name == "current2")
            {
                player.transform.position = new Vector3(12, 0.75f, 80);
                camera.transform.position = new Vector3(20, 17, 80);
            }
            else if (this.gameObject.name == "err4" || this.gameObject.name == "current3")
            {
                player.transform.position = new Vector3(12, 0.75f, 120);
                camera.transform.position = new Vector3(20, 17, 120);
            }
            else if (this.gameObject.name == "err5" || this.gameObject.name == "current4")
            {
                player.transform.position = new Vector3(12, 0.75f, 160);
                camera.transform.position = new Vector3(20, 17, 160);
            }
            else if (this.gameObject.name == "current5")
            {

            }
        }
    }
}
