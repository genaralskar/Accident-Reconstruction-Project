using UnityEngine;

[CreateAssetMenu(menuName = "ControlInputs/Player")]
public class CIPlayer : ControlInputs
{
    [SerializeField] private string horizontalName = "Horizontal";
    [SerializeField] private string verticalName = "Vertical";
    [SerializeField] private string brakeName = "Brake";
    public override void GetInputs(CarController cc)
    {
        cc.horizontalInput = Input.GetAxis("Horizontal");
        cc.verticalInput = Input.GetAxis("Vertical");
        cc.breaking = Input.GetButtonDown("Brake");
    }
}
