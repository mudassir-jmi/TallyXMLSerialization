
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TallyXMLSerialization
{
    // Define the root element
    [XmlRoot("TALLYMESSAGE")]
    public class TallyMessage
    {
        [XmlElement("UNIT")]
        public Unit[] Units { get; set; }

        [XmlElement("STOCKITEM")]
        public StockItem[] StockItems { get; set; }

        [XmlElement("LEDGER")]
        public Ledger[] Ledgers { get; set; }
    }

    // Class to represent the UNIT element
    public class Unit
    {
        [XmlAttribute("NAME")]
        public string Name { get; set; }

        [XmlElement("NAME")]
        public string UnitName { get; set; }

        [XmlElement("ISSIMPLEUNIT")]
        public string IsSimpleUnit { get; set; }
    }

    // Class to represent the STOCKITEM element
    public class StockItem
    {
        [XmlAttribute("NAME")]
        public string Name { get; set; }

        [XmlElement("NAME")]
        public string StockItemName { get; set; }

        [XmlElement("BASEUNITS")]
        public string BaseUnits { get; set; }

        [XmlElement("OPENINGBALANCE")]
        public string OpeningBalance { get; set; }

        [XmlElement("OPENINGVALUE")]
        public decimal OpeningValue { get; set; }

        [XmlElement("OPENINGRATE")]
        public decimal OpeningRate { get; set; }

        [XmlArray("LANGUAGENAME.LIST")]
        [XmlArrayItem("NAME")]
        public string[] LanguageNames { get; set; }
    }

    public class Ledger
    {
        [XmlAttribute("NAME")]
        public string Name { get; set; }

        [XmlElement("PARENT")]
        public string Parent { get; set; }

        [XmlElement("NAME")]
        public string LedgerName { get; set; }

        [XmlElement("LEDGSTREGDETAILS.LIST")]
        public LedgstRegDetails GstRegDetails { get; set; }

        [XmlElement("LEDMAILINGDETAILS.LIST")]
        public LedMailingDetails MailingDetails { get; set; }
    }

    public class LedgstRegDetails
    {
        [XmlElement("APPLICABLEFROM")]
        public string ApplicableFrom { get; set; }

        [XmlElement("GSTREGISTRATIONTYPE")]
        public string GstRegistrationType { get; set; }

        [XmlElement("GSTIN")]
        public string GstIn { get; set; }
    }

    public class LedMailingDetails
    {
        [XmlArray("ADDRESS.LIST")]
        [XmlArrayItem("ADDRESS")]
        public List<string> AddressList { get; set; }

        [XmlElement("APPLICABLEFROM")]
        public string ApplicableFrom { get; set; }

        [XmlElement("MAILINGNAME")]
        public string MailingName { get; set; }

        [XmlElement("STATE")]
        public string State { get; set; }

        [XmlElement("COUNTRY")]
        public string Country { get; set; }
    }

}
