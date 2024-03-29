﻿using System;
using DomainService.DomainService;
using Microsoft.Extensions.DependencyInjection;
using PetShopV2.Core.AppService;
using PetShopV2.Core.AppService.Impl;
using PetShopV2.Infrastructure.Data;
using PetShopV2.Infrastructure.Data.Repository;


namespace PetShopV2.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();

            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            FakeDB.InitData();
            printer.StartUI();
        }
    }
}
