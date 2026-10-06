using SecondLabTwo.model;
using SecondLabTwo.Service;
using System;

List<Telephone> telephones = new List<Telephone>()
{
    new Telephone("Nokia 3310", "Nokia", 50, new DateOnly(2000, 9, 1)),
    new Telephone("Nokia 3310", "Nokia", 65, new DateOnly(2017, 2, 26)),
    new Telephone("Samsung Galaxy S26", "Samsung", 650, new DateOnly(2020, 02, 10)),
    new Telephone("iPhone 11", "Apple", 380, new DateOnly(2020, 10, 13)),
    new Telephone("Samsung Galaxy S21", "Samsung", 650, new DateOnly(2021, 1, 29)),
    new Telephone("Samsung Galaxy S24", "Samsung", 800, new DateOnly(2024, 1, 17)),
    new Telephone("Google Pixel 7", "Google", 499, new DateOnly(2022, 10, 6)),
    new Telephone("Google Pixel 8", "Google", 699, new DateOnly(2023, 10, 12)),
    new Telephone("Xiaomi Redmi Note 11", "Xiaomi", 180, new DateOnly(2022, 1, 26)),
    new Telephone("Xiaomi 13 Pro", "Xiaomi", 899, new DateOnly(2022, 12, 11))
};
TelephoneMethods telephoneMethods = new TelephoneMethods();

telephoneMethods.AllTelephones();
telephoneMethods.MoreThanOneHundPriceTelephones();
telephoneMethods.MoreThanSevenHundButLessThanFourHundPriceTelephones();
telephoneMethods.ManufactureTelephones("Samsung");
telephoneMethods.CheaperTelephones();
telephoneMethods.CostlyTelephones(;
telephoneMethods.FiveCheaperTelephones();
telephoneMethods.FiveCostlyTelephones();
telephoneMethods.NewestTelephones();
telephoneMethods.OldestTelephones();
telephoneMethods.ThreeNewestTelephones();
telephoneMethods.ThreeOldestTelephones();
telephoneMethods.AverageTelephones();
telephoneMethods.StatisticsOnNuMTelephonesForEachManufacturer();
telephoneMethods.StatisticsOnNuMTelephonesModel();