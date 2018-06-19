using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class TagRepository : ITagRepository
  {
    private DataContext context;

    public TagRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Tag> Tags => context.Tags;
    public void AddTag(Tag tagP)
    {
      context.Tags.Add(tagP);
      context.SaveChanges();
    }
    public void UpdateTag(Tag tagP)
    {
      Tag p = context.Tags.Find(tagP.Id);
      p.name = tagP.name;
      context.SaveChanges();
    }
    public void DeleteTag(Tag tagP)
    {
      context.Tags.Remove(tagP);
      context.SaveChanges();
    }
  }
}
