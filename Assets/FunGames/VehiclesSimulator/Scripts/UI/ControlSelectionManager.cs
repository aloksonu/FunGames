
using UnityEngine;

public class ControlSelectionManager : MonoBehaviour
{
    public GameObject controlSelectionPanel;
    public GameObject steeringWheel;
    public GameObject leftButton;
    public GameObject rightButton;

    public SteeringWheelUI steeringWheelController;
    public SteeringUI buttonController;

    void Start()
    {
        Time.timeScale = 0f;

        controlSelectionPanel.SetActive(true);
        steeringWheel.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }

    public void SelectSteeringWheel()
    {
        steeringWheel.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        steeringWheelController.SetControlsEnabled(true);
        buttonController.SetControlsEnabled(false);

        StartGame();
    }

    public void SelectButtons()
    {
        steeringWheel.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);

        steeringWheelController.SetControlsEnabled(false);
        buttonController.SetControlsEnabled(true);

        StartGame();
    }

    void StartGame()
    {
        controlSelectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
