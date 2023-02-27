﻿using AmiCog.Application.Common.Interfaces.Authentication;

namespace AmiCog.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if the user already exists
        
        // create user ( generate unique id )
        
        // create JWT token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
       
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }
}