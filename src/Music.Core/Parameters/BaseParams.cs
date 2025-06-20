using Music.Application.Parameters;

namespace Music.Core.Parameters
{
    public class BaseParams : PaginationParams
    {
        public string Search { get; set; } = string.Empty;
        public virtual string OrderBy { get; set; } = "id_desc";
    }
}
