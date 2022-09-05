namespace Advice.Application.Dtos
{
    public class FilterSortPagedListInputDto
    {
        /// <summary>
        /// number of records to skip
        /// </summary>
        public int SkipCount { get; set; }
        /// <summary>
        /// number of records to show
        /// </summary>
        public int MaxResultCount { get; set; }
    }
}
