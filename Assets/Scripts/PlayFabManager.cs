using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;


    //Register/Login/ResetPassword
    #region Buttom Functions
    public void RegisterUser()
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


    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {

            Email = emailInput.text,
            Password = passwordInput.text,
        
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {

            Email = emailInput.text,
            TitleId = "C5719",

        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnError);
    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Recovery Mail Sent";
    }



    void OnRegisterSuccess(RegisterPlayFabUserResult Result) {
        messageText.text = "New account is created!";
    }

    void OnLoginSuccess(LoginResult Result)
    {
        SceneManager.LoadSceneAsync(1);
    }

    void OnError(PlayFabError Error)
    {
        messageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame




    /*                   CLASSIFICA    
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
    */
    #endregion

}
