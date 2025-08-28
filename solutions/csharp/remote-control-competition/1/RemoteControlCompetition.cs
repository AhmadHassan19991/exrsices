using System;
using System.Collections.Generic;
using System.Linq;

public interface IRemoteControlCar 
{
    void Drive(); 
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    // طريقة المقارنة لترتيب السيارات حسب عدد الانتصارات تصاعدياً
    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null) return 1;
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    // ترتيب سيارات الإنتاج حسب NumberOfVictories باستخدام IComparable
    public static List<ProductionRemoteControlCar> GetRankedCars(params ProductionRemoteControlCar[] cars)
    {
        var list = cars.ToList();
        list.Sort(); // الآن Sort() يشتغل بدون مشاكل بفضل IComparable
        return list;
    }
}
