using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        List<TodoItem> todoItems = new List<TodoItem>();

        public TodoItemsController()
        {
            todoItems.Add(new TodoItem
            {
                Id = 1,
                Name = "Item 1",
                IsCompleate = true
            });

            todoItems.Add(new TodoItem
            {
                Id = 2,
                Name = "Item 2",
                IsCompleate = false
            });

        }


        [HttpGet]
        public List<TodoItem> Get()
        {
            return todoItems;
        }


        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item= todoItems.SingleOrDefault(a => a.Id == id);
            if(item==null) return NotFound();
            else return item;
        }


        [HttpPost]
        public ActionResult Post([FromBody] TodoItem todoItem)
        {
            todoItems.Add(todoItem);
            return CreatedAtAction("GetById", new {id=todoItem.Id }, todoItems);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]TodoItem todoItem)
        {
          var eitem=todoItems.Find(a => a.Id == id);    
            if (eitem==null) return NotFound();     
            foreach (var item in todoItems)
            {
                if(item.Id == id)
                {
                    item.Name = todoItem.Name;
                }
            }
            return Ok(todoItem);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = todoItems.Find(a => a.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            todoItems.Remove(todoItem);
            return NoContent();


        }

    }
}
