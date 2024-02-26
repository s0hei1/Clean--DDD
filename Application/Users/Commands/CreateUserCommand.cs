namespace Application.Users.Commands;

public sealed record CreateUserCommand
(string Username, string Password);