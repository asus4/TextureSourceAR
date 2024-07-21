using UnityEngine;
using UnityEngine.Events;

public sealed class GlobalTextureListener : MonoBehaviour
{
    [System.Serializable]
    public class TextureEvent : UnityEvent<Texture> { }
    [System.Serializable]
    public class AspectChangeEvent : UnityEvent<float> { }

    public string globalTextureName;
    public TextureEvent onTexture;
    public AspectChangeEvent onAspectChange;

    private int globalTextureID;

    private void Start()
    {
        globalTextureID = Shader.PropertyToID(globalTextureName);
    }

    private void Update()
    {
        var tex = Shader.GetGlobalTexture(globalTextureID);
        if (tex == null)
        {
            return;
        }
        onTexture.Invoke(tex);
        onAspectChange.Invoke((float)tex.width / tex.height);
    }
}
