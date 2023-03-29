using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationManager : MonoSingleton<CalculationManager>
{
    private string _num1String;
    private float _num1;
    private string _num2String;
    private float _num2;
    private string _chosenOperator;

    private float _result;
    private bool _operatorChosen;

    /// <summary>
    /// Method to grab value from Buttons and add the value to the appropriate number
    /// </summary>
    /// <param name="newValue">Value assigned to the numerical button</param>
    public void FillNum(string newValue)
    {
        if (_operatorChosen == true)
        {
            _num2String += newValue;
        }
        else if (_operatorChosen == false)
        {
            _num1String += newValue;
        }
    }
    /// <summary>
    /// Method to grab the Value from OPERATOR buttons and assign the operator to the equation
    /// </summary>
    /// <param name="chosenOperator">Operator assigned to the operator button</param>
    public void SetOperator(string chosenOperator)
    {
        _operatorChosen = true;
        _chosenOperator = chosenOperator;
    }
    public void ClearCalculator()
    {
        _num1String = "";
        _num2String = "";
        _chosenOperator = "";
        _operatorChosen = false;
    }
    /// <summary>
    /// Method to call SolveEquation() when "=" is pressed
    /// </summary>
    public void EqualsPressed()
    {
        SolveEquation(_num1String, _num2String);
    }
    /// <summary>
    /// Method to be called to solve the given equation
    /// Step 1. Converts num1/2String to float variables
    /// Step 2. Figures which operator was chosen
    /// Step 3. Runs the equation and stores results
    /// Step 4. Displays result through DisplayManager
    /// </summary>
    /// <param name="num1S">First number entered by the user</param>
    /// <param name="num2S\">Second number entered by the user</param>
    private void SolveEquation(string num1S, string num2S)
    {
        _num1 = float.Parse(num1S, System.Globalization.NumberStyles.Number);
        _num2 = float.Parse(num2S, System.Globalization.NumberStyles.Number);
        switch (_chosenOperator)
        {
            case "+":
                _result = _num1 + _num2;
                DisplayManager.Instance.DisplayAnswer(_result);
                DisplayManager.Instance.ClearEquation();
                ClearCalculator();
                break;
            case "-":
                _result = _num1 - _num2;
                DisplayManager.Instance.DisplayAnswer(_result);
                DisplayManager.Instance.ClearEquation();
                ClearCalculator();
                break;
            case "x":
                _result = _num1 * _num2;
                DisplayManager.Instance.DisplayAnswer(_result);
                DisplayManager.Instance.ClearEquation();
                ClearCalculator();
                break;
            case "/":
                _result = _num1 / _num2;
                DisplayManager.Instance.DisplayAnswer(_result);
                DisplayManager.Instance.ClearEquation();
                ClearCalculator();
                break;

        }
    }
}
