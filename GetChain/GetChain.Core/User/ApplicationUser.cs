using System;
using System.Collections.Generic;
using AspNetCore.Identity.MongoDbCore.Models;
using GetChain.GetChain.Core;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace GetChain.Core.User {
    [CollectionName("users")]
    [BsonIgnoreExtraElements]
    public class ApplicationUser : MongoIdentityUser<Guid> {

        public static readonly ApplicationUser NoUser = new ApplicationUser("Deleted User", "unknown@unknown.com");
        public List<ApiKey> ApiKeys { get; set; }

        public ApplicationUser() : base() { }

        public ApplicationUser(string userName, string email) : base(userName, email) { }
    }

    public class ApplicationRole : MongoIdentityRole<Guid> {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}