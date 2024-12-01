using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DropdownController : MonoBehaviour
{
   [Header("Dropdown Elements")]
   public TMP_Dropdown collegeDepartment;
   public TMP_Dropdown collegeProgram;

   [Header("College and Programs")]
   public Dictionary<string, List<string>> departmentPrograms = new Dictionary<string, List<string>>{
        {"Select College", new List<string>{"Select Program"}},
       {"College of Liberal Arts and Sciences", new List<string>{
        "Select Program",
        "BS Computer Science", 
        "BS Information System", 
        "BS Entertainment and Multimedia Computing",
        "BS Information Technology",
        "BS Psychology",
        "AB Political Science",
        "BA Communication",
        "BS Public Administration",
        "BS Mathematics"}},

        {"College of Business and Accountancy", new List<string>{
        "Select Program",
        "BS Accounting Information System",
        "BSBA Financial Management",
        "BSBA marketing Management",
        "BSBA Human Resource",
        "BS Entrepreneurship",
        "BS Hospitality Management",
        "BS Tourism Management",
        "BS Office Administration"}},
        
        {"College of Education", new List<string>{
        "Select Program",
        "BEED Special Education", 
        "BSE English", 
        "BSE English-Chinese",
        "BSE Science",
        "BSE TLE",
        "Bachelor of Early Childhood Education"}}
    };


    void Start()
    {
         PopulateCollegeDepartment();

        // Add listener for department dropdown
        collegeDepartment.onValueChanged.AddListener(OnCollegeDepartmentChanged);

        // Initialize Program Dropdown based on the first department
        OnCollegeDepartmentChanged(0);
    }

    public void PopulateCollegeDepartment(){
        collegeDepartment.options.Clear();
        foreach (var department in departmentPrograms.Keys){
            collegeDepartment.options.Add(new TMP_Dropdown.OptionData(department));
        }
        collegeDepartment.RefreshShownValue();
    }

    public void OnCollegeDepartmentChanged(int departmentIndex){
       
        string selectedDepartment = collegeDepartment.options[departmentIndex].text;
       
       if (departmentPrograms.TryGetValue(selectedDepartment, out List<string> programs)){
         collegeProgram.options.Clear();
           foreach (var program in programs){
               collegeProgram.options.Add(new TMP_Dropdown.OptionData(program));
           }
           collegeProgram.RefreshShownValue();
       }
    }
    
}
