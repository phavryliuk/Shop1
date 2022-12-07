﻿using System;
using System.Collections.Generic;
using System.Linq;
using Shop1.Data.interfaces;
using Shop1.Data.Models;

namespace Shop1.Data.mocks;

public class MockCars : IAllCars
{
    private readonly ICarsCategory _categoryCars = new MockCategory();

    public IEnumerable<Car> Cars =>
        new List<Car>
        {
            new Car()
            {
                name = "Tesla", 
                shortDesc = "Сучасний електромобіль", 
                longDesc = "Заряду батареї вистачає на 1000 км, максимальна швидеість - 300 км/год. Купуйте!", 
                img = "/img/Tesla.jpg", 
                price = 50000, 
                isFavourite = true,
                available = true, 
                Category = _categoryCars.AllCategories.First()
            },

            new Car()
            {
                name = "Mercedes",
                shortDesc = "Автомобіль для понтів",
                longDesc = "Бак для соляри, максимальна швидеість - 400 км/год. Один на все село!",
                img = "/img/Mercedes.jpg",
                price = 99000,
                isFavourite = true,
                available = true,
                Category = _categoryCars.AllCategories.First()
            },

            new Car()
            {
                name = "Lamborghini",
                shortDesc = "Чисто бульбу з села привезти. Не бита",
                longDesc = "Їде краще любого трактора",
                img = "/img/Lambo.jpg",
                price = 999000,
                isFavourite = true,
                available = true,
                Category = _categoryCars.AllCategories.First()
            },

            new Car()
            {
                name = "Таврія",
                shortDesc = "Відро з болтами для душі",
                longDesc = "Не їде, максимальна швидеість - 000 км/год. Безцінні емоції!",
                img = "/img/Tavriia.jpg",
                price = 900,
                isFavourite = true,
                available = true,
                Category = _categoryCars.AllCategories.First()
            },

            new Car()
            {
                name = "Запорожець",
                shortDesc = "Не машина - легенда",
                longDesc = "Мотор як бензопили, їде трохи швидше",
                img = "/img/Zapor.jpg",
                price = 900,
                isFavourite = true,
                available = true,
                Category = _categoryCars.AllCategories.First()
            },
        };

    public IEnumerable<Car> GetFavCars { get; set; }

    public Car GetObjectCar(int carId)
    {
        throw new NotImplementedException();
    }
}