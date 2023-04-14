﻿namespace Sat.Recruitment.Domain.Events;

public class UserCreatedEvent : BaseEvent
{
    public UserCreatedEvent(User item)
    {
        Item = item;
    }

    public User Item { get; }
}
