using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    Animator anim;
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        anim.Play("Idle");
    }
    void Update()
    {
        
    }
}
