using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MaterialSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI materialName;
    [SerializeField] Transform imagesParent;
    [SerializeField] TextureButton texturePrefab;
    List<TextureButton> textures = new List<TextureButton>();
    [SerializeField] ChangeMaterial startMaterial;
    private void Start()
    {
        SetMaterial(startMaterial);
    }
    public void SetMaterial(ChangeMaterial changeMaterial)
    {
        materialName.text = "Objeto: " + changeMaterial.Material.name;
        foreach (TextureButton textureButton in textures)
        {
            textureButton.Button.onClick.RemoveAllListeners();
            Destroy(textureButton);
        }
        textures.Clear();

        for (int i = 0; i < changeMaterial.Textures.Length; i++)
        {
            TextureButton newTexture = Instantiate(texturePrefab, imagesParent);
            newTexture.Textures = changeMaterial.Textures[i];
            newTexture.Image.texture = newTexture.Textures.texture;
            newTexture.Button.onClick.AddListener(() => changeMaterial.ChangeMaterialTexture(newTexture.Textures));
            textures.Add(newTexture);
        }
    }
}
