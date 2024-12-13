using System;
using System.IO;
using System.Xml.Serialization;
using TallyXMLSerialization;

class Program
{
    static void Main()
    {
        TallyMessage tallyMessage = new TallyMessage
        {
            Units = new[]
            {
                new Unit { Name = "Box", UnitName = "Box", IsSimpleUnit = "Yes" },
                new Unit { Name = "Pcs", UnitName = "Pcs", IsSimpleUnit = "Yes" }
            },
            StockItems = new[]
            {
                new StockItem
                {
                    Name = "Bisleri Bottle",
                    BaseUnits = "Box",
                    OpeningBalance = "5 Box",
                    OpeningValue = -100.00m,
                    OpeningRate = 20.00m,
                    LanguageNames = new[] { "Bisleri Bottle" }
                },
                new StockItem
                {
                    Name = "LED Bulb",
                    BaseUnits = "Pcs",
                    OpeningBalance = "5 Pcs",
                    OpeningValue = -1000.00m,
                    OpeningRate = 200.00m,
                    LanguageNames = new [] { "LED Bulb" }
                }
            },
            Ledgers = new Ledger[]
            {
                new Ledger
                {
                    Name = "D1",
                    Parent = "Capital Account",
                    LanguageNames = new [] { "D1" }
                },
                new Ledger
                {
                    Name = "D2",
                    Parent = "Capital Account",
                    LanguageNames = new [] { "D2" }
                },
                new Ledger
                {
                    Name = "D3",
                    Parent = "Capital Account",
                    LanguageNames = new [] { "D3" }
                }
            }
        };

        // Serialize the object to XML
        XmlSerializer serializer = new XmlSerializer(typeof(TallyMessage));
        StringWriter stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, tallyMessage);
        string xmlOutput = stringWriter.ToString();
        Console.WriteLine(xmlOutput);
        Console.ReadLine();
    }
}
