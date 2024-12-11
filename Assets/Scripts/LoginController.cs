using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;




public class LoginController: MonoBehaviour
{
  [Header("UI Elements")]
public TMP_InputField studentNumber;
public TMP_InputField password;
public TMP_InputField confirmPassword;



  void Start()
  {

  }

public void RegisterButton(){
   var request = new RegisterPlayFabUserRequest{
      Username = studentNumber.text,
      Password = password.text,
      RequireBothUsernameAndEmail = false
   };
   if(password.text != confirmPassword.text){
       Debug.Log("Passwords do not match");
       return;
   }
   PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
}

void OnRegisterSuccess(RegisterPlayFabUserResult result){
    Debug.Log("User registered successfully");
}
void OnRegisterFailure(PlayFabError error){
    Debug.Log("Error while registering user");
    Debug.Log(error.GenerateErrorReport());
}


public void LoginStudent(){

  bool isEmail = studentNumber.text.Contains("@");

  if (isEmail){
   var emailRequest = new LoginWithEmailAddressRequest{
      Email = studentNumber.text,
      Password = password.text
   };
  PlayFabClientAPI.LoginWithEmailAddress(emailRequest, OnLoginSuccess, OnLoginFailure);
}else{
  var usernameRequest = new LoginWithPlayFabRequest{
    Username = studentNumber.text,
    Password = password.text
  };
  PlayFabClientAPI.LoginWithPlayFab(usernameRequest, OnLoginSuccess, OnLoginFailure);
}

}


  public void GuestLogin()
  {
    var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
    PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
  }

  void OnLoginSuccess(LoginResult result)
  {
    Debug.Log("You are logged in!");
  }

  void OnLoginFailure(PlayFabError error)
  {
    Debug.LogWarning("Something went wrong with your first API call.  :(");
    Debug.LogError("Here's some debug information:");
    Debug.LogError(error.GenerateErrorReport());
  }

}
