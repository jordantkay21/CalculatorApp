using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolutionManager : MonoSingleton<SolutionManager>
{
    public TextMeshProUGUI[] StackTextboxes;
    public string[] _solutionArray = new string[5];

    private Stack<string> stackSolution = new();

    private string _result;

    public void AddToStack(string result)
    {
        _result = result;

        stackSolution.Push(_result);
        UpdateTheLabels();
    }

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
        foreach (string result in stackSolution)
        {
            _solutionArray[index] = result;
        }
    }

    public void GetSolution(int value)
    {
        Debug.Log("being called");
        string[] equation = _solutionArray[value].Split('=');
        ButtonManager.Instance.AddValue(equation[1]);

        Debug.Log("_solutionArray["+value+"] is..." + _solutionArray[value]);

    }

    private void ResetTextboxes(TextMeshProUGUI[] textboxes)
    {
        foreach (TextMeshProUGUI text in textboxes)
            text.text = "";
       
    }

    public void ClearStack()
    {
        ResetTextboxes(StackTextboxes);
        stackSolution.Clear();
    }

                

    


}
