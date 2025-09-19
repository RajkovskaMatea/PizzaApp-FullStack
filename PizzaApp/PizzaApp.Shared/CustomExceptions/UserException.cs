namespace PizzaApp.Shared.CustomExceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; }
        public string Username { get; }

        public UserException(int? userId, string username, string message)
            : base(message)
        {
            UserId = userId;
            Username = username;
        }

        public override string ToString()
        {
            return $"UserException: UserId={UserId}, Username={Username}, Message={Message}";
        }
    }
}
