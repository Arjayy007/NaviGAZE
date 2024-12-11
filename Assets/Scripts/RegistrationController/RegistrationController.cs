using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class RegistrationController : MonoBehaviour
{
    [Header("Scene 1 Elements")]
    public TMP_InputField lastName;
    public TMP_InputField firstName;
    public TMP_InputField studentNumber;
    public TMP_Dropdown collegeDepartment;
    public TMP_Dropdown collegeProgram;
    public TMP_InputField yearAndSection;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField confirmPassword;

    [Header("Scene 2 Elements")]
    public TMP_InputField subjectCode;
    public TMP_InputField room;
    public TMP_InputField subjectName;
   
    public TMP_Dropdown campus;
    public TMP_Dropdown daysOfTheWeek;

     [Header("Table Elements")]
    public GameObject tableRowPrefab;  // Reference to the prefab of the table row
    public Transform tableContent; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            // Call this in Start or as needed
    }


    public void AddScheduleButton(){
         GameObject newRow = Instantiate(tableRowPrefab, tableContent);

        TMP_Text[] rowTexts = newRow.GetComponentsInChildren<TMP_Text>();

    
        rowTexts[0].text = subjectCode.text;  
        rowTexts[1].text = subjectName.text;  
        rowTexts[2].text = room.text;         
        rowTexts[3].text = daysOfTheWeek.options[daysOfTheWeek.value].text;  // Get selected text from the dropdown
        rowTexts[4].text = campus.options[campus.value].text;  // Get selected text from the dropdown


        subjectCode.text = "";
        room.text = "";
        subjectName.text = "";
        campus.value = 0;  // Reset dropdown to the first option
        daysOfTheWeek.value = 0;
 // Reset dropdown to the first option

    }

        public void SaveToPlayFab()
    {
        if (password.text != confirmPassword.text)
        {
            Debug.LogError("Passwords do not match!");
            return;
        }

        var registerRequest = new RegisterPlayFabUserRequest
        {
            Username = studentNumber.text,
            Password = password.text,
            Email = email.text,
            RequireBothUsernameAndEmail = true
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
{
    Debug.Log("User registered successfully!");

    // Prepare first set of data (10 keys)
    var updateRequest1 = new UpdateUserDataRequest
    {
        Data = new Dictionary<string, string>
        {
            { "LastName", lastName.text },
            { "FirstName", firstName.text },
            { "StudentNumber", studentNumber.text },
            { "CollegeDepartment", collegeDepartment.options[collegeDepartment.value].text },
            { "CollegeProgram", collegeProgram.options[collegeProgram.value].text },
            { "YearAndSection", yearAndSection.text }
        }
    };

    PlayFabClientAPI.UpdateUserData(updateRequest1, OnDataSaveSuccess, OnDataSaveFailure);

}


    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError($"Error registering user: {error.GenerateErrorReport()}");
    }

    private void OnDataSaveSuccess(UpdateUserDataResult result)
    {
        SceneManager.LoadScene("RegistrationPage2");
    }

  private void OnDataSaveFailure(PlayFabError error)
{
    Debug.LogError("Error saving user data: " + error.GenerateErrorReport());

    // Check for the 409 HTTP Conflict error
    if (error.HttpCode == 409) // HTTP 409 Conflict
    {
        Debug.Log("Conflict detected. Fetching latest data to resolve...");
  
    }
    else
    {
        Debug.LogError("An error occurred: " + error.ErrorMessage);
    }
}


}
