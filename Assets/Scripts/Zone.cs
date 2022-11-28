using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//polymorphism is the concept of inheritance which means in OOP its the same thing
public abstract class Zone : MonoBehaviour
{
    protected int isDeactivating = 0;
    protected bool isDisableRenderer = false;
    protected abstract void ZoneTrigger(GameObject marble);

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.activeSelf) return;

        if (other.CompareTag("Marble"))
        {
            ZoneTrigger(other.gameObject);
        }
    }

    protected IEnumerator DisableWithDelay(GameObject go, float delay, float returnDelay, bool isDisableRenderer = false)
    {
        isDeactivating++;
        yield return new WaitForSeconds(delay);
        if (isDisableRenderer)
        {
            go.GetComponent<MeshRenderer>().enabled = false;
            go.GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(returnDelay);
            go.GetComponent<MeshRenderer>().enabled = true;
            go.GetComponent<Collider>().enabled = true;
        }
        else
        {
            go.SetActive(false);
            yield return new WaitForSeconds(returnDelay);
            go.SetActive(true);
        }
        isDeactivating--;
    }

    protected IEnumerator DisableWithDelay(GameObject go, float delay = 1f)
    {
        isDeactivating++;
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
        isDeactivating--;
    }
}
