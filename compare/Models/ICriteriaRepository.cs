using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface ICriteriaRepository
  {
    IEnumerable<Criteria> Criterias { get; }
    void AddCriteria(Criteria criteria);
    void UpdateCriteria(Criteria criteria);
    void DeleteCriteria(Criteria criteria);
  }
}
