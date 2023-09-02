
namespace Data
{
    public class Character
    {
        private CharacterState currentState;

        public Character()
        {
            currentState = CharacterState.Idle;
        }

        public void ChangeState(CharacterState newState)
        {
            currentState = newState;
        }

        public void Update()
        {
            switch (currentState)
            {
                case CharacterState.Idle:
                    Console.WriteLine("Персонаж в состоянии покоя.");
                    break;
                case CharacterState.Walking:
                    Console.WriteLine("Персонаж идет.");
                    break;
                case CharacterState.Jumping:
                    Console.WriteLine("Персонаж прыгает.");
                    break;
                default:
                    Console.WriteLine("Неизвестное состояние персонажа.");
                    break;
            }
        }
    }
    public enum CharacterState
    {
        Idle,
        Walking,
        Jumping
    }
}