using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite _imageFullHealth;
    public Sprite _imageIncompleteHealth;
    public List<Image> images = new List<Image>();

    private int index;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            images[i].sprite = _imageFullHealth;
            index = i;
        }
    }

    public void DepriveImageHealth()
    {
        if(index > 0)
        {
            for (int i = 0; i < images.Count; i++)
            {
                if(images[i].sprite == _imageFullHealth)
                {
                    images[i].sprite = _imageIncompleteHealth;
                    index--;
                    break;
                }
            }
        }
    }

    public void AddImageHealth()
    {
        if(index < 3)
        {
            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].sprite == _imageIncompleteHealth)
                {
                    images[i].sprite = _imageFullHealth;
                    index++;
                    break;
                }
            }
        }
    }
}
