using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testable : MonoBehaviour
{
    public Animator animator;
    public float delay;
    public void Cast()
    {
        StartCoroutine(Enumerator());
    }
    IEnumerator Enumerator()
    {
        animator.SetBool("Start", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("Start", false);
    }

}
