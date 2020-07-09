public interface IState
{
    void Enter(CarMotion carMotion);
    void Execute();
    void Exit();
}
