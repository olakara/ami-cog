﻿using AmiCog.Application.Common.Interfaces.Authentication;
using AmiCog.Application.Common.Interfaces.Persistence;
using AmiCog.Domain.Entities;

namespace AmiCog.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User not registered with this email!");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid Password!");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if the user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists!");
        }
        
        // create user ( generate unique id )
        var user = new User
        {
            Email = email,
            FirstName = firstName,
            Password = password,
            LastName = lastName
        };
        _userRepository.Add(user);
        
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);
        return new AuthenticationResult(user, token);
    }
}