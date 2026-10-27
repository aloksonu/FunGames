
using UnityEngine;

public class ControlSelectionManager : MonoBehaviour
{
    public GameObject controlSelectionPanel;
    public GameObject steeringWheel;
    public GameObject leftButton;
    public GameObject rightButton;

    public SteeringWheelUI steeringWheelController;
    public SteeringUI buttonController;
    public GyroCarController gyroController;

    void Start()
    {
        Time.timeScale = 0f;

        controlSelectionPanel.SetActive(true);
        steeringWheel.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        gyroController.DisableGyro();
    }

    public void SelectSteeringWheel()
    {
        steeringWheel.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        steeringWheelController.SetControlsEnabled(true);
        buttonController.SetControlsEnabled(false);
        gyroController.DisableGyro();

        StartGame();
    }

    public void SelectButtons()
    {
        steeringWheel.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);

        steeringWheelController.SetControlsEnabled(false);
        buttonController.SetControlsEnabled(true);
        gyroController.DisableGyro();

        StartGame();
    }

    public void SelectGyro()
    {
        steeringWheel.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        steeringWheelController.SetControlsEnabled(false);
        buttonController.SetControlsEnabled(false);
        gyroController.EnableGyro();

        StartGame();
    }

    void StartGame()
    {
        controlSelectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
