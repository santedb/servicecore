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

using MARC.Everest.Connectors;
using System.Collections.Generic;

namespace MARC.HI.EHRS.SVC.Messaging.Everest
{
	/// <summary>
	/// Receive result for an invalid message handler
	/// </summary>
	public class InvalidMessageResult : IReceiveResult
	{
		#region IReceiveResult Members

		public ResultCode Code { get; set; }

		public IEnumerable<IResultDetail> Details { get; set; }

		public MARC.Everest.Interfaces.IGraphable Structure { get; set; }

		#endregion IReceiveResult Members
	}
}