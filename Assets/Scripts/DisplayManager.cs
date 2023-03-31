using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// V1.0
/// Manager to handle UI elements and values to display
/// </summary>
 
//V1.1 Updates --> N/A
public class DisplayManager : MonoSingleton<DisplayManager>
{
    [SerializeField]
    private TextMeshProUGUI _displayText;
    private string _equation;


    /// <summary>
    /// Adds the numerical button value to the display
    /// </summary>
    /// <param name="newText">Value assigned to the button</param>
    public void UpdateDisplayText(string newText)
    {
        _equation += newText;
        _displayText.SetText(_equation);
    }
    /// <summary>
    /// Clears the value of the number on the display
    /// </summary>
    public void ClearDisplay()
    {
        _equation = "";
        _displayText.SetText(_equation);
    }
    public void ClearEquation()
    {
        _equation = "";
    }
    /// <summary>
    /// Displays the result of the most recent solution the calculator solved
    /// </summary>
    /// <param name="result"> the answer to our equation found within the CalculatorManager</param>
    public void DisplayAnswer(float result)
    {
        string resultString = result.ToString();
        _displayText.SetText(resultString);
    }
}

