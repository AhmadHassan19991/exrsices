using System;

public class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    // 1) LastWeek: ترجع مصفوفة ثابتة
    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    // 2) Today: آخر عنصر (اليوم الحالي)
    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    // 3) IncrementTodaysCount: زيد قيمة اليوم الحالي +1
    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    // 4) HasDayWithoutBirds: هل فيه يوم عدّه 0؟
    public bool HasDayWithoutBirds()
    {
        foreach (var n in birdsPerDay)
        {
            if (n == 0) return true;
        }
        return false;
    }

    // 5) CountForFirstDays: مجموع أول numberOfDays أيام
    public int CountForFirstDays(int numberOfDays)
    {
        int limit = Math.Min(numberOfDays, birdsPerDay.Length);
        int sum = 0;
        for (int i = 0; i < limit; i++)
        {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    // 6) BusyDays: عدّ الأيام اللي قيمتها >= 5
    public int BusyDays()
    {
        int count = 0;
        foreach (var n in birdsPerDay)
        {
            if (n >= 5) count++;
        }
        return count;
    }
}
