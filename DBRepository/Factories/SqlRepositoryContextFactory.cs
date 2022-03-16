using DBRepository;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;

namespace XmlReader.Data.DBRepository.Factories
{
    public class SqlRepositoryContextFactory : IRepositoryContextFactory
    {
        private readonly string _connectionString;
        public SqlRepositoryContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RepositoryContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
