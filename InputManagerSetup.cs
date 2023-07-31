using UnityEngine;

public class InputManagerSetup : MonoBehaviour
{
    private void Start()
    {
        // Add the "Attack" input to the Input Manager
        InputManager_AddButton("Attack", KeyCode.E);
    }

    private void InputManager_AddButton(string buttonName, KeyCode key)
    {
        string[] inputAxes = Input.GetJoystickNames();

        string axisName = "Button_" + buttonName;
        string altPositive = "";

        for (int i = 1; i <= 20; i++)
        {
            if (Input.GetKey(key))
            {
                axisName = "Button_" + buttonName + "_" + i;
                break;
            }
        }

        InputManagerEntry entry = new InputManagerEntry()
        {
            name = axisName,
            positiveButton = key.ToString(),
            altPositiveButton = altPositive,
            gravity = 1000,
            dead = 0.001f,
            sensitivity = 1000,
            type = (int)InputManagerEntryType.KeyOrMouseButton, // Explicitly cast to int here
            axis = -1,
            joyNum = 0
        };

        string serializedEntry = JsonUtility.ToJson(entry);

        PlayerPrefs.SetString("UnityInput_" + axisName, serializedEntry);
    }

    private class InputManagerEntry
    {
        public string name;
        public string positiveButton;
        public string altPositiveButton;
        public float gravity;
        public float dead;
        public float sensitivity;
        public int type;
        public int axis;
        public int joyNum;
    }

    private enum InputManagerEntryType
    {
        KeyOrMouseButton = 0,
        MouseMovement = 1,
        JoystickAxis = 2,
    }
}
