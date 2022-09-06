using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СhangesСolor : MonoBehaviour
{
    private Material material; 

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        //material.EnableKeyword("OVERLAY_ON");
    }

    /// <summary>
    /// Мигание цвета
    /// </summary>
    /// <returns></returns>
    public IEnumerator Color()
    {
        yield return new WaitForSeconds(0.1f);
        material.EnableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.DisableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.EnableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.DisableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.EnableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.DisableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.EnableKeyword("OVERLAY_ON");
        yield return new WaitForSeconds(0.1f);
        material.DisableKeyword("OVERLAY_ON");
    }
}
