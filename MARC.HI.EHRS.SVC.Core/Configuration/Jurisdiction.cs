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



using MARC.HI.EHRS.SVC.Core.Data;
using MARC.HI.EHRS.SVC.Core.Services;
/*
* Copyright 2012-2013 Mohawk College of Applied Arts and Technology
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
* Date: 7-5-2012
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARC.HI.EHRS.SVC.Core.Configuration
{
    /// <summary>
    /// Identifies a structure that stores information related to a jurisdiction
    /// </summary>
    public class Jurisdiction : CustodianshipData
    {

        /// <summary>
        /// Gets or sets the default language code
        /// </summary>
        public string DefaultLanguageCode { get; set; }

    }
}
