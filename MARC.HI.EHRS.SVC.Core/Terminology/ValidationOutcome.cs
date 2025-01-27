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

namespace MARC.HI.EHRS.SVC.Core.Terminology
{
    /// <summary>
    /// Identifies the outcome of code validation
    /// </summary>
    public enum ValidationOutcome
    {
        /// <summary>
        /// The code supplied is valid
        /// </summary>
        Valid,
        /// <summary>
        /// The code supplied is valid, however there are warnings
        /// </summary>
        ValidWithWarning,
        /// <summary>
        /// The code supplied was invalid
        /// </summary>
        Invalid,
        /// <summary>
        /// An error occurred
        /// </summary>
        Error
    }
}