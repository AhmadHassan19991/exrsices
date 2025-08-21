enum LogLevel
{
    Unknown,  // 
    Trace,    // -- TRC
    Debug,    // -- DBG
    Info,     // -- INF
    Warning,  // -- WRN
    Error,    // -- ERR
    Fatal     // -- FTL
}
static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        int start = logLine.IndexOf('[')+1;
        int end = logLine.IndexOf(']');
        string code = logLine.Substring(start, end - start);
        switch (code)
        {
         case "TRC":
            return LogLevel.Trace;
         case "DBG":
            return LogLevel.Debug;
        case "INF": 
            return LogLevel.Info;
        case "WRN": 
            return LogLevel.Warning;
        case "ERR": 
            return LogLevel.Error;
        case "FTL": 
            return LogLevel.Fatal;
        default: 
            return LogLevel.Unknown;  
  
        }
        Console.WriteLine(LogLine.ParseLogLevel("[INF]: File deleted"));  

    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
       int encoded;
    switch (logLevel)
    {
        case LogLevel.Trace: encoded = 1; break;
        case LogLevel.Debug: encoded = 2; break;
        case LogLevel.Info: encoded = 4; break;
        case LogLevel.Warning: encoded = 5; break;
        case LogLevel.Error: encoded = 6; break;
        case LogLevel.Fatal: encoded = 42; break;
        default: encoded = 0; break;
    }
    return $"{encoded}:{message}";
    }
}
