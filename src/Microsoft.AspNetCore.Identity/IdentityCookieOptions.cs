// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Identity
{
    /// <summary>
    /// Represents all the options you can use to configure the cookies middleware uesd by the identity system.
    /// </summary>
    public class IdentityCookieOptions
    {
        private static readonly string DefaultApplicationScheme = typeof(IdentityCookieOptions).Namespace + ".Application";
        private static readonly string DefaultExternalScheme = typeof(IdentityCookieOptions).Namespace + ".External";
        private static readonly string DefaultTwoFactorRememberMeScheme = typeof(IdentityCookieOptions).Namespace + ".TwoFactorRememberMe";
        private static readonly string DefaultTwoFactorUserIdScheme = typeof(IdentityCookieOptions).Namespace + ".TwoFactorUserId";

        public IdentityCookieOptions()
        {
            // Configure all of the cookie middlewares
            ApplicationCookie = new CookieAuthenticationOptions
            {
                AuthenticationScheme = DefaultApplicationScheme,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/Account/Login"),
                Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
                }
            };

            ExternalCookie = new CookieAuthenticationOptions
            {
                AuthenticationScheme = DefaultExternalScheme,
                CookieName = DefaultExternalScheme,
                ExpireTimeSpan = TimeSpan.FromMinutes(5)
            };

            TwoFactorRememberMeCookie = new CookieAuthenticationOptions
            {
                AuthenticationScheme = DefaultTwoFactorRememberMeScheme,
                CookieName = DefaultTwoFactorRememberMeScheme
            };

            TwoFactorUserIdCookie = new CookieAuthenticationOptions
            {
                AuthenticationScheme = DefaultTwoFactorUserIdScheme,
                CookieName = DefaultTwoFactorUserIdScheme,
                ExpireTimeSpan = TimeSpan.FromMinutes(5)
                };

        }

        public CookieAuthenticationOptions ApplicationCookie { get; set; }
        public CookieAuthenticationOptions ExternalCookie { get; set; }
        public CookieAuthenticationOptions TwoFactorRememberMeCookie { get; set; }
        public CookieAuthenticationOptions TwoFactorUserIdCookie { get; set; }

        /// <summary>
        /// Gets the scheme used to identify application authentication cookies.
        /// </summary>
        /// <value>The scheme used to identify application authentication cookies.</value>
        public string ApplicationCookieAuthenticationScheme => ApplicationCookie?.AuthenticationScheme;

        /// <summary>
        /// Gets the scheme used to identify external authentication cookies.
        /// </summary>
        /// <value>The scheme used to identify external authentication cookies.</value>
        public string ExternalCookieAuthenticationScheme => ExternalCookie?.AuthenticationScheme;

        /// <summary>
        /// Gets the scheme used to identify Two Factor authentication cookies for round tripping user identities.
        /// </summary>
        /// <value>The scheme used to identify user identity 2fa authentication cookies.</value>
        public string TwoFactorUserIdCookieAuthenticationScheme => TwoFactorUserIdCookie?.AuthenticationScheme;

        /// <summary>
        /// Gets the scheme used to identify Two Factor authentication cookies for saving the Remember Me state.
        /// </summary>
        /// <value>The scheme used to identify remember me application authentication cookies.</value>        
        public string TwoFactorRememberMeCookieAuthenticationScheme => TwoFactorRememberMeCookie?.AuthenticationScheme;
    }
}
