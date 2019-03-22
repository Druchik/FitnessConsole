using System.Data.Entity.Migrations;
using Fitness.BL.Controller;

internal sealed class Configuration : DbMigrationsConfiguration<Fitness.BL.Controller.FitnessContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        ContextKey = "Fitness.BL.Controller.FitnessContext";
    }

    protected override void Seed(FitnessContext context)
    {
        //base.Seed(context);
    }
}
