using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
   private int waitTime  =7;
    void Start()
    {
        StartCoroutine(nameof(introScene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator introScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }
}
