﻿namespace dotnet6_auth_sqlite_api.Models.Authentication
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
