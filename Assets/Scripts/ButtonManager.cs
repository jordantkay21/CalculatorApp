using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoSingleton<ButtonManager>
{
    [SerializeField]
    private GameObject _numKeyboard;
    [SerializeField]
    private GameObject _QueKeyboard;

    private bool _isNumKeyboard = true;

    #region NumericalKeyboard
    /// <summary>
    /// Pushes value of numerical button pressed to the equation 
    /// </summary>
    public void AddValue(string value)
    {
        CalculationManager.Instance.FillNum(value);
        DisplayManager.Instance.UpdateDisplayText(value);
    }
    /// <summary>
    /// Pushes value of operator button pressed to the equation
    /// </summary>
    public void AddOperator(string value)
    {
        CalculationManager.Instance.SetOperator(value);
        DisplayManager.Instance.UpdateDisplayText(value);
    }
    /// <summary>
    /// Pushes value of CLEAR button pressed to Managers
    /// </summary>
    public void Clear()
    {
        CalculationManager.Instance.ClearCalculator();
        DisplayManager.Instance.ClearDisplay();

    }
    /// <summary>
    /// Pushes value of EQUALS button pressed to Managers
    /// </summary>
    public void SolveEquation()
    {
        CalculationManager.Instance.EqualsPressed();
    }

    #endregion

    public void SwitchKeyboard()
    {
        if (_isNumKeyboard == true)
        {
            _numKeyboard.SetActive(false);
            _QueKeyboard.SetActive(true);
            _isNumKeyboard = false;
        }
        else
        {
            _numKeyboard.SetActive(true);
            _QueKeyboard.SetActive(false);
            _isNumKeyboard = true;
        }
    }

    #region QueueKeyboard

    //Button needs to...
    //Step One: grab current value of result
    //Step Two: fill current number of result
    //Step Three: display current number

    public void SetValue(int value)
    {
        SolutionManager.Instance.GetSolution(value);
    }
    #endregion
}