using System;
using System.Collections.Generic;
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
                    Name = "Nike",
                    Parent = "Capital Account",
                    LedgerName = "Nike",
                    GstRegDetails = new LedgstRegDetails
                    {
                        ApplicableFrom = "20240401",
                        GstRegistrationType = "Regular",
                        GstIn = "10DELI04124B1DE"
                    },
                    MailingDetails = new LedMailingDetails
                    {
                        AddressList = new List<string>
                        {
                            "Pankaj Market C-32",
                            "Main Building Saraiya"
                        },
                        ApplicableFrom = "20240401",
                        MailingName = "Nike Store",
                        State = "Bihar",
                        Country = "India"
                    }
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
