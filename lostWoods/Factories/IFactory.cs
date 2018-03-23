using lostWoods.Models;
using System.Collections.Generic;
namespace lostWoods.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}
