using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllIn1SpriteShader;

public class TestShader : MonoBehaviour
{
    public AllIn1Shader shader;

    public Material material;

    private void Start()
    {
         material = GetComponent<Renderer>().material;
        material.EnableKeyword("OVERLAY_ON");
    }

    private void TestFicha()
    {
        
    }
}
