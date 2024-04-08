using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;


    //Register/Login/ResetPassword
    public void RegisterButton()
    {

        if(passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
    }


    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }


    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
      
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful Login/Account create!");
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }




    //                      CLASSIFICA    
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName ="PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10,
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);

        void OnLeaderboardGet(GetLeaderboardResult result)
        {
            foreach (var item in result.Leaderboard)
            {
                Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
            }
        }
    }
}
