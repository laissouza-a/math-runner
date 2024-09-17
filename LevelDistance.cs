using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
  public GameObject DistanceDisplay;

  public int disRun;
  public bool addingDis = false;
  public float disDelay = 0.35f;
    void Update()
    {
        if (addingDis == false){
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis(){
        disRun+=1;
        DistanceDisplay.GetComponent<Text>().text=""+disRun;

        yield return new WaitForSeconds(0.35f);
        addingDis = false;
    }
}
