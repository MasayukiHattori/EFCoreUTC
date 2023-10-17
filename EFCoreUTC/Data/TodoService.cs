using EFCoreUTC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreUTC.Data
{
    public class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync() =>
            await _context.Todos.OrderByDescending(x => x.ExecutionDate).ToListAsync();

        public async Task<int> AddAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            return await _context.SaveChangesAsync();
        }
    }
}
