using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Level")]
    public class LevelData : ScriptableObject
    {
        Loader.Scene nextLevel;
    }
}