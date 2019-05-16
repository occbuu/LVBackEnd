using System.Collections.Generic;

namespace LVBackEnd.DAL.Dto
{
    /// <summary>
    /// Payload
    /// </summary>
    public class PayloadDto
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public PayloadDto()
        {
            Rights = new List<string>();
            Menu = new List<RightDto>();
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Rights
        /// </summary>
        public List<string> Rights { get; set; }

        /// <summary>
        /// Menu
        /// </summary>
        public List<RightDto> Menu { get; set; }

        #endregion
    }
}