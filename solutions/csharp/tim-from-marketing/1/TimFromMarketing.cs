static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
     department = (department == null) ? "OWNER" : department.ToUpper();
        
 string badge =(id == null)
     ?$"{name} - {department}"
     : $"[{id}] - {name} - {department}";
        return badge;


        

        
    }
}
