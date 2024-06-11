using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private MaterialProperties[] textures;
    [SerializeField] MaterialSelector materialSelector;
    public string MaterialName { get => _renderer.sharedMaterial.name; }
    public MaterialProperties[] Textures { get => textures; }
    XRBaseInteractable xrBaseInteractable;

    Renderer _renderer;
    private void Start()
    {
        xrBaseInteractable = GetComponent<XRBaseInteractable>();
        xrBaseInteractable.activated.AddListener(ObjectSelected);
        _renderer = GetComponent<Renderer>();
    }
    private void OnDestroy()
    {
        xrBaseInteractable.activated.RemoveListener(ObjectSelected);
    }
    public void ObjectSelected(ActivateEventArgs activateEventArgs)
    {
        materialSelector.SetMaterial(this);
    }
    public void ChangeMaterialTexture(MaterialProperties newMaterial)
    {
        Debug.Log("ChangeMaterial");
        _renderer.sharedMaterial.SetTexture("_BaseMap", newMaterial.texture);
        _renderer.sharedMaterial.SetTexture("_BumpMap", newMaterial.normalMap ? newMaterial.normalMap : null);
        _renderer.sharedMaterial.EnableKeyword("_NORMALMAP");
        ChangeMaterialColor(Color.white);
    }
    public void ChangeMaterialColor(Color newColor)
    {
        _renderer.sharedMaterial.color = newColor;
    }
}

[Serializable]
public struct MaterialProperties
{
    public Texture texture;
    public Texture normalMap;
}
