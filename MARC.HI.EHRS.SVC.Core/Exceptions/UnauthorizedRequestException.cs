﻿/*
 * Copyright 2010-2018 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: fyfej
 * Date: 1-9-2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace MARC.HI.EHRS.SVC.Core.Exceptions
{
    /// <summary>
    /// Unauthorized access
    /// </summary>
    public class UnauthorizedRequestException : AuthenticationException
    {

        /// <summary>
        /// Authenticate challenge
        /// </summary>
        public String AuthenticateChallenge { get; set; }

        /// <summary>
        /// Unauthorized access exception
        /// </summary>
        public UnauthorizedRequestException(String message, String scheme, String realm, String scope) : base(message)
        {
            StringBuilder authenticateString = new StringBuilder();
            authenticateString.AppendFormat("{0} realm=\"{1}\"", scheme, realm ?? "anonymous");
            if(!String.IsNullOrEmpty(scope))
                authenticateString.AppendFormat(", scope=\"{0}\"", scope);
            this.AuthenticateChallenge = authenticateString.ToString();
        }

    }
}
