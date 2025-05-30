using BepInEx;
using UnityEngine;

[BepInPlugin("com.yourname.iistupidmod", "ii's Stupid Mod Menu", "1.0.0")]
public class IIsStupidModPlugin : BaseUnityPlugin
{
    private void OnEnable()
    {
        GameObject modObject = new GameObject("IIsStupidModMenu");
        modObject.AddComponent<IIsStupidModMenu>();
        DontDestroyOnLoad(modObject);
    }
}