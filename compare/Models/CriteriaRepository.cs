using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class CriteriaRepository : ICriteriaRepository
  {
    private DataContext context;
    public CriteriaRepository(DataContext ctx) => context = ctx;
    public IEnumerable<Criteria> Criterias => context.Criterias;
    public void AddCriteria(Criteria criteria)
    {
      context.Criterias.Add(criteria);
      context.SaveChanges();
    }
    public void UpdateCriteria(Criteria criteria)
    {
      Criteria p = context.Criterias.Find(criteria.Id);
      p.name = criteria.name;
      context.SaveChanges();
    }
    public void DeleteCriteria(Criteria criteria)
    {
      context.Criterias.Remove(criteria);
      context.SaveChanges();
    }
  }
}
