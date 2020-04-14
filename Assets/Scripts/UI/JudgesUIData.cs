using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "ScriptableObjects/JudgesUIData")]
    public class JudgesUIData : ScriptableObject
    {
        public string[] countries = new string[5];
    }
}
