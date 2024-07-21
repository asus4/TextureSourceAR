using UnityEngine;

public sealed class GlobalTextureListener : MonoBehaviour
{
    [System.Serializable]
    public class TextureEvent : UnityEngine.Events.UnityEvent<Texture> { }

    public string globalTextureName;
    public TextureEvent onTexture;


    private int globalTextureID;

    private void Start()
    {
        globalTextureID = Shader.PropertyToID(globalTextureName);
    }

    private void Update()
    {
        var tex = Shader.GetGlobalTexture(globalTextureID);
        onTexture.Invoke(tex);
    }
}
