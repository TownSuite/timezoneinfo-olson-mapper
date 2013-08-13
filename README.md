Overview
===
Provides a quick mapping of Window TimeZoneInfo IDs to Olson IDs.

**Examples:**

- Pacific Standard Time -> America/Los_Angeles
- SE Asia Standard Time -> Asia/Bangkok

**Notes:**

You will want to filter out the following TimeZoneInfo IDs as they are obsolete:

- Kamchatka Standard Time
- Mid-Atlantic Standard Time

See the following document for more information regarding the obsolete time zones:

- http://cldr.unicode.org/development/development-process/design-proposals/extended-windows-olson-zid-mapping

**Mapping Data:**

Embedded in the repository is the latest WindowsZones.xml data from unicode.org. You can always pull the latest from this URL:

- http://unicode.org/repos/cldr/trunk/common/supplemental/windowsZones.xml
