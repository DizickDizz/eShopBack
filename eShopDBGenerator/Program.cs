using System.Data.SQLite;
class TestClass
{
    static readonly SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=e-shop.db;Version=3;");
    static void Main(string[] args)
    {
        SQLiteConnection.CreateFile("e-shop.db");

        m_dbConnection.Open();
        
        var sql = "CREATE TABLE Carts (Id INTEGER NOT NULL," +
            "user_id INTEGER NOT NULL," +
            "product_id INTEGER NOT NULL," +
            "quantity INTEGER NOT NULL," +
            "state INTEGER NOT NULL," +
            "PRIMARY KEY(Id AUTOINCREMENT) );";
        MakeARequest(sql); //Carts
        sql = "CREATE TABLE OrderItems (" +
            "Id   INTEGER NOT NULL," +
            "user_id   INTEGER NOT NULL," +
            "order_id  INTEGER NOT NULL," +
            "product_id    INTEGER NOT NULL," +
            "quantity  INTEGER NOT NULL," +
            "PRIMARY KEY(Id AUTOINCREMENT) );";
        MakeARequest(sql); //OrderItems
        sql = "CREATE TABLE Orders (" +
            "Id    INTEGER NOT NULL," +
            "user_id   INTEGER NOT NULL," +
            "order_price   INTEGER NOT NULL," +
            "order_status  INTEGER NOT NULL," +
            "PRIMARY KEY(Id AUTOINCREMENT) );";
        MakeARequest(sql); //Orders
        sql = "CREATE TABLE Products (" +
            "Id    INTEGER NOT NULL," +
            "name  STRING," +
            "cost  INTEGER NOT NULL," +
            "amount_left   INTEGER NOT NULL," +
            "PRIMARY KEY(Id AUTOINCREMENT) );";
        MakeARequest(sql); //Products
        sql = "CREATE TABLE Users (" +
            "Id    INTEGER NOT NULL," +
            "Username  TEXT NOT NULL," +
            "Password  TEXT NOT NULL," +
            "PRIMARY KEY(Id AUTOINCREMENT) );";
        MakeARequest(sql); //Users

        sql = "INSERT INTO Products (name, cost, amount_left) VALUES (\"Кусочек пиццы\", 79, 85)";
        MakeARequest(sql);
        sql = "INSERT INTO Products (name, cost, amount_left) VALUES (\"Кока-кова\", 129, 100)";
        MakeARequest(sql);
        sql = "INSERT INTO Products (name, cost, amount_left) VALUES (\"Айфончик\", 100000, 5)";
        MakeARequest(sql);
        sql = "INSERT INTO Products (name, cost, amount_left) VALUES (\"Крутая клава с алика\", 2999, 10)";
        MakeARequest(sql);
        sql = "INSERT INTO Products (name, cost, amount_left) VALUES (\"Виски Деза\", 7027, 1)";
        MakeARequest(sql);

        m_dbConnection.Close();
    }

    public static void MakeARequest(string sql)
    {
        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();
    }
}



