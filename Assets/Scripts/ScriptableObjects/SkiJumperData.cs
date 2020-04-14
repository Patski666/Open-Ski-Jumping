using Competition;
using Competition.Persistent;
using UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class SkiJumperData : ScriptableObject
    {
        public Gender gender;
        public Color helmetColor;
        public Color suitTopFrontColor;
        public Color suitTopBackColor;
        public Color suitBottomFrontColor;
        public Color suitBottomBackColor;
        public Color skisColor;
        public void Set(Competitor competitorData)
        {
            gender = competitorData.gender;
            helmetColor = SimpleColorPicker.Hex2Color(competitorData.helmetColor);
            suitTopFrontColor = SimpleColorPicker.Hex2Color(competitorData.suitTopFrontColor);
            suitTopBackColor = SimpleColorPicker.Hex2Color(competitorData.suitTopBackColor);
            suitBottomFrontColor = SimpleColorPicker.Hex2Color(competitorData.suitBottomFrontColor);
            suitBottomBackColor = SimpleColorPicker.Hex2Color(competitorData.suitBottomBackColor);
            skisColor = SimpleColorPicker.Hex2Color(competitorData.skisColor);
        }
    }
}