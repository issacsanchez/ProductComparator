using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface ITagRepository
  {
    IEnumerable<Tag> Tags { get; }
    void AddTag(Tag tagP);
    void UpdateTag(Tag tagP);
    void DeleteTag(Tag tagP);
  }
}
