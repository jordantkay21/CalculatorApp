using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Calculator
{
    /// <summary>
    /// V1.0
    /// Manager to handle UI elements and values to display
    /// </summary>
    //V1.1 Updates --> N/A
    public class DisplayManager : MonoSingleton<DisplayManager>
    {
        [SerializeField]
        public TextMeshProUGUI[] StackTextboxes;
        [SerializeField]
        private TextMeshProUGUI _displayText;
        [SerializeField]
        private GameObject _numKey;
        [SerializeField]
        private GameObject _queKey;
        private string _equation;
        private bool _isNumKey = true;

        #region DisplayPanelManager
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
        #endregion
        #region Keyboard Manager
        /// <summary>
        /// Logic to switch between numerical keyboard and recent solutions keyboard
        /// </summary>
        public void SwitchDisplay()
        {
            if (_isNumKey == true)
            {
                DisplayNumberKeyboard(false);
                DisplayQueKeyboard(true);
                _isNumKey = false;
            }
            else
            {
                DisplayNumberKeyboard(true);
                DisplayQueKeyboard(false);
                _isNumKey = true;
            }
        }
        /// <summary>
        /// Turn NumberKeyboard on/off
        /// </summary>
        /// <param name="onOff">on=true | off=false</param>
        public void DisplayNumberKeyboard(bool onOff)
        {
            _numKey.SetActive(onOff);
        }
        /// <summary>
        /// Turn SoultionsKeyboard on/off
        /// </summary>
        /// <param name="onOff">on=true | off=false</param>
        public void DisplayQueKeyboard(bool onOff)
        {
            _queKey.SetActive(onOff);
        }

        #endregion
        #region RecentSolutions

        /// <summary>
        /// Resets the value of our text boxes to the current values in our Stack<>
        /// </summary>
        public void UpdateTheLabels(Stack<string> stackSolution)
        {
            int index = 0;
            ResetTextboxes();
            foreach (string result in stackSolution)
            {
                StackTextboxes[index].text = result;
                index++;
                if (index > 5)
                    break;
            }
        }

        /// <summary>
        /// Changes textbox display to null
        /// </summary>
        /// <param name="textboxes">The array holding the textboxes</param>
        public void ResetTextboxes()
        {
            foreach (TextMeshProUGUI text in StackTextboxes)
                text.text = "";

        }
        #endregion
    }
}

