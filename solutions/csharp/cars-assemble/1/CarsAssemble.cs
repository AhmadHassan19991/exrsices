static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
       return new double[] { 0, 1, 1, 1, 1, 0.9, 0.9, 0.9, 0.9, 0.8, 0.77 }[speed];
        
    }
    
    public static double ProductionRatePerHour(int speed)
    {
       double primaryProduction = speed * 221;
double actualProduction = primaryProduction * SuccessRate(speed);
return actualProduction; 
        

    }

    public static int WorkingItemsPerMinute(int speed)
    {
           return (int)(ProductionRatePerHour(speed) / 60);
 
    }
}
