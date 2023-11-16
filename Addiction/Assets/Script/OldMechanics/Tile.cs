using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private GameObject saw, firePit, lightning;

    private void OnMouseEnter()
    {
        render.color = baseColor;

        if (ObjectManger.instance.isSawSelected == true)
        {
            saw.SetActive(true);
        }
        if (ObjectManger.instance.isLightningSelected == true)
        {
            lightning.SetActive(true);
        }
        if (ObjectManger.instance.isFirePitSelected == true)
        {
            firePit.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        render.color = offsetColor;
        saw.SetActive(false);
        firePit.SetActive(false);
        lightning.SetActive(false);

    }
}
