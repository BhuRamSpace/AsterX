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
    private static PlayFabManager instance;



    public static PlayFabManager Instance
    {
        get
        {
            // Se l'istanza non è stata ancora creata, crea un'istanza nuova
            if (instance == null)
            {
                // Trova l'oggetto PlayFabManager nella scena o crea uno nuovo se non esiste
                instance = FindObjectOfType<PlayFabManager>();

                // Se non esiste, crea un nuovo oggetto PlayFabManager nella scena
                if (instance == null)
                {
                    GameObject obj = new GameObject("PlayFabManager");
                    instance = obj.AddComponent<PlayFabManager>();
                }
            }
            return instance;
        }
    }


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

    public bool IsLoggedIn()
    {
        return PlayFabClientAPI.IsClientLoggedIn();
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

    #endregion

}
