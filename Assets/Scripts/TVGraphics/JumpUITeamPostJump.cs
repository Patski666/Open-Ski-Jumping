using System.Globalization;
using DG.Tweening;
using OpenSkiJumping.Competition.Persistent;
using OpenSkiJumping.UI;
using TMPro;
using UnityEngine;

namespace OpenSkiJumping.TVGraphics
{
    public class JumpUITeamPostJump : PostJumpUIManager
    {
        public TMP_Text bibTeam;
        public TMP_Text bibJumper;
        public TMP_Text teamName;
        public TMP_Text jumperName;
        public TMP_Text rank;
        public TMP_Text totalTeam;
        public TMP_Text totalJumper;
        public TMP_Text[] meters;

        public CountryInfo countryInfo;

        [SerializeField] private RectTransform judgesMarksTransform;
        [SerializeField] private JudgesUIData judgesUIData;

        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private CanvasGroup canvasGroup;

        private void OnEnable()
        {
            InstantHide();
        }


        public void SetCountry()
        {
            int competitorId = resultsManager.currentStartList[resultsManager.startListIndex];
            Team team = competitors.teams[participants.participants[competitorId].id];
            countryInfo.FlagImage.sprite = flagsData.GetFlag(team.countryCode);
            countryInfo.CountryName.text = team.countryCode;
        }

        public override void Show()
        {
            canvasGroup.alpha = 1;
            SetCountry();

            rectTransform.localScale = new Vector3(0, 1, 1);
            judgesMarksTransform.localScale = new Vector3(1, 0, 1);
            DOTween.Sequence().Append(rectTransform.DOScaleX(1, 0.5f)).Append(judgesMarksTransform.DOScaleY(1, 0.5f));

            int jumpsCount = resultsManager.roundIndex + 1;
            int competitorId = resultsManager.currentStartList[resultsManager.startListIndex];
            int bib = resultsManager.results[competitorId].Bibs[resultsManager.roundIndex];
            int rank = resultsManager.results[competitorId].Rank;
            Competitor competitor = competitors.competitors[participants.participants[competitorId].competitors[resultsManager.subroundIndex]];
            Team team = competitors.teams[participants.participants[competitorId].id];
            JumpResults jumpResults = resultsManager.results[competitorId].Results[resultsManager.subroundIndex];

            teamName.text = team.teamName.ToUpper();
            jumperName.text = $"{competitor.firstName} {competitor.lastName.ToUpper()}";
            bibTeam.text = bib.ToString();
            bibJumper.text = (resultsManager.subroundIndex + 1).ToString();
            this.rank.text = rank.ToString();

            int xx = jumpsCount - meters.Length;
            int offset = Mathf.Max(0, meters.Length - jumpsCount);

            JumpResult jump = jumpResults.results[resultsManager.roundIndex];
            totalTeam.text = resultsManager.results[competitorId].TotalPoints.ToString("F1", CultureInfo.InvariantCulture);
            totalJumper.text = resultsManager.results[competitorId].TotalResults[resultsManager.subroundIndex].ToString("F1", CultureInfo.InvariantCulture);
            wind.SetValues(jump.windPoints);
            gate.SetValues(jump.gatePoints);

            for (int i = 0; i < judgesMarks.Length; i++)
            {
                judgesMarks[i].SetValues(jump.judgesMarks[i], judgesUIData.countries[i], flagsData.GetFlag(judgesUIData.countries[i]), jump.judgesMask[i]);
            }

            foreach (var item in meters)
            {
                if (0 <= xx)
                {
                    item.text = $"{jumpResults.results[xx].distance:F1} m";
                }
                else
                {
                    item.text = "";
                }
                xx++;
            }
            // listView.AddItem(new ResultData() { firstName = competitor.firstName, lastName = competitor.lastName.ToUpper(), result = (float)resultsManager.results[competitorId].TotalPoints });
            // listView.Items = listView.Items.OrderByDescending(item => item.result).ToList();
        }

        public override void Hide()
        {
            canvasGroup.DOFade(0, 0.5f);
        }

        public override void InstantHide()
        {
            canvasGroup.alpha = 0;
        }

    }
}
