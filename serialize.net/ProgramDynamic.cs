using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TallyXMLSerialization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the current year (e.g., 2024):");
        string currentYear = Console.ReadLine();
        string dynamicApplicableFrom = currentYear + "0401";

        // Collect dynamic values for Units
        Console.WriteLine("Enter Unit Name (e.g., LTR):");
        string unitName = Console.ReadLine();

        Console.WriteLine("Enter Unit Original Name (e.g., Liter):");
        string originalName = Console.ReadLine();

        Console.WriteLine("Enter Reporting UQC Name (e.g., LTR-LITRE):");
        string reportingUQCName = Console.ReadLine();

        // Collect dynamic values for StockItems
        Console.WriteLine("Enter Stock Item Name (e.g., LED Bulb):");
        string stockItemName = Console.ReadLine();

        Console.WriteLine("Enter Base Units (e.g., Pcs):");
        string baseUnits = Console.ReadLine();

        Console.WriteLine("Enter Opening Balance (e.g., 5 Pcs):");
        string openingBalance = Console.ReadLine();

        Console.WriteLine("Enter Opening Value (e.g., -1000):");
        decimal openingValue = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Opening Rate (e.g., 200):");
        decimal openingRate = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter HSN Code (e.g., 2523):");
        string hsnCode = Console.ReadLine();

        Console.WriteLine("Enter HSN Description (e.g., Cement):");
        string hsnDescription = Console.ReadLine();

        Console.WriteLine("Enter GST Rate (e.g., 10):");
        decimal gstRate = decimal.Parse(Console.ReadLine());

        // Collect dynamic values for Ledgers
        Console.WriteLine("Enter Ledger Name (e.g., Nike):");
        string ledgerName = Console.ReadLine();

        Console.WriteLine("Enter Parent Group (e.g., Capital Account):");
        string parentGroup = Console.ReadLine();

        Console.WriteLine("Enter GSTIN (e.g., 10DELI04124B1DE):");
        string gstIn = Console.ReadLine();

        Console.WriteLine("Enter Address Line 1:");
        string address1 = Console.ReadLine();

        Console.WriteLine("Enter Address Line 2:");
        string address2 = Console.ReadLine();

        Console.WriteLine("Enter State (e.g., Bihar):");
        string state = Console.ReadLine();

        Console.WriteLine("Enter Country (e.g., India):");
        string country = Console.ReadLine();

        TallyMessage tallyMessage = new TallyMessage
        {
            Units = new[]
            {
                new Unit
                {
                    Name = unitName,
                    UnitName = unitName,
                    OriginalName = originalName,
                    IsSimpleUnit = "Yes",
                    ReportingUQCDetails = new ReportingUQCDetails
                    {
                        ApplicableFrom = dynamicApplicableFrom,
                        ReportingUQCName = reportingUQCName
                    }
                }
            },
            StockItems = new[]
            {
                new StockItem
                {
                    Name = stockItemName,
                    StockItemName = stockItemName,
                    BaseUnits = baseUnits,
                    OpeningBalance = openingBalance,
                    OpeningValue = openingValue,
                    OpeningRate = openingRate,
                    LanguageNames = new[] { stockItemName },
                    HSNDetailsList = new[]
                    {
                        new HSNDetails
                        {
                            ApplicableFrom = dynamicApplicableFrom,
                            HSNCode = hsnCode,
                            HSN = hsnDescription,
                            SourceOfHSNDetails = "Specify Details Here"
                        }
                    },
                    GSTDetailsList = new[]
                    {
                        new GSTDetails
                        {
                            ApplicableFrom = dynamicApplicableFrom,
                            Taxability = "Taxable",
                            SourceOfGSTDetails = "Specify Details Here",
                            StatewiseDetailsList = new[]
                            {
                                new StatewiseDetails
                                {
                                    StateName = $"{char.ConvertFromUtf32(4)} Any",
                                    RateDetailsList = new[]
                                    {
                                        new RateDetails
                                        {
                                            GSTRateDutyHead = "IGST",
                                            GSTRate = gstRate
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            Ledgers = new[]
            {
                new Ledger
                {
                    Name = ledgerName,
                    Parent = parentGroup,
                    LedgerName = ledgerName,
                    GstRegDetails = new LedgstRegDetails
                    {
                        ApplicableFrom = dynamicApplicableFrom,
                        GstRegistrationType = "Regular",
                        GstIn = gstIn
                    },
                    MailingDetails = new LedMailingDetails
                    {
                        AddressList = new List<string> { address1, address2 },
                        ApplicableFrom = dynamicApplicableFrom,
                        MailingName = ledgerName + " Store",
                        State = state,
                        Country = country
                    }
                }
            }
        };

        // Serialize the object to XML
        XmlSerializer serializer = new XmlSerializer(typeof(TallyMessage));
        StringWriter stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, tallyMessage);
        string xmlOutput = stringWriter.ToString();
        xmlOutput = Regex.Replace(xmlOutput, @"&#x(\d+);", @"&#$1;");

        Console.WriteLine("\nSerialized XML:\n");
        Console.WriteLine(xmlOutput);
        Console.ReadLine();
    }
}
