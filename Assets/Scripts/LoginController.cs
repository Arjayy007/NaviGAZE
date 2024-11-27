using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class LoginController: MonoBehaviour
{
  void Start()
  {
    Login();
  }

  void Login()
  {
    var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
    PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
  }

  void OnLoginSuccess(LoginResult result)
  {
    Debug.Log("Congratulations, you made your first successful API call!");
  }

  void OnLoginFailure(PlayFabError error)
  {
    Debug.LogWarning("Something went wrong with your first API call.  :(");
    Debug.LogError("Here's some debug information:");
    Debug.LogError(error.GenerateErrorReport());
  }

}
