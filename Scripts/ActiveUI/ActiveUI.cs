using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUI : MonoBehaviour
{
    public bool isActive;
    private void OnTriggerStay2D(Collider2D other)
    {

        Debug.Log("isACtive");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("unActice");
    }
}
