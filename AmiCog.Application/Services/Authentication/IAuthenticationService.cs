﻿namespace AmiCog.Application.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Login(string email, string password);
    public AuthenticationResult Register(string firstName,
        string lastName,
        string email,
        string password);
}