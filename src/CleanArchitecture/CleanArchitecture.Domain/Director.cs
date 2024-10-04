using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Director : BaseDomainModel
    {
        public string? Name          { get; set; }
        public string? LastName      { get; set; }

        #region LlaveForaneaAVideo
        public int VideoId           { get; set; }
        public virtual Video? Video  { get; set; }
        #endregion
    }
}
