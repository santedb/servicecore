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
using System.Text;
using System.Net;
using AtnaApi.Transport;

namespace MARC.HI.EHRS.SVC.Auditing.Atna.Configuration
{
    /// <summary>
    /// Audit configuration
    /// </summary>
    public class AuditConfiguration
    {


        /// <summary>
        /// Identifies the host that audits should be sent to
        /// </summary>
        public IPEndPoint AuditTarget { get; set; }

        /// <summary>
        /// Gets or sets the message publisher to use for this audit
        /// </summary>
        public ITransporter MessagePublisher { get; set; }
    }
}
