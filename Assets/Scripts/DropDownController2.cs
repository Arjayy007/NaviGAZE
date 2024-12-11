using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class DropDownController2 : MonoBehaviour
{

    
    public TMP_Dropdown campus;
    public TMP_Dropdown daysOfTheWeek;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         PopulateCampusDropdown();
        PopulateDaysOfTheWeekDropdown();
    }

   public void PopulateCampusDropdown(){
    // Example campuses
    List<string> campuses = new List<string> { "North Congress", "Camarin", "Bagong Silang" };
    campus.ClearOptions();
    campus.AddOptions(campuses);
}
   public void PopulateDaysOfTheWeekDropdown(){
    // Example days of the week
    List<string> Days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    daysOfTheWeek.ClearOptions();
    daysOfTheWeek.AddOptions(Days);
}

}
