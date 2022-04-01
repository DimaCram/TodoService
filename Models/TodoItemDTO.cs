using Swashbuckle.AspNetCore.Annotations;

namespace TodoApi.Models
{
    #region snippet
    public class TodoItemDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    #endregion
}
