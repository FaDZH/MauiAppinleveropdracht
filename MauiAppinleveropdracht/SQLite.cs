using SQLite;

namespace MauiAppinleveropdracht;

public static class DBConstants
{
    private const string DBFileName = "SQLiteDemo.db3";

    public const SQLiteOpenFlags Flags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DBFileName);
}