using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visiontrapscript : MonoBehaviour
{
    public Animator scenetransitionanim;
    public GameObject pic1;
    public GameObject pic2;
    public GameObject pic3;
    public GameObject pic4;
    public GameObject pic5;
    public GameObject pic6;
    public GameObject pic7;
    public GameObject pic8;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VisionShrink() {
        pic1.SetActive(true);
        pic2.SetActive(true);
        pic3.SetActive(true);
        pic4.SetActive(true);
        pic5.SetActive(true);
        pic6.SetActive(true);
        pic7.SetActive(true);
        pic8.SetActive(true);
        scenetransitionanim.SetBool("VisionTraptriggered",true);
        StartCoroutine(Wait()); //pocakaj 5s
    }

    public void VisionShrinkEnd()
    {
        scenetransitionanim.SetBool("VisionTrapEnded",true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
        scenetransitionanim.SetBool("VisionTraptriggered", false);
        yield return new WaitForSeconds(0.7f);
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
        pic6.SetActive(false);
        pic7.SetActive(false);
        pic8.SetActive(false);
    }
}
