using SQLite;

namespace LaudoBuilder
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
