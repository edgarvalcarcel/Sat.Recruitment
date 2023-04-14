namespace Sat.Recruitment.Domain.Events;

public class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(User item)
    {
        Item = item;
    }

    public User Item { get; }
}
