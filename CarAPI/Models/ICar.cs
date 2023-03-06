using System;
namespace CarAPI.Models

{
    public interface ICar
    {


        int Id { get; set; }
        string Model { get; set; }
        int Price { get; set; }
        int LicensePlate { get; set; }

        int GetHashCode();
        string ToString();
        void Validate();
        void ValidatePrice();
        void ValidateModel();
        void ValidateLicensePlate();
    }
}