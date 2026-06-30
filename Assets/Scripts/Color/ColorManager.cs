using System.Collections.Generic;
using UnityEngine;
using Moblik.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorSetups.Find(i => i.artType == artType);

        for (int mat = 0; mat < materials.Count; mat++)
        {
            materials[mat].SetColor("_Color", setup.colors[mat]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}