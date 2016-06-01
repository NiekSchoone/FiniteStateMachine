public interface IFSM<T>
{
    void Enter(T entity);   //Called once when a state has started execution.
    void Execute(T entity); //Called every update in a state.
    void Exit(T entity);    //Called once when a state will stop execution.
}