using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface IManufactureRepository
  {
    IEnumerable<Manufacture> Manufactures { get; }
    void AddManufacture(Manufacture manufacture);
    void UpdateManufacture(Manufacture manufacture);
    void DeleteManufacture(Manufacture manufacture);
  }
}
