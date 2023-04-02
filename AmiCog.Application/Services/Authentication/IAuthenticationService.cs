﻿using ErrorOr;

namespace AmiCog.Application.Services.Authentication;

public interface IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName,
        string lastName,
        string email,
        string password);
}