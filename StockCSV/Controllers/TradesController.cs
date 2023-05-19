﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockCSV.Data;
using StockCSV.Interfaces;
using StockCSV.Models;
using System.Globalization;
using CsvHelper;

namespace StockCSV.Controllers
{
    public class TradesController : Controller
    {
        private readonly StockCSVContext _context;

        public TradesController(StockCSVContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                // get csv data to display
                ViewData["Trades"] = CsvToList();
                // calculate and show tax figures
                ViewData["Total"] = TaxCalculator();
            }
            catch (Exception ex)
            {
                Response.WriteAsync("<script>alert('" + ex.Message + "')</script>");
            }

            return View(_context.Holding.ToList());
        }

        private List<Trade> CsvToList()
        {
            var uploadedFiles = @"C:\Users\angus\source\repos\StockCSV\UploadedFiles";
            var path = Directory.GetFiles(uploadedFiles);
            if (path.Length >= 1)
            {
                using (var streamReader = new StreamReader(path[0]))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        var records = csvReader.GetRecords<Trade>().ToList();
                        return records;
                    }
                }
            }
            return new List<Trade>();
        }

        private double TaxCalculator()
        {
            var records = CsvToList();
            records.Reverse();
            var total = 0.0;
            foreach (var record in records)
            {
                if (record.TradeType == "Sell")
                    total += Sell(record, total);

                else if (record.TradeType == "Buy")
                    Buy(record);
            }
            ViewData["Holdings"] = _context.Holding;
            return Math.Round(total, 2);
        }

        private double Sell(Trade record, double total)
        {
            var sold = false;
            foreach (var holding in _context.Holding)
            {
                if (holding.Code == record.Code)
                {
                    sold = true;
                    var recordUnits = record.Units;
                    holding.Units -= recordUnits;

                    if (holding.Units < 0)
                        throw new Exception("Insufficient holdings for trade type sale of" + holding.Code);

                    var costPrice = recordUnits * holding.AVGPrice;
                    var saleValue = (record.Price * recordUnits) - (record.GST + record.Brokerage);
                    var profitLoss = saleValue - costPrice;

                    if (holding.Units == 0)
                        _context.Remove(holding);

                    total += profitLoss;
                }
            }
            if (sold == false)
                throw new Exception($"Cannot sell a holding which does not exist. Please add {record.Code} holdings from previous financial year");

            _context.SaveChanges();
            return total;
        }

        private void Buy(Trade record)
        {
            var adjusted = 0;
            foreach (var holding in _context.Holding)
            {
                if (holding.Code == record.Code)
                {
                    holding.Units += record.Units;
                    var totalCostPrice = record.Consideration + (holding.Units * holding.AVGPrice);
                    holding.AVGPrice = Math.Round(totalCostPrice / holding.Units, 2);
                    var purchaseDate = record.PurchaseDate/*.ToDateTime(TimeOnly.MinValue)*/;
                    holding.PurchaseDate = purchaseDate;
                    adjusted = 1;
                }

            }
            if (adjusted == 0)
            {
                var purchaseDate = record.PurchaseDate/*.ToDateTime(TimeOnly.MinValue)*/;
                var newHolding = new Holding(record.Code, record.Units, record.Price, purchaseDate);
                _context.Add(newHolding);
            }
            _context.SaveChanges();
        }
    }
}
