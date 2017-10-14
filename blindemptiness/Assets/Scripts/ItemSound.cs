using UnityEngine;

[System.Serializable]
public class ItemSound
{
    public string itemSoundPath;
    public string itemSoundName;
    public AudioClip ItemAudioClip()
    {
        var sounds = Resources.LoadAll<AudioClip>(itemSoundPath);
        foreach (var s in sounds)
        {
            if (s.name == itemSoundName)
            {
                return s;
            }
        }
        return null;
    }

    public ItemSound(string itemSoundPath, string itemSoundName)
    {
        this.itemSoundName = itemSoundName;
        this.itemSoundPath = itemSoundPath;
    }
}



