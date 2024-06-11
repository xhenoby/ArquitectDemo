using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private MaterialProperties[] textures;
    [SerializeField] private Material material;
    [SerializeField] MaterialSelector materialSelector;
    public Material Material { get => material; }
    public MaterialProperties[] Textures { get => textures; }
    XRBaseInteractable xrBaseInteractable;
    private void Start()
    {
        xrBaseInteractable = GetComponent<XRBaseInteractable>();
        xrBaseInteractable.firstSelectEntered.AddListener(ObjectSelected);
    }
    private void OnDestroy()
    {
        xrBaseInteractable.firstSelectEntered.RemoveListener(ObjectSelected);
    }
    public void ObjectSelected(SelectEnterEventArgs selectEnterEventArgs)
    {
        materialSelector.SetMaterial(this);
    }
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
