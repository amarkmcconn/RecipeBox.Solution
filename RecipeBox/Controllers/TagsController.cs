using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace RecipeBox.Controllers
{
  [Authorize]
  public class TagsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //new line
    public TagsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager; //new line
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTags = _db.Tags.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTags);
      // List<Tag> model = _db.Tags.ToList();
      // return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Tag tag)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // new line
      var currentUser = await _userManager.FindByIdAsync(userId); // new line
      tag.User = currentUser; // new line
      _db.Tags.Add(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTag = _db.Tags
          .Include(tag => tag.JoinEntities)
          .ThenInclude(join => join.Recipe)
          .FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }
    public ActionResult Edit(int id)
    {
      var thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult Edit(Tag tag)
    {
      _db.Entry(tag).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
      _db.Tags.Remove(thisTag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddRecipe(int id)
    {
        var thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
        ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
        return View(thisTag);
    }
    [HttpPost]
    public ActionResult AddRecipe(Tag tag, int RecipeId)
    {
        if (RecipeId != 0)
        {
          _db.RecipeTag.Add(new RecipeTag() { RecipeId = RecipeId, TagId = tag.TagId });
          _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    // [HttpPost]
    // public ActionResult DeleteTag(int joinId)
    // {
    //     var joinEntry = _db.RecipeTag.FirstOrDefault(entry => entry.RecipeTag == joinId);
    //     _db.RecipeTag.Remove(joinEntry);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }   
  }
}