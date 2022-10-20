using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;

    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private GameObject _hightlight;

    public void Init(bool isOffset)
    {
        _renderer.material.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _hightlight.SetActive(true);
    }
    void OnMouseExit()
    {
        _hightlight.SetActive(false);
    }
}
