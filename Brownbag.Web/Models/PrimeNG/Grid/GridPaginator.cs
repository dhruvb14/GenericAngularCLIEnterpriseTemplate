using Reinforced.Typings.Attributes;

namespace Models.PrimeNG.Grid
{
    [TsInterface(AutoI=false)]
    public class GridPaginator
    {
        ///<summary>
        /// First Item in PrimeNG Grid Data
        ///</summary>
        public int First { get; set; }
        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int Page { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
        ///<summary>
        /// Gets or sets Rows
        ///</summary>
        public int Rows { get; set; }
    }
}