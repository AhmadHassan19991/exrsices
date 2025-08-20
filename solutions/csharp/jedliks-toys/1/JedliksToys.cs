class RemoteControlCar
{
    private int _battary = 100;
    private int _distance = 0; 

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
         if (_battary == 0)
        return "Battery empty";
    return $"Battery at {_battary}%";
    }

    public void Drive()
    {
        if (_battary > 0) 
        {
            _distance += 20;
            _battary -= 1;
        }
    }
}
