using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private MaterialProperties[] materials;
    [SerializeField] private Material material;

    public void ChangeMaterialTexture(MaterialProperties newMaterial)
    {
        material.SetTexture("_MainTex", newMaterial.texture);
        material.SetTexture("_BumpMap", newMaterial.normalMap);
        ChangeMaterialColor(Color.white);
    }
    public void ChangeMaterialColor(Color newColor)
    {
        material.color = newColor;
    }
}

[Serializable]
public struct MaterialProperties
{
    public Texture texture;
    public Texture normalMap;
}
