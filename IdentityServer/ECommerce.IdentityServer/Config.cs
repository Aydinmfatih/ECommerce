// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission" } },
            new ApiResource("ResourceReadCatalog") { Scopes = { "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = { "DiscountReadPermission", "DiscountCreatePermission" } },
            new ApiResource("ResourceDiscountFull") { Scopes = { "DiscountFullPermission" } },
            new ApiResource("ResourceOrderEdit") { Scopes = { "OrderEditPermission" } },
            new ApiResource("ResourceOrderFull") { Scopes = { "OrderFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
           new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
           new ApiScope("CatalogReadPermission","Catalog Read Authority For Catalog Read Operations"),
           new ApiScope("DiscountReadPermission","Discount Read  Authority For Discount Read Operations"),
           new ApiScope("DiscountCreatePermission","Discount Create  Authority For Discount Create Operations"),
           new ApiScope("DiscountFullPermission","Discount Full  Authority For Discount Full Operations"),
           new ApiScope("OrderEditPermission","Order Edit  Authority For Order Edit Operations"),
           new ApiScope("OrderFullPermission","Order Full  Authority For Order Full Operations"),
           new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor Client
            new Client
            {
                ClientId="ECommerceVisitorId",
                ClientName="E Commerce Visitor Users",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }

            },

            //Manager Client
            new Client
            {
                ClientId="ECommerceManagerId",
                ClientName="E Commerce Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={"CatalogFullPermission" }
            },

             //Admin Client
            new Client
            {
                ClientId="ECommerceAdminId",
                ClientName="E Commerce Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission", "CatalogFullPermission", "OrderFullPermission" ,IdentityServerConstants.LocalApi.ScopeName },
                AccessTokenLifetime=600
            }
        };
    }
}