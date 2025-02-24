﻿using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        void Add (Car car);
        void Update (Car car);
        void Delete (Car car);
        bool Any(int id);

    }
}
