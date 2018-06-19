using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class ManufactureRepository : IManufactureRepository
  {
    private DataContext context;

    public ManufactureRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Manufacture> Manufactures => context.Manufactures;

    public void AddManufacture(Manufacture manufacture)
    {
      context.Manufactures.Add(manufacture);
      context.SaveChanges();
    }

    public void UpdateManufacture(Manufacture manufacture)
    {
      Manufacture p = context.Manufactures.Find(manufacture.Id);
      p.name = manufacture.name;
      context.SaveChanges();
    }
    public void DeleteManufacture(Manufacture manufacture)
    {
      context.Manufactures.Remove(manufacture);
      context.SaveChanges();
    }
  }
}
