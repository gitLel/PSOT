using System;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    public const string SfxClick = "Click";
    

    [Serializable]
    public class Config
    {
        public List<AudioClip> AudioClips;
    }
}
