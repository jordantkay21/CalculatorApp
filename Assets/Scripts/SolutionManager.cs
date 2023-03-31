using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// V1.1
/// Manager to store recent solutions
/// </summary>
public class SolutionManager : MonoSingleton<SolutionManager>
{
    public TextMeshProUGUI[] StackTextboxes;
    public string[] _solutionArray = new string[5];

    private Stack<string> stackSolution = new();

    private string _result;

    /// <summary>
    /// Adds the most recent equation to our stack<> to be displayed
    /// </summary>
    /// <param name="result"> most recent equation</param>
    public void AddToStack(string result)
    {
        _result = result;

        stackSolution.Push(_result);
        UpdateTheLabels();
        AddToArray();
    }
    /// <summary>
    /// Resets the value of our text boxes to the current values in our Stack<>
    /// </summary>
    private void UpdateTheLabels()
    {
        int index = 0;
        ResetTextboxes(StackTextboxes);
        foreach (string result in stackSolution)
        {
            StackTextboxes[index].text = result;
            index++;
            if (index > 5)
                break;
        }
    }
    /// <summary>
    /// Adds the most recent equation to our array
    /// </summary>
    private void AddToArray()
    {
        int index = 0;
        foreach (string result in stackSolution)
        {
            _solutionArray[index] = result;
            index++;
            if (index > 5)
                break;
        }
    }
    /// <summary>
    /// Sets the value of our button to the result of the matching equation.
    /// </summary>
    /// <param name="value">Index of our soultionArray</param>
    public void GetSolution(int value)
    {
        /*This method takes the equation and splits it into 2 where the "=" is
          Then sends the result (equation[1]) to our buttonManager */

        string[] equation = _solutionArray[value].Split('=');
        ButtonManager.Instance.AddValue(equation[1]);
    }
    /// <summary>
    /// Changes textbox display to null
    /// </summary>
    /// <param name="textboxes">The array holding the textboxes</param>
    private void ResetTextboxes(TextMeshProUGUI[] textboxes)
    {
        foreach (TextMeshProUGUI text in textboxes)
            text.text = "";
       
    }
    /// <summary>
    /// Emptys Stack<> and UI display
    /// </summary>
    public void ClearStack()
    {
        ResetTextboxes(StackTextboxes);
        stackSolution.Clear();
    }

                

    


}
