// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
        new ApiResource("ResourceCatalog") {Scopes={"CatelogFullPermission","CatelogReadPermission"}},
        new ApiResource("ResourceDiscount") {Scopes={ "DiscountFullPermission"}},
        new ApiResource("ResourceOrder") {Scopes={ "OrderFullPermission"}},
        new ApiResource("ResourceCargo") {Scopes={ "CargoFullPermission"}},
        new ApiResource("ResourceBasket") {Scopes={ "BasketFullPermission"}},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatelogFullPermission","Full Yetkili"),
            new ApiScope("CatelogReadPermission","Sadece okuma yetkisi"),
            new ApiScope("DiscountFullPermission","Full Yetkili"),
            new ApiScope("OrderFullPermission","Full Yetkili"),
            new ApiScope("CargoFullPermission","Full Yetkili"),
            new ApiScope("BasketFullPermission","Full Yetkili"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="Visitor",
                ClientName="Multi Shop Client User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedScopes= { "DiscountFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId="Manager",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedScopes= { "CatelogReadPermission" , "CatelogFullPermission"}
            },

             //Admin
            new Client
            {
                ClientId="Admin",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedScopes= { "CatelogReadPermission" , "CatelogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile },
                AccessTokenLifetime=6000
            }
        };
    }
}