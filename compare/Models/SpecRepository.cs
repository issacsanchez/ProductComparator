using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class SpecRepository : ISpecRepository
  {
    private DataContext context;

    public SpecRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Spec> Specs => context.Specs;
    public void AddSpec(Spec specP)
    {
      context.Specs.Add(specP);
      context.SaveChanges();
    }
    public void UpdateSpec(Spec specP)
    {
      Spec p = context.Specs.Find(specP.Id);
      p.name = specP.name;
      context.SaveChanges();
    }
    public void DeleteSpec(Spec specP)
    {
      context.Specs.Remove(specP);
      context.SaveChanges();
    }
  }
}
