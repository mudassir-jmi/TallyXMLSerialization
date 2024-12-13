
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
        //public List<Ledger> Ledgers { get; set; }
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

    // Class to represent the LEDGER element
    public class Ledger
    {
        [XmlAttribute("NAME")]
        public string Name { get; set; }

        [XmlElement("PARENT")]
        public string Parent { get; set; }

        [XmlArray("LANGUAGENAME.LIST")]
        [XmlArrayItem("Name")]
        public string[] LanguageNames { get; set; }
    }

    // Class for LANGUAGENAME.LIST inside LEDGER
    //public class LanguageNameList
    //{
    //    [XmlElement("NAME.LIST")]
    //    public NameList Names { get; set; }
    //}

    // Class for NAME.LIST inside LANGUAGENAME.LIST
    //public class NameList
    //{
    //    [XmlElement("NAME")]
    //    public string Name { get; set; }
    //}

}
