using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprikes : MonoBehaviour
{
    private Animator _anim;
    private static readonly int Show = Animator.StringToHash("SpikesShow");
    private static readonly int Remove = Animator.StringToHash("SpikesRemove");

    private void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        while (true)
        {
            _anim.CrossFade(Show, 0, 0);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
            _anim.CrossFade(Remove, 0, 0);
        }
    }
}
