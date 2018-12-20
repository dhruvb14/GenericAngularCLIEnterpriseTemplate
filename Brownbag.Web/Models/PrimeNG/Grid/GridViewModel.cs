using Reinforced.Typings.Attributes;

namespace Models.PrimeNG.Grid
{
    [TsInterface(AutoI=false)]
    public class GridViewModel<T> : GridPaginator
    {
        ///<summary>
        /// Generic Data responce holder for PrimeNG Grid Data
        ///</summary>
        public T[] Data { get; set; }
        ///<summary>
        /// Generic Error responce holder for PrimeNG Grid Data
        ///</summary>
        public string Errors { get; set; }
        ///<summary>
        /// Passes back the search query
        ///</summary>
        public string SearchQuery { get; set; }
    }
}