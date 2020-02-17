namespace TreinaWeb.Musicas.AcessoDados.Entity.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Classe responsável pelas aplicações das configurações das Migrations.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Context.MusicasDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.MusicasDbContext context)
        {
            
        }
    }
}
