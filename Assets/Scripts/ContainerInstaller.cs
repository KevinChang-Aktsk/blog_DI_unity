using UnityEngine;

public interface IUserInput
{
    float GetAxis(string axisName); //使用者input 轉為抽象才能自定義測試數值
}

//自定義的input，也可以是寫測試的替換物
public class FakeUserInput : IUserInput
{
    public float GetAxis(string axisName)
    {
        return 100;
    }
}

//Container的建造者，這裡集中寫系統與物件的相依性，也就是我們程序員的維護靈藥！
public class ContainerInstaller : MonoBehaviour
{
    public HumbleShip Ship;

    void Awake()
    {
        var customInput = DependencyContainer.GetDependantInstance<FakeUserInput>() as IUserInput;
        Ship = FindObjectOfType<HumbleShip>().GetComponent<HumbleShip>();
        Ship.Initialize(customInput); //MonoBehaviour不支持建構子注入，這邊採方法注入
    }

    private void Start()
    {
        Ship.MoveHorizontally();
    }
}