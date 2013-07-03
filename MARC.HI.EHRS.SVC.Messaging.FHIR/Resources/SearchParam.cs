﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MARC.HI.EHRS.SVC.Messaging.FHIR.DataTypes;

namespace MARC.HI.EHRS.SVC.Messaging.FHIR.Resources
{
    /// <summary>
    /// Search parameter
    /// </summary>
    [XmlType("SearchParam", Namespace = "http://hl7.org/fhir")]
    public class SearchParam
    {

        /// <summary>
        /// Gets or sets the name of the search parameter
        /// </summary>
        [XmlElement("name")]
        public FhirString Name { get; set; }
        /// <summary>
        /// Gets or sets the type of the parameter
        /// </summary>
        [XmlElement("type")]
        public PrimitiveCode<String> Type { get; set; }
        /// <summary>
        /// Gets or sets the documentation related to the parameter
        /// </summary>
        [XmlElement("documentation")]
        public FhirString Documentation { get; set; }

    }
}