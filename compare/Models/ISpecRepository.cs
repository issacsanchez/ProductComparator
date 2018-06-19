using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface ISpecRepository
  {
    IEnumerable<Spec> Specs { get; }
    void AddSpec(Spec specP);
    void UpdateSpec(Spec specP);
    void DeleteSpec(Spec specP);
  }
}
