using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeoutAudio : MonoBehaviour
{
    IEnumerator stopTheAudio()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
