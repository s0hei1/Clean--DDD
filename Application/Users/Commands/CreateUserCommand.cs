namespace Application.Users.Commands;

public sealed record CreateUserCommand
(string UserName, string Password);