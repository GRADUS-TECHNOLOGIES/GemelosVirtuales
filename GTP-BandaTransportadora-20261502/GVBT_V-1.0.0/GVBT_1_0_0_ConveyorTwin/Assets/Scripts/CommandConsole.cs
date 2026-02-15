using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    public InputField inputField;
    public Text outputText;

    public ConveyorController conveyor;
    public ObjectSpawner spawner;

    void Start()
    {
        Print("=== GV 1.0.0 Console Ready ===");
        Print("Type 'help' for commands.");
    }

    public void OnCommandEntered()
    {
        string cmd = inputField.text.Trim().ToLower();
        inputField.text = "";
        inputField.ActivateInputField();

        Execute(cmd);
    }

    void Execute(string cmd)
    {
        Print("> " + cmd);

        if (cmd == "start") conveyor.StartBelt();
        else if (cmd == "stop") conveyor.StopBelt();
        else if (cmd == "reverse") conveyor.ReverseBelt();
        else if (cmd.StartsWith("spawn"))
        {
            string[] parts = cmd.Split(" ");
            if (parts.Length > 1) spawner.SpawnObject(parts[1]);
        }
        else if (cmd == "clear") spawner.ClearObjects();
        else if (cmd == "state") Print(conveyor.GetState());
        else if (cmd == "help")
        {
            Print("Commands: start, stop, reverse, spawn cube/sphere/capsule, clear, state");
        }
        else Print("Unknown command.");
    }

    void Print(string msg)
    {
        outputText.text += "\n" + msg;
    }
}
