﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Infrastructure.Identity;
using System.Security.Authentication;
using System.Security.Claims;

namespace StirCraftApp.Api.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var userToReturn = await userManager.Users
            .FirstOrDefaultAsync(x => x.Email == user.GetEmail());

        if (userToReturn == null)
        {
            throw new AuthenticationException("User not found");
        }

        return userToReturn;
    }

    private static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);

        if (email == null)
        {
            throw new AuthenticationException("Email claim not found");
        }

        return email;
    }
}