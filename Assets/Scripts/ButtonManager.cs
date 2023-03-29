using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoSingleton<ButtonManager>
{
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
}
