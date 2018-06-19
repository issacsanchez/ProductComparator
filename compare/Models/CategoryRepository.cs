using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class CategoryRepository : ICategoryRepository
  {
    private DataContext context;

    public CategoryRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Category> Categories => context.Categories;

    public void AddCategory(Category category)
    {
      context.Categories.Add(category);
      context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
      Category p = context.Categories.Find(category.Id);
      p.name = category.name;
      context.SaveChanges();
    }
    public void DeleteCategory(Category category)
    {
      context.Categories.Remove(category);
      context.SaveChanges();
    }
  }
}
