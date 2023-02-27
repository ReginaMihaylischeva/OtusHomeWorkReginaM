using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HomeWork1.Mapping;
using NHibernate.Cfg;
using Npgsql;
using NHibernate;

namespace HomeWork1
{
    static class DbInfoService
    {
        public const string connectionString = "Host=localhost;Username=postgres;Password=regina;Database=otus1";

        private static Configuration GetConfiguration()
        {
            var config = Fluently.Configure().
                              Database(
                                  PostgreSQLConfiguration
                                      .PostgreSQL81
                                      .ConnectionString(x => x
                                          .Database("otus1")
                                          .Password("regina")
                                          .Port(5432)
                                          .Username("postgres")
                                          .Host("localhost"))
                                          .UseReflectionOptimizer())
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BasketMap>())
                              .BuildConfiguration();

            return config;
        }

        public static string GetTableNames()
        {
            var connection = new NpgsqlConnection(DbInfoService.connectionString);
            connection.Open();

            var sql = "SELECT table_name FROM information_schema.tables WHERE table_schema NOT IN('information_schema','pg_catalog'); ";

            var cmd = new NpgsqlCommand(sql, connection);
            var tableNames = "\n";

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tableNames += reader.GetString(0) + "\n";
            }

            return tableNames;
        }
        public static ISession GetSession()
        {

            var config = GetConfiguration();

            ISessionFactory factory = config.BuildSessionFactory();

            ISession session = factory.OpenSession();

            return session;
        }
    }
}
