﻿using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdSrv
{
    static class Users
    {
        public static List<InMemoryUser> Get() 
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser{
                    Username = "bob",
                    Password = "secret",
                    Subject = "1"
                },
                new InMemoryUser {
                    Username = "alice",
                    Password = "secret",
                    Subject = "2"
                }
            };
        }
    }
}
