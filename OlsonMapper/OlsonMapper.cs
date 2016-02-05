using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace McNearney.TimeZones
{
    public class OlsonMapper
    {
        /// <summary>
        /// Holds the Windows TimeZoneId -> OlsonId mappings
        /// </summary>
        private readonly Dictionary<string, string> _mapping;

        /// <summary>
        /// Initializes the mapping based on the incoming file path
        /// </summary>
        /// <param name="path">The path to the XML file containing the mapping data</param>
        public OlsonMapper(string path) : this(XElement.Load(path))
        {
        }

        public OlsonMapper(XElement xml)
        {
            var values = from m in xml.XPathSelectElements("*/mapTimezones/mapZone")
                         where m.Attribute("territory").Value == "001"
                         select new
                         {
                             TimeZoneId = m.Attribute("other").Value,
                             OlsonId = m.Attribute("type").Value
                         };

            _mapping = values.ToDictionary(v => v.TimeZoneId, v => v.OlsonId);
        }

        /// <summary>
        /// Returns the OlsonId value for the specified Windows TimeZoneId
        /// </summary>
        /// <param name="timeZoneId">The Windows TimeZoneId primary key</param>
        /// <returns></returns>
        public string Find(string timeZoneId)
        {
            if(!_mapping.ContainsKey(timeZoneId))
            {
                throw new ArgumentException("Invalid TimeZoneId Specified", "timeZoneId");
            }

            return _mapping[timeZoneId];
        }
    }
}