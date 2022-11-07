using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] bool Forward;
    [SerializeField] bool Backward;
    Animator treeAnim;

    // Start is called before the first frame update
    void Start()
    {
        treeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Forward = true;
            Backward = false;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Backward = true;
            Forward = false;
        }
    }

    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        
        if (Forward && !Backward)
        {
            treeAnim.SetTrigger("Forward");
        }
        else if (Backward && !Forward)
        {
            treeAnim.SetTrigger("Backward");
        }
    }
}
