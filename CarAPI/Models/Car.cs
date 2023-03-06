
using System;
namespace CarAPI.Models


public class Car : ICar
{
    //Bemærk her er valgt at definere "Unknown", som det 0'te element (default elementet - er Gender ikke initialiseret med en værdi, assignes det denne værdi)
    //Det er valgt for at tvinge stillingtagen til Gender og ikke auto-tildele værdien "Male" der ellers er det 0'te element
    
    public int Id { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }
    public int LicensePlate { get; set; }

    
    //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void ValidateModel()
    {
        // if (String.IsNullOrEmpty(Name)) throw new ArgumentException("Name is null or empty");

        if (Model == null) throw new ArgumentNullException("model is null");

        if (Model.Length < 2) throw new ArgumentException("model must be at least 1 character: " + Model);



    }

    public void ValidatePrice()
    {
        // if (String.IsNullOrEmpty(Name)) throw new ArgumentException("Name is null or empty");

        if (Price == null) throw new ArgumentNullException("price is null");

        if (Price < 1) throw new ArgumentException("price has to be a positive number: " + Price);

    }
    public void ValidateLicensePlate()
    {
        // if (String.IsNullOrEmpty(Name)) throw new ArgumentException("Name is null or empty");

        if (LicensePlate == null) throw new ArgumentNullException("name is null");

        if (LicensePlate <= 2 && LicensePlate <= 7) throw new ArgumentException("Shirt number has to be between 1 and 99: " + LicensePlate);

    }


    public Car(int number, string name, int pricing, int licenseplate)
    {
        Id = number;
        Model = name;
        Price = pricing;
        LicensePlate = licenseplate;
    }

    public Car() { }

    public virtual void Validate()
    {
        ValidateModel();
    }

    public override string ToString()
    {
        return $"{nameof(Id)}={Id.ToString()}, {nameof(Model)}={Model}, {nameof(Price)}={Price}, {nameof(LicensePlate)}={LicensePlate}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Car car &&
               Id == car.Id &&
               Model == car.Model &&
               Price == car.Price &&
               LicensePlate == car.LicensePlate;
    }

}
