﻿using SSO.Domain.Users.InsertUsers;

namespace SSO.Domain.Users
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public void ValidateToInsertUser() =>
            Validate(this, new InsertUserContract());
    }
}
