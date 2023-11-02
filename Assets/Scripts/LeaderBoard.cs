using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    public List<TextMeshProUGUI> names;

    [SerializeField]
    public List<TextMeshProUGUI> scores;
    private string publicLeaderboardKey = "25e6739a78964be25f8dfd8a6f5fb99e4733adc88fcf0d55962a33ca0fc74b0e";
    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {

            for (int i = 0; i < names.Count; ++i)
            {

                int loopLength = (msg.Length > names.Count) ? msg.Length : names.Count;
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }
    public void SetLeaderboardEntry(string Username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, Username, score, ((msg) => {
            Username.Substring(0, 5);
            GetLeaderboard();
        }));
    }
}