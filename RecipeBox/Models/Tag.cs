using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Tag
    {
        public Tag()
        {
            this.JoinEntities = new HashSet<RecipeTag>();
        }

        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; } //new line
        public virtual ICollection<RecipeTag> JoinEntities { get; set; }
    } 
}