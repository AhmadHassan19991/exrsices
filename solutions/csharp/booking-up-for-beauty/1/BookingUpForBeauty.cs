using System;

static class Appointment
{
    // 1. Parse appointment date
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    // 2. Check if an appointment has already passed
    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    // 3. Check if appointment is in the afternoon
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
    }

    // 4. Describe the time and date of the appointment
    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }

    // 5. Return the anniversary date
    public static DateTime AnniversaryDate()
    {
        int currentYear = DateTime.Now.Year;
        return new DateTime(currentYear, 9, 15, 0, 0, 0);
    }
}
