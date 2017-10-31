using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            //return y
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
                throw new DuplicateTodoItemException("duplicate id: { " + todoItem.Id + " }");

            _inMemoryTodoDatabase.Add(todoItem);
            return _inMemoryTodoDatabase.Last();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(t => t.Id == todoId).FirstOrDefault();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(t => t.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderBy(t => t.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(t => t.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(t => filterFunction(t)).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Count == 0 || this.Get(todoId) == null) return false;
            return _inMemoryTodoDatabase.Where(t => t.Id == todoId).First().MarkAsCompleted();
        }

        public bool Remove(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Count == 0 || this.Get(todoId) == null) return false;
            return _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.Where(t => t.Id == todoId).First());
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (!(_inMemoryTodoDatabase.Contains(todoItem)))
            {
                return this.Add(todoItem);
            }
            _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.Where(t => t.Id == todoItem.Id).First());
            return this.Add(todoItem);

        }
    }
}
