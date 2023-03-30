using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolutionManager : MonoSingleton<SolutionManager>
{
    public TextMeshProUGUI[] StackTextboxes;

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
        ClearTextboxes(StackTextboxes);
        foreach (string result in stackSolution)
        {
            StackTextboxes[index].text = result;
            index++;
            if (index > 5)
                break;
        }
    }

    private void ClearTextboxes(TextMeshProUGUI[] textboxes)
    {
        foreach (TextMeshProUGUI text in textboxes)
            text.text = "";
    }

    public void ClearStack()
    {
        ClearTextboxes(StackTextboxes);
        stackSolution.Clear();
    }

                

    


}
