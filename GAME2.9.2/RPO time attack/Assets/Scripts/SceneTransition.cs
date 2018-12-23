using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator scenetransitionanim;
    public GameObject pic1;
    public GameObject pic2;
    public GameObject pic3;
    public GameObject pic4;
    private int indxofscene;

    // Start is called before the first frame update
    void Start()
    {
        pic1.SetActive(true);
        pic2.SetActive(true);
        pic3.SetActive(true);
        pic4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {
            TransitionToScene(1);
        }*/
    }

    public void TransitionToScene(int sceneindex) {
        indxofscene = sceneindex;
        scenetransitionanim.SetTrigger("TranzOUT");
    }

    public void onTransComplete() {
        SceneManager.LoadScene(indxofscene);
    }


}
