// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.AspNetCore.Identity.EntityFrameworkCore.InMemory.Test
{
    public class InMemoryContext :
        InMemoryContext<IdentityUser, IdentityRole, string>
    {
    }

    public class InMemoryContext<TUser> :
        InMemoryContext<TUser, IdentityRole, string>
        where TUser : IdentityUser
    {
    }

    public class InMemoryContext<TUser, TRole, TKey> : IdentityDbContext<TUser,TRole,TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public InMemoryContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}