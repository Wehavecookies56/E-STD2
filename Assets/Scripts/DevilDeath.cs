using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilDeath : MonoBehaviour
{

    
    public float timer;
    public float time;
    private bool Dying = true;
    private float Decaying = -1f;
    public bool RunScritpt = false;
    List<GameObject> DevilParts = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            DevilParts.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RunScritpt == true)
        {

            if (timer <= 0)
            {
                
                if (Dying)
                {

                    gameObject.GetComponent<Animator>().SetBool("melting", true);
                    StartCoroutine(realdeath());
                   

                }
                else
                {
                    Decaying += Time.deltaTime;
                    if (Decaying < 0.8)
                    {
                        foreach (GameObject Part in DevilParts)
                        {
                            Part.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Time_Decay", Decaying);

                        }
                    }
                    else
                    {

                        StartCoroutine(Destoryer());
                    }

                   

                }

            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    IEnumerator Destoryer()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
    IEnumerator realdeath()
    {
        yield return new WaitForSeconds(1);
        Dying = false;
    }


}