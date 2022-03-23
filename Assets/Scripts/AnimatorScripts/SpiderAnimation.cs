using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimation : MonoBehaviour
{
    private Animator SpiderAnimator;
    void Start()
    {
        SpiderAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpiderAnimator.SetBool("Idle", false);
            SpiderAnimator.SetBool("Attack", true);
        }
        }
}
