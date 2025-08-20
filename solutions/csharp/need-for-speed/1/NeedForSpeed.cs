class RemoteControlCar
{
   private int speed ;
   private int batteryDrain ;
   private int currentBattery;
   private int distanceDriven;


    public RemoteControlCar(int speed, int batteryDrain) 
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.currentBattery = 100;
        this.distanceDriven = 0; 
        
        
    }

    public bool BatteryDrained()
    {
        return currentBattery == 0;
    }

    public int DistanceDriven()
    {
          return distanceDriven;
    }

    public void Drive()
    {
   if (currentBattery >= batteryDrain)
   {
      distanceDriven += speed  ;
       currentBattery -= batteryDrain;
   }
         if (currentBattery < batteryDrain)
    {
        currentBattery = 0;
    }
    }

    public static RemoteControlCar Nitro()
    {
      return new RemoteControlCar(50,4);
    }
    public int CurrentBattery => currentBattery;
     public int BatteryDrainValue => batteryDrain;
  public int Speed => speed;

}

class RaceTrack
{
    private int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }
    
    public bool TryFinishTrack(RemoteControlCar car)
    {
        
        int possibleDrives = car.CurrentBattery / car.BatteryDrainValue; 
int possibleDistance = possibleDrives * car.Speed;
        
return possibleDistance >= distance;        
    }
}
