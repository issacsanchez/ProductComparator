﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface ICategoryRepository
  {
    IEnumerable<Category> Categories { get; }
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);

  }
}
