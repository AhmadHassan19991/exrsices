class Lasagna
{
    //1 time is 40
      public int ExpectedMinutesInOven()
        {
            return 40; 
            
        }
    //2 الوقت المتبقي بالفرن - الموجود حاليا 
        public int  RemainingMinutesInOven(int MinutesInOven)
        {
            return 40 - MinutesInOven;
            
        }
    // 3 وقت التحضير = عدد الطبقات * 2 دقيقة 
    public int PreparationTimeInMinutes(int layers)
    {
        return layers*2;
    }
    //4 الوقت المنقضي = وقت التحضير - الوقت الحالي 
    public int ElapsedTimeInMinutes(int layers, int MinutesInOven)
    {
        return PreparationTimeInMinutes( layers) + MinutesInOven;
    }
}
