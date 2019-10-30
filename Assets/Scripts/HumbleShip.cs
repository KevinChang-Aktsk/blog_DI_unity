using UnityEngine;
public class HumbleShip : MonoBehaviour
{
    private IUserInput m_userInput;

    public void Initialize(IUserInput userInput)
    {
        m_userInput = userInput;
    }
    
    public void MoveHorizontally ()
    {
        var horizontal = m_userInput.GetAxis ("Horizontal");   //不在綁定Monobehavior，可測試
        Debug.Log("input value: " + horizontal);
    }
}
