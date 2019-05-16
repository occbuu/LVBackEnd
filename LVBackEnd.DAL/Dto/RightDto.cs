using SKG;
using SKG.Ext;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Dto
{
    /// <summary>
    /// Right
    /// </summary>
    public class RightDto
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public RightDto()
        {
            Children = new List<RightDto>();
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ParentId
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Route
        /// </summary>
        public string Route
        {
            get
            {
                var t = Code.ToAddSpace();
                t = t.Replace(ZConst.String.Space, ZConst.String.Minus);
                return t.ToLower();
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Sequence
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public List<RightDto> Children { get; set; }

        #endregion
    }
}