using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// V1.0
/// Manager to handle all button functions
/// </summary>

//V1.1 Updates --> Cability to Switch between Keyboards & New method for recent solution buttons to be assigned to
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
    /// <summary>
    /// V1.1
    /// Switches UI Keybaord to either numerical or solutions
    /// Logic is held within DisplayManager
    /// </summary>
    public void SwitchKeyboard()
    {
        DisplayManager.Instance.SwitchDisplay();
    }

    #region QueueKeyboard
    /// <summary>
    /// V1.1
    /// Sets value of UI solution to the index value we need
    /// </summary>
    /// <param name="value">index value</param>
    public void SetValue(int value)
    {
        SolutionManager.Instance.GetSolution(value);
    }
    #endregion
}