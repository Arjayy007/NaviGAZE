using UnityEngine;
// RegistrationData.cs
public class RegistrationData
{
    public string LastName;
    public string FirstName;
    public string StudentNumber;
    public string CollegeDepartment;
    public string CollegeProgram;
    public string YearAndSection;
    public string Email;
    public string Password;
    public string ConfirmPassword;
    public string SubjectCode;
    public string Room;
    public string SubjectName;
    public string DayOfTheWeek;
    public string Campus;


    // You can add a constructor to initialize all fields if needed
    public RegistrationData()
    {
        LastName = string.Empty;
        FirstName = string.Empty;
        StudentNumber = string.Empty;
        CollegeDepartment = string.Empty;
        CollegeProgram = string.Empty;
        YearAndSection = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        SubjectCode = string.Empty;
        Room = string.Empty;
        SubjectName = string.Empty;
        DayOfTheWeek = string.Empty;
        Campus = string.Empty;
    }
}
